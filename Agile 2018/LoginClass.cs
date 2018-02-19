using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Agile_2018
{
    public class LoginClass
    {
        public Boolean MyMethod(string StaffID, string pwd)
        {
            //assign stored procedure
            string storedProc = "checkLogin;";
            //open connection
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            connection.Open();
            //define stored procedure
            MySqlCommand cmd = new MySqlCommand(storedProc, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //assign parameters
            cmd.Parameters.Add(new MySqlParameter("?pID", StaffID));
            cmd.Parameters.Add(new MySqlParameter("?sID", pwd));
            // in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. 
            DataTable dt = new DataTable(); //this is creating a virtual table  
            dt.Load(cmd.ExecuteReader());
                //Fill(result);
            if (dt.Rows[0][0].ToString() == "1")        //when login matches
            {
                //...........
                Console.Write("found!");
                ConnectionClass.CloseConnection();
                return true;                
            }
            else
            {
                Console.Write("Invalid username or password");
                ConnectionClass.CloseConnection();
                return false;
            }
            
            
        }
    }
}