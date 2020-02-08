using System;
using System.Data;
using System.Data.SqlClient;

namespace OnlineCabBooking.DAL
{
    public class CustomerConnection
    {
        internal static DataTable ViewLocation()
        {
            string connectionString1 = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString1))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Location", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }


        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection dbConnection = new SqlConnection(connectionString);

        public static object ConfigurationManager { get; private set; }

        public int CustomerDbConnection(CustomerRepository SignUpObject)
        {
            int affectedRows;
            try
            {
                dbConnection.Open();
                string command = "spInsertIntoCustomer";              //stored prodecure
                using (SqlCommand insertCommand = new SqlCommand(command, dbConnection))
                {
                    insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@fname", SignUpObject.fName);
                    insertCommand.Parameters.AddWithValue("@lname", SignUpObject.lName);
                    insertCommand.Parameters.AddWithValue("@mailId", SignUpObject.mail);
                    insertCommand.Parameters.AddWithValue("@phone", SignUpObject.mobile);
                    insertCommand.Parameters.AddWithValue("@location", SignUpObject.location);
                    insertCommand.Parameters.AddWithValue("@password", SignUpObject.password);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.InsertCommand = insertCommand;
                    affectedRows = insertCommand.ExecuteNonQuery();
                }
                return affectedRows;
            }
            catch (Exception e)
            {
                //Console.WriteLine("{0}- {1}", e.GetType(), e.Message);
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
