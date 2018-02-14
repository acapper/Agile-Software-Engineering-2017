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
            MySqlCommand viewProjectSQL = new MySqlCommand("Select ProjectID from projects where ProjectID = '" + idToView + "'", ConnectionClass.con);

            //The one that this statement has returned must have a specific title (title = "Dylan").

            int UserExist = 0;
            UserExist = (int)viewProjectSQL.ExecuteScalar();
            Console.WriteLine(UserExist);

            ConnectionClass.con.Close();


            //Return the results from this SQL query
            //Display these results to the user


            //1. take in project id
            //2. query projects in database for the row with this id
            //3. query stored files for all files with this id in the database. 
            //4. you shoul dhave 2 arrays at this point. one with the first query and one with the second query, 
            //5. Combine these in some way, such as with a json
            //6. return the combined results from the json file. 
            

            //The test should do 
            //1. take in an example id
            //2. runs the method we created. 
            //3. recieves the combined result. 
            //4. make a fake result which is what we expect the real results to be. 
            //5. eg: Check if this example has the same number of files returned as the fake test. 



        }
    }
}
