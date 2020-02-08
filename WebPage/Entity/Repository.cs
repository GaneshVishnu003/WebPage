﻿using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebPage.Entity
{
    public class Repository
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string mail { get; set; }
        public long mobile { get; set; }
        public string password { get; set; }
        public string location { get; set; }

        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static SqlConnection dbConnection = new SqlConnection(connectionString);
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

        internal static DataTable Addnew(string newLocation)
        {
            //DataTable data=new DataTable();
            //using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                dbConnection.Open();
                string command = "spInsertLocation";
                using(SqlCommand insertCommand=new SqlCommand(command,dbConnection))
                {
                    insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@newLocation", newLocation);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.InsertCommand = insertCommand;
                    int i = insertCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select * from location",dbConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter1.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        
        public int CustomerDbConnection(Repository SignUpObject)
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
