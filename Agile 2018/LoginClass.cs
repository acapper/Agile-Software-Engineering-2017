using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Agile_2018
{
    public class LoginClass
    {
        public void MyMethod(string StaffID, string Password)
        {
            //open connection
            ConnectionClass.OpenConnection();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM logindetails WHERE staffID ='" + StaffID + "' AND password='" + Password + "'", ConnectionClass.con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable result = new DataTable(); //this is creating a virtual table  
            sda.Fill(result);
            if (result.Rows[0][0].ToString() == "1")        //when login matches
            {
                //...........
            }
            else
            {
                Console.Write("Invalid username or password");
            }
            ConnectionClass.CloseConnection();
        }
    }
}