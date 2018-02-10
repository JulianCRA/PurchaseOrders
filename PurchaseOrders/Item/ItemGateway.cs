using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class ItemGateway : IGateway
    {
        public DatabaseConnection.QueryStatus Delete(string id)
        {
            SqlCommand command = new SqlCommand("SetInactive", DatabaseConnection.getConn());
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@tbname", "Item");
            command.Parameters.AddWithValue("@token", Int32.Parse(id));
            command.ExecuteNonQuery();

            return DatabaseConnection.QueryStatus.Success;
        }

        public IDatabaseEntity Find(string id)
        {
            SqlCommand command = new SqlCommand("GetItemInfo", DatabaseConnection.getConn());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@token", id);

            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                SqlCommand command2 = new SqlCommand("GetItemPrices", DatabaseConnection.getConn());
                command2.CommandType = CommandType.StoredProcedure;

                command2.Parameters.AddWithValue("@token", rdr["ID"].ToString());

                SqlDataReader rdr2 = command2.ExecuteReader();
                List<Price> l = new List<Price>();
                while (rdr2.Read())
                {
                    Price p = new Price(rdr2["ID"].ToString(), rdr["ID"].ToString(), rdr2["PricePerUnit"].ToString(), rdr2["Currency"].ToString(), rdr2["Unit"].ToString());
                    l.Add(p);
                }
                rdr2.Close();

                Item s = new Item(rdr["ID"].ToString(), rdr["Supplier"].ToString(), rdr["Name"].ToString(), rdr["Description"].ToString(), l);
                rdr.Close();
                return s;
            }
            rdr.Close();
            return null;
        }

        public string GetNextID()
        {
            return DatabaseConnection.getNextAvailableID("Item");
        }

        public DatabaseConnection.QueryStatus Insert(IDatabaseEntity obj)
        {
            Item item = (Item)obj;

            if (item.IsValid())
            {
                SqlCommand command = new SqlCommand("AddItem", DatabaseConnection.getConn());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@n", item.Name);
                command.Parameters.AddWithValue("@d", item.Description);
                command.Parameters.AddWithValue("@i", Int32.Parse(item.ID));
                command.Parameters.AddWithValue("@s", Int32.Parse(item.Supplier));

                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.Read() && (Boolean)rdr["Success"])
                {
                    rdr.Close();
                    foreach (Price p in item.Prices)
                    {
                        if (!p.ffd)    // if the price entry is not flagged for deletion
                        {
                            command = new SqlCommand("AddPrice", DatabaseConnection.getConn());
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@id", Int32.Parse(p.ID));
                            command.Parameters.AddWithValue("@item", Int32.Parse(p.Item));
                            command.Parameters.AddWithValue("@ppu", p.PricePerUnit);
                            command.Parameters.AddWithValue("@currency", p.Currency);
                            command.Parameters.AddWithValue("@unit", p.Unit);

                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            //Delete(p.ID);
                        }
                    }
                    return DatabaseConnection.QueryStatus.Success;
                }
                else
                {
                    rdr.Close();
                    return DatabaseConnection.QueryStatus.Fail;  // transaction failed at database level
                }
            }
            return DatabaseConnection.QueryStatus.DataError; // wrongly formatted data
        }

        public IEnumerable<IDatabaseEntity> SearchByName(string token)
        {
            SqlCommand command = new SqlCommand("SearchItem", DatabaseConnection.getConn());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@token", token);

            SqlDataReader rdr = command.ExecuteReader();
            List<Item> list = new List<Item>();
            while (rdr.Read())
            {
                Item i = new Item(rdr["ID"].ToString(), rdr["Supplier"].ToString(), rdr["Name"].ToString(), String.Empty, null);
                list.Add(i);
            }

            return list;
        }

        public DatabaseConnection.QueryStatus Update(IDatabaseEntity obj)
        {
            Item item = (Item)obj;
            if (item.IsValid())
            {
                SqlCommand command = new SqlCommand("UpdateItem", DatabaseConnection.getConn());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@n", item.Name);
                command.Parameters.AddWithValue("@d", item.Description);
                command.Parameters.AddWithValue("@i", Int32.Parse(item.ID));
                command.Parameters.AddWithValue("@s", Int32.Parse(item.Supplier));
                command.ExecuteNonQuery();

                foreach (Price p in item.Prices)
                {
                    if (!p.ffd)    // if the price entry is not flagged for deletion
                    {
                        command = new SqlCommand("AddPrice", DatabaseConnection.getConn());
                        command.CommandType = CommandType.StoredProcedure;
                    
                        command.Parameters.AddWithValue("@id", Int32.Parse(p.ID));
                        command.Parameters.AddWithValue("@item", Int32.Parse(p.Item));
                        command.Parameters.AddWithValue("@ppu", p.PricePerUnit);
                        command.Parameters.AddWithValue("@currency", p.Currency);
                        command.Parameters.AddWithValue("@unit", p.Unit);

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        Delete(p.ID);
                    }
                }
                return DatabaseConnection.QueryStatus.Success;
            }
            return DatabaseConnection.QueryStatus.DataError;   // Invalid data formatting
        }

        public DataTable GetSuppliers()
        {
            SqlCommand command = new SqlCommand("GetSupplierList", DatabaseConnection.getConn());
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            sqlda.SelectCommand = command;

            sqlda.Fill(dt);
            command.Dispose();

            return dt;
        }
    }
}
