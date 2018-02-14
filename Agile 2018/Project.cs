using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Agile_2018
{
    /*
     * Method which takes in the project ID the user wants to search for from 
     * the user and returns it from the database. 
     */
    public class Project
    {

        int idToView = 0;
        
        public int viewProject(int input)
        {
            ConnectionClass.OpenConnection();
            idToView = input;

            MySqlCommand viewProjectSQL = new MySqlCommand("Select id from projects where id = '" + idToView + "'", ConnectionClass.con);










            return idToView;
            

        }
        




    }
}