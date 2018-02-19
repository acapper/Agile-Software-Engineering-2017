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


        public bool CreateProject(string title, int userID)
        {
            MySqlCommand cmd;
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand(); //New Connection object

            try
            {
                //FIRST INSERT THE NEW PROJECT INTO THE PROJECTS TABLE
                //SQL Query
                cmd.CommandText = "INSERT INTO projects(Title)VALUES(@title)";

                // Populate SQl query values
                cmd.Parameters.AddWithValue("@title", title);

                // Execute Query
                cmd.ExecuteNonQuery();

                //query server to find out what ID that record got
                cmd.CommandText = "SELECT ProjectID From projects Where Title = @newtitle";
                cmd.Parameters.AddWithValue("@newtitle", title);
                //Read the return and grab the HIGHEST project ID. This allows multiple of the same named records
                string projID = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projID = reader["ProjectID"].ToString();
                  
                }
                reader.Close();

                //FOLLOW BY INSERTING THE PROJECT AND ID INTO LINK
                //SQL Query
                cmd.CommandText = "INSERT INTO userprojectpairing(LoginDetails_UserID,Projects_ProjectID)VALUES(@userID,@projID)";

                // Populate SQl query values
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@projID", projID);
               

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
    }
}