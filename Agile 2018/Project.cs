using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Agile_2018
{
    public class Project
    {
        //make a connection string
        
        
        public bool CreateProject(string title)
        {
            MySqlCommand cmd;
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand(); //New Connection object

            try
            {
                //SQL Query
                cmd.CommandText = "INSERT INTO projects(Title)VALUES(@title)";

                // Populate SQl query values
                cmd.Parameters.AddWithValue("@title", title);

                // Execute Query
                cmd.ExecuteNonQuery();

                // Close Connection
                ConnectionClass.CloseConnection();
                return true;
            }
            catch(Exception)
            {
                ConnectionClass.CloseConnection();
                return false;
                throw;
            }
        }

        //method to update project title.
        public bool UpdateProject(int projectID, string title)
        {
            MySqlCommand cmd;
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand(); //New Connection object

            try
            {
                //SQL Query
                cmd.CommandText = "Update projects SET Title = @title WHERE ProjectID = @projectID ";

                // Populate SQl query values
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@projectID",projectID);

                // Execute Query
                cmd.ExecuteNonQuery();

                // Close Connection
                ConnectionClass.CloseConnection();
                return true;
            }
            catch (Exception)
            {
                ConnectionClass.CloseConnection();
                return false;
                throw;
            }
        }
    }
}