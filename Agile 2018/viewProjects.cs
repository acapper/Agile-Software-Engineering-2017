using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Agile_2018
{
    public class ViewProjects
    {
        /// <summary>
        /// Function which returns all projects associated with Staff ID.
        /// For procedure to work, user must have linked projects to their userID
        /// i.e records must exist in userprojectpairing table
        /// </summary>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public DataTable ViewResearcherProjects(int userID)
        {
            DataTable dataTable = new DataTable();

            //assign stored procedure
            string storedProc = "viewAllResearcherProjects;";   

            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();

            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?uID", userID));

            //execute procedure
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            //close connection
            connection.Close();
            adapter.Dispose();

            //return table data
            return dataTable;
        }

        public DataTable ViewProjectsToSign(int status)
        {
            DataTable dataTable = new DataTable();

            //assign stored procedure
            string storedProc = "viewProjectsToSign;";

            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();

            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?p", status));

            //execute procedure
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            //close connection
            connection.Close();
            adapter.Dispose();

            //return table data
            return dataTable;
        }
    }
}