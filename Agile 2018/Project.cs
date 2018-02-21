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


        public String CreateProject(string title, int userID)
        {
            MySqlCommand cmd;
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand(); //New Connection object

            try
            {
                //FIRST INSERT THE NEW PROJECT INTO THE PROJECTS TABLE
                //SQL Query
                cmd.CommandText = "INSERT INTO projects(Title)VALUES(@title);SELECT LAST_INSERT_ID();";

                // Populate SQl query values
                cmd.Parameters.AddWithValue("@title", title);

                // Execute Query
                MySqlDataReader reader = cmd.ExecuteReader();
                String pID = "";
                while (reader.Read())
                {
                    pID = reader.GetString("LAST_INSERT_ID()");
                }
                reader.Close();

                //FOLLOW BY INSERTING THE PROJECT AND ID INTO LINK
                //SQL Query
                cmd.CommandText = "INSERT INTO userprojectpairing(LoginDetails_UserID,Projects_ProjectID)VALUES(@userID,@projID)";

                // Populate SQl query values
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@projID", pID);
               

                // Execute Query
                cmd.ExecuteNonQuery();

                // Close Connection
                ConnectionClass.CloseConnection();
                return pID;
            }
            catch(Exception)
            {
                ConnectionClass.CloseConnection();
                return null;
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