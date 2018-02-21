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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool UpdateTitle(int projectID, string title)
        {
            //assign stored procedure
            string storedProc = "updateTitle;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            cmd.Parameters.Add(new MySqlParameter("?title", title));
            //execute procedure
            cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return true;
        }

        /*
         * Potential generic sign/reject methods
         * 
        public int Sign(int projectID, string staffID, string proc)
        {
            //assign stored procedure
            string storedProc = proc;
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            cmd.Parameters.Add(new MySqlParameter("?sID", staffID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        public int ResearcherReject(int projectID, string proc)
        {
            //assign stored procedure
            string storedProc = proc";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }
        */

        /// <summary>
        /// Sets project record researcherSigned field = staffID. 
        /// Increments project record statusCode 1.
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        /// 
        public int ResearcherSign(int projectID, string staffID)
        {
            //assign stored procedure
            string storedProc = "researcherSignProject;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            cmd.Parameters.Add(new MySqlParameter("?sID", staffID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Sets project record RISSigned field = staffID. 
        /// Increments project record statusCode 1.
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public int RISSign(int projectID, string staffID)
        {
            //assign stored procedure
            string storedProc = "RISSign;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            cmd.Parameters.Add(new MySqlParameter("?sID", staffID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Sets project record AssocDeanSigned field = staffID. 
        /// Increments project record statusCode 1.
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public int AssocDeanSign(int projectID, string staffID)
        {
            //assign stored procedure
            string storedProc = "assocDeanSign;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            cmd.Parameters.Add(new MySqlParameter("?sID", staffID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Sets project record DeanSigned field = staffID. 
        /// Increments project record statusCode 1.
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public int DeanSign(int projectID, string staffID)
        {
            //assign stored procedure
            string storedProc = "deanSign;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            cmd.Parameters.Add(new MySqlParameter("?sID", staffID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Update project record statusCode to 5(rejected).
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public int ResearcherReject(int projectID)
        {
            //assign stored procedure
            string storedProc = "``ResearcherRejectProject``;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Update project record statusCode to 5(rejected).
        /// Sets researcherSigned field to 0. 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public int RISReject(int projectID)
        {
            //assign stored procedure
            string storedProc = "``RISRejectProject``;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Update project record statusCode to 5(rejected).
        /// Sets researcherSigned & RISSigned fields to 0. 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public int AssocDeanReject(int projectID)
        {
            //assign stored procedure
            string storedProc = "``assocDeanRejectProject``;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        /// <summary>
        /// Update project record statusCode to 5(rejected).
        /// Sets AssocDeanSigned, researcherSigned & RISSigned fields to 0. 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public int DeanReject(int projectID)
        {
            //assign stored procedure
            string storedProc = "`deanRejectProject`;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }

        //clears the values of signings for testing purposes
        public int ClearValuesForTesting(int projectID)
        {
            //assign stored procedure
            string storedProc = "ClearValuesForTesting;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", projectID));
            //execute procedure
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }
    }
}