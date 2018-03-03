using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class OrderGateway : IGateway
    {
        public DatabaseConnection.QueryStatus Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IDatabaseEntity Find(string id)
        {
            throw new NotImplementedException();
        }

        public string GetNextID()
        {
            throw new NotImplementedException();
        }

        public DatabaseConnection.QueryStatus Insert(IDatabaseEntity obj)
        {
            PurchaseOrder order = (PurchaseOrder)obj;

            if (order.IsValid())
            {
                SqlCommand command = new SqlCommand("AddOrder", DatabaseConnection.getConn());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ed", order.ExpectedDate);
                command.Parameters.AddWithValue("@s", Int32.Parse(order.Supplier));

                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.Read() && (Boolean)rdr["Success"])
                {
                    rdr.Close();
                    /*foreach (Price p in item.Prices)
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
                    }*/
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
