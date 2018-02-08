using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public static class DatabaseConnection
    {
        
        private static SqlConnection dbconn;

        public static String connError { get; private set; }

        private static void setConn()
        {
            dbconn = new SqlConnection("user id=applogin;" +
                                        "password=password;" +
                                        "server=localhost;" +
                                        //"Trusted_Connection=yes;" +
                                        "MultipleActiveResultSets=True;" +
                                        "database=TestDB; " +
                                        "connection timeout=10");
        }

        public static SqlConnection getConn()
        {
            if (dbconn == null || dbconn.State == ConnectionState.Closed)
            {
                startDBConnection();
            }
            return dbconn;
        }

        public static Boolean startDBConnection()
        {
            setConn();
            try
            {
                dbconn.Open();
            }
            catch (SqlException e)
            {
                connError = e.Message;
                return false;
            }
            return true;
        }

        public static String getNextAvailableID(String tname)
        {
            SqlCommand command = new SqlCommand("GetNextAvailableID", getConn());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@tbname", tname);

            SqlParameter returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();

            int id = (int)returnParameter.Value;
            return id.ToString().PadLeft(7, '0');
        }
        
    }
}
