using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Agile_2018
{
    public class Issue3
    {
        //make a connection string
        
        
        public string SubmitDB(string name)
        {
            string ConnectString = "Server = silva.computing.dundee.ac.uk;Database=17agileteam5db;Uid=17agileteam5;Pwd=7485.at5.5847";
            Debug.WriteLine("Here");
            MySqlConnection connection = new MySqlConnection(ConnectString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO projects(Title)VALUES('"+name+"')";
                Debug.WriteLine("Entered");
                return name;
            }
            catch(Exception)
            {
                Debug.WriteLine("Exception");
                throw;
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}