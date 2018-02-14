using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using System.Linq;
using System.Web;

namespace Agile_2018
{
    //Class to control connecting and disconnecting to and from database
    //Static class so methods can be called from anywhere
    public static class ConnectionClass
    {
        //variable holds database information
        static string ConnectionString = "Server=silva.computing.dundee.ac.uk;Database=17agileteam5db;Uid=17agileteam5;Pwd=7485.at5.5847;";
        //variable holds the SQL connection
        static public mySqlConnection con;

        //function that connects to the database
        public static void OpenConnection()
        {
            con = new mySqlConnection(ConnectionString);
            con.Open();
        }

        //function that disconnects to the database
        public static void CloseConnection()
        {
            con.Close();
        }
    }
}