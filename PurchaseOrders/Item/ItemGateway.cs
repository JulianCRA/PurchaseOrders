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
            throw new NotImplementedException();
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
                    Price p = new Price(rdr2["ID"].ToString(), rdr2["PricePerUnit"].ToString(), rdr2["Currency"].ToString(), rdr2["Unit"].ToString());
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
            throw new NotImplementedException();
        }

        public IEnumerable<IDatabaseEntity> SearchByName(string token)
        {
            throw new NotImplementedException();
        }

        public DatabaseConnection.QueryStatus Update(IDatabaseEntity obj)
        {
            throw new NotImplementedException();
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
