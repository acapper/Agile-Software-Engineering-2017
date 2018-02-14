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




            //1. take in project id
            //2. query projects in database for the row with this id
            //3. query stored files for all files with this id in the database. 
            //4. you shoul dhave 2 arrays at this point. one with the first query and one with the second query, 
            //5. Combine these in some way, such as with a json
            //6. return the combined results from the json file. 

        }





    }
}