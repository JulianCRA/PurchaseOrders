using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class SupplierGateway : IGateway
    {
        public DatabaseConnection.QueryStatus Delete(string id)
        {
            SqlCommand command = new SqlCommand("SetInactive", DatabaseConnection.getConn());
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@tbname", "Supplier");
            command.Parameters.AddWithValue("@token", Int32.Parse(id));
            command.ExecuteNonQuery();

            return DatabaseConnection.QueryStatus.Success;
        }

        public IDatabaseEntity Find(string id)
        {
            SqlCommand command = new SqlCommand("GetSupplierInfo", DatabaseConnection.getConn());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@token", id);

            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                Supplier s = new Supplier(rdr["ID"].ToString(), rdr["Name"].ToString(), rdr["Email"].ToString());
                rdr.Close();
                return s;
            }
            rdr.Close();
            return null;
        }

        public string GetNextID()
        {
            return DatabaseConnection.getNextAvailableID("Supplier");
        }

        public DatabaseConnection.QueryStatus Insert(IDatabaseEntity obj)
        {
            Supplier s = (Supplier)obj;

            if (s.IsValid())
            {
                SqlCommand command = new SqlCommand("AddSupplier", DatabaseConnection.getConn());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", Int32.Parse(s.id));
                command.Parameters.AddWithValue("@Name", s.name);
                command.Parameters.AddWithValue("@Email", s.email);

                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.Read() && (Boolean)rdr["Success"])
                {
                    rdr.Close();
                    return DatabaseConnection.QueryStatus.Success;  //  successful transaction
                }
                else
                {
                    rdr.Close();
                    return DatabaseConnection.QueryStatus.Fail;  // transaction failed at database level
                }
            }
            return DatabaseConnection.QueryStatus.DataError;
        }

        public IEnumerable<IDatabaseEntity> SearchByName(string token)
        {
            SqlCommand command = new SqlCommand("SearchSupplierByName", DatabaseConnection.getConn());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@token", token);

            SqlDataReader rdr = command.ExecuteReader();
            List<Supplier> list = new List<Supplier>();
            while (rdr.Read())
            {
                Supplier s = new Supplier(rdr["ID"].ToString(), rdr["Name"].ToString(), rdr["Email"].ToString());
                list.Add(s);
            }

            return list;
        }

        public DatabaseConnection.QueryStatus Update(IDatabaseEntity obj)
        {
            Supplier s = (Supplier)obj;
            if (s.IsValid())
            {
                SqlCommand command = new SqlCommand("UpdateSupplier", DatabaseConnection.getConn());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@n", s.name);
                command.Parameters.AddWithValue("@e", s.email);
                command.Parameters.AddWithValue("@i", Int32.Parse(s.id));
                command.ExecuteNonQuery();

                return DatabaseConnection.QueryStatus.Success; // Assumed success. can be expanded to handle messages from the database
            }

            return DatabaseConnection.QueryStatus.DataError;   // Invalid data formatting
        }
    }
}
