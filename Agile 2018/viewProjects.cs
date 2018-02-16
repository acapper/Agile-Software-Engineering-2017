﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

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
        public int ViewResearcherProjects(string staffID)
        {
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
            int i = cmd.ExecuteNonQuery();
            //close connection and return number of rows affected (should be 1)
            connection.Close();
            return i;
        }
    }
}