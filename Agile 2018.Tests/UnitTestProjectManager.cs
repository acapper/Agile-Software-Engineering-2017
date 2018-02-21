using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Threading;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestProjectManager
    {
        //Method which tests if the search function works correctly by calling the searchProject() method and comparing
        //its returned results to what the results should be.
        [TestMethod]
        public void viewProjectInfo()
        {
            ConnectionClass.OpenConnection();

            //Add the expected record to the database, which will have a title of "viewProjectInfoTest" and a user ID of "1".
            ProjectManager pm = new ProjectManager();
            Project expectedProject = new Project();
            int expectedProjectID = Convert.ToInt32(expectedProject.CreateProject("viewProjectInfoTest", 1));   
            
            //Actual
            DataTable dt = pm.viewProjectInfo(expectedProjectID);

            //Making actual result comparable by converting into string format
            string rowRead = "";
            foreach (DataRow dr in dt.Rows)
            {
                rowRead = dr["ProjectID"].ToString();
                Console.WriteLine(rowRead);
            }
            
            //Testing if strings are equal
            Assert.AreEqual(expectedProjectID.ToString(), rowRead, false, "There was an error with the view for your project.");

            //REMEMBER TO DELETE THE RECORDS - get Pete's delete project method
        }


        //Method which tests if the correct number of storedfiles results are returned for a specific ProjectID by calling viewProjectInfo() and passing in 51 which 
        //should return 1 file record. 
        [TestMethod]
        public void viewProjectFiles()
        {
            ConnectionClass.OpenConnection();

            //Add the expected record to the database, which will have a title of "test" and a user ID of "1".
            ProjectManager pm = new ProjectManager();
            Project expectedProject = new Project();
            int expectedProjectID = Convert.ToInt32(expectedProject.CreateProject("viewProjectFileTest", 1));


            //Create and upload test file
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String fileName = "viewProjectFilesTest.txt";
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String fullPath = System.IO.Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("TEST FILE :3");
                    sw.WriteLine("Maybe it needs lots of text????");
                }
                while (!File.Exists(fullPath))
                {
                    Thread.Sleep(1000);
                }
            }
            int id = expectedProjectID;

            int expectedRowCount = dfh.UploadFile(id, File.Open(fullPath, FileMode.Open), fileName);

            //Actual
            DataTable dt = pm.viewProjectFiles(expectedProjectID);
            int actualRowCount = dt.Rows.Count;

            Assert.AreEqual(expectedRowCount, actualRowCount);
            File.Delete(fullPath);
            DatabaseFileHandler dbfh = new DatabaseFileHandler();
            ConnectionClass.OpenConnection();
            MySqlCommand comm = ConnectionClass.con.CreateCommand();
            comm.CommandText = "SELECT FileID FROM storedfiles sf WHERE sf.FileName = @fileName AND sf.ProjectID = @id";
            comm.Parameters.AddWithValue("@fileName", fileName);
            comm.Parameters.AddWithValue("@id", id);

            int fileID = 0;

            using (MySqlDataReader sqlQueryResult = comm.ExecuteReader())
                if (sqlQueryResult != null)
                {
                    sqlQueryResult.Read();
                    fileID = Int32.Parse(sqlQueryResult["FileID"].ToString());
                }
            ConnectionClass.CloseConnection();

            int i = dfh.DeleteFile(fileID);




            //REMEMBER TO DELETE THE PROJECT RECORDS with pete's method


        }

        //Method wich tests whether the correct number of records are returned which are unconfirmed by a researcher. There should be 31 records with a status code of 0
        //as of 16/02/2018 but this will change. 

        [TestMethod]
        public void getResearcherUnconfirmedProjects()
        {
            //should return 31 values
            ConnectionClass.OpenConnection();
            ProjectManager pm = new ProjectManager();

            //Expected number of rows returned (THIS IS CONSTANTLY CHANGING SO EXPECT TEST TO FAIL)
            int expected = 67;

            //Actual number of rows returned
            DataTable dt = pm.getResearcherUnconfirmedProjects();
            int actual = dt.Rows.Count;
            Console.WriteLine(actual);

            //Testing if variables are equal
            Assert.AreEqual(expected, actual);
        }

        /*
        //Method wich tests whether the correct number of records are returned which are unconfirmed by a researcher. There should be 31 records with a status code of 0
        //as of 16/02/2018 but this will change. 
        [TestMethod]
        public void researcherConfirmation()
        {
            //get a row with statuscode and researchersigned both at 0
            //get statuscode and ResearcherSigned values of a project before running this method in a string
            //compare this to what they should be before in another string
            //run method on this projectID record
            //get new values of these two fields
            //compare these to old values. 



            ConnectionClass.OpenConnection();
            ProjectManager pm = new ProjectManager();

            //this is a datatable of all the rows which are unconfirmed
            DataTable dt = pm.getResearcherUnconfirmedProjects();
            //get projectID for the first row of this table
            String rowRead = "";

            foreach (DataRow dr in dt.Rows)
            {
                rowRead = dr["ProjectID"].ToString();
                String projectID = rowRead.
                Console.WriteLine(rowRead);
            }





            //Expected before method is run
            String oldExpected = "1 Dylan 0 11 0 0 0";


        }
        */
    }
}  
