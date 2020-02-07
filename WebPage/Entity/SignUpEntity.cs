using System;
using System.Data.SqlClient;
using System.Configuration;
namespace WebPage.Entity
{
    public class SignUpEntity
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string mail { get; set; }
        public long mobile { get; set; }
        public string password { get; set; }
        public string location { get; set; }

        


        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        public int CustomerDbConnection(SignUpEntity SignUpObject)
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
                    insertCommand.Parameters.AddWithValue("@mailId",SignUpObject.mail);
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
