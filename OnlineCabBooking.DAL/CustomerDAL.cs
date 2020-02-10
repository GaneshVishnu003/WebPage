using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OnlineCabBooking.Entity;

namespace OnlineCabBooking.DAL
{
    public class CustomerDAL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static SqlConnection dbConnection = new SqlConnection(connectionString);

        public static void InsertRow(string location)
        {
            using(SqlCommand cmd=new SqlCommand("spInsert",dbConnection))
            {
                dbConnection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@location", location);
                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public static void UpdateRow(string location,int id)
        {
            using (SqlCommand cmd = new SqlCommand("spUpdate", dbConnection))
            {
                dbConnection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteRow(int id)
        {
            using (SqlCommand cmd = new SqlCommand("spDelete", dbConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                dbConnection.Open();
                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public static DataTable ViewLocation()
        {
            //string connectionString1 = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Location", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public static DataTable Addnew(string newLocation)
        {
            //DataTable data=new DataTable();
            //using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
               // dbConnection.Open();
                string command = "spInsertLocation";
                using (SqlCommand insertCommand = new SqlCommand(command, dbConnection))
                {
                    insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@newLocation", newLocation);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.InsertCommand = insertCommand;
                    dbConnection.Open();
                    int i = insertCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select * from location", dbConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter1.Fill(dataTable);
                    dbConnection.Close();
                    return dataTable;
                }
            }
        }

        public static int CustomerDbConnection(CustomerEntity SignUpObject)
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
                    insertCommand.Parameters.AddWithValue("@mailid", SignUpObject.mail);
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
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
