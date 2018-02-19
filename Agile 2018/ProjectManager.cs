using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Agile_2018
{
    public class ProjectManager
    {
        //1. take in project id
        //2. query projects in database for the row with this id
        //3. query stored files for all files with this id in the database. 
        //4. you should have 2 arrays at this point. one with the first query and one with the second query, 
        //5. Combine these in some way, such as with a json
        //6. return the combined results from the json file. 


        //DB INFO:
        //Hostname: silva.computing.dundee.ac.uk    
        //Port: 3306
        //Username: 17agileteam5
        //Password: 7485.at5.5847


        //Method which returns a datatable containing all the information returned for a project based on the projectID passed to it. 
        public DataTable viewProjectInfo(int input)
        {
            //Connects to database
            ConnectionClass.OpenConnection();

            //Declare new mysql command using connection to return project info relevent to this projectID
            String query = "SELECT * FROM projects WHERE ProjectID = '" + input + "'";

            //Create datatable for results to be read into
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionClass.con);
            //Fill the datatable with the results from the MYSQL command using data adapter
            sda.Fill(dt);

            //If the datatable is empty, ie the project row does not exist in the database, then return null.
            if (dt == null)
            {
                return null;
            }
            //else if the project record does exist, return this datatable. 
            else
            {
                return dt;
            }
        }

        //Method which returns a datatable containing all the related files returned based on the projectID passed to it. 
        public DataTable viewProjectFiles(int input)
        {


            //Connects to database
            ConnectionClass.OpenConnection();

            //Declare new mysql command using connection to return files from storedfiles table relevent to this projectID
            String query = "SELECT * FROM storedfiles WHERE ProjectID = '" + input + "'";

            //Create datatable for results to be read into
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionClass.con);
            //Fill the datatable with the results from the MYSQL command using data adapter
            sda.Fill(dt);
            ConnectionClass.CloseConnection();
            return dt;
        }

        //Method which returns all project records which have a status code of 0, ie need to be confirmed by a researcher. 
        public DataTable getResearcherUnconfirmedProjects()
        {
            //Connects to database
            ConnectionClass.OpenConnection();

            //Declare new mysql command using connection to returns all projects which need
            MySqlCommand cmd = ConnectionClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM projects WHERE StatusCode = '0'";
            cmd.ExecuteNonQuery();

            //Create datatable for results to be read into
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //Fill the datatable with the results from the MYSQL command using data adapter
            da.Fill(dt);

            //If the datatable is empty, ie there are no Projects which require a researcher to confirm
            if (dt == null)
            {
                return null;
            }
            //else if there are projects to be confirmed 
            else
            {
                return dt;
            }
        }


        //Function which takes in a ProjectID for the project to be confirmed, changing its status code to 1 and its Researcher signed value to 1
        public void researcherConfirmation(int input)
        {
            //Connects to database
            ConnectionClass.OpenConnection();

            //Declare new mysql command using connection which sets user specified project's ResearcherSigned and StatusCode values to 1
            MySqlCommand cmd = ConnectionClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE projects SET ResearcherSigned = '1', StatusCode = '1' WHERE ProjectID = '" + input + "'";
            cmd.ExecuteNonQuery();
        }


    }
}