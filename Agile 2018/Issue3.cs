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
        
        
        public bool SubmitDB(string title,int researcherSign, int status)
        {
           
            MySqlCommand cmd;
            ConnectionClass.OpenConnection();
            try
            {
                cmd = ConnectionClass.con.CreateCommand();
                cmd.CommandText = "INSERT INTO projects(Title, ResearcherSigned)VALUES(@title,@researcherSign)"; 
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@researcherSign", researcherSign);
                Debug.WriteLine("Entered1");
               // cmd.Parameters.AddWithValue("@status", status); //Fails test, possible issue: foreign key constraints.
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Entered");
                ConnectionClass.CloseConnection();
                return true;
            }
            catch(Exception)
            {
                Debug.WriteLine("Exception");
                ConnectionClass.CloseConnection();
                return false;
                throw;
            }
            finally
            {
               /* if(connection.State == System.Data.ConnectionState.Open)
                {

                    ConnectionClass.closeConnection();
                    
                }*/
            }
        }
    }
}