using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace Agile_2018.Tests
{
    [TestClass]
    public class Project
    {
        [TestMethod]
        public void TestMethod()
        {
            ConnectionClass.OpenConnection();
            Project testProject = new Project();

            //get user input (ID of Project to view)
            int idToView = 1;
            //SQL statement which queries the database for this project based on this input
            MySqlCommand viewProjectSQL = new MySqlCommand("Select id from projects where id = '" + idToView + "'", ConnectionClass.con);

            //The one that this statement has returned must have a specific title (title = "Dylan").

            //Return the results from this SQL query
            //Display these results to the user


        }
    }
}
