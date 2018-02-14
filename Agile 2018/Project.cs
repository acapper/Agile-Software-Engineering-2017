using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Agile_2018
{
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