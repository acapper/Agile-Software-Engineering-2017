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
        public DataTable ViewResearcherProjects(string staffID)
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
            cmd.Parameters.Add(new MySqlParameter("?sID", staffID));

            //execute procedure
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            //close connection and return number of rows affected (should be 1)
            connection.Close();
            adapter.Dispose();

            //return table data
            return dataTable;
        }
    }
}