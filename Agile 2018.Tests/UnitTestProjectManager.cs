using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;
using System.Data;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestProjectManager
    {

        //The test should do 
        //1. take in an example id
        //2. runs the method we created. 
        //3. recieves the combined result. 
        //4. make a fake result which is what we expect the real results to be. 
        //5. eg: Check if this example has the same number of files returned as the fake test.


        //Method which tests if the search function works correctly by calling the searchProject() method and comparing
        //its returned results to what the results should be.
        [TestMethod]
        public void viewProjectInfo()
        {
            ConnectionClass.OpenConnection();
            ProjectManager pm = new ProjectManager();

            //Expected
            String whatsExpected = "3 DontTouch 0 0 11 0 0 5";

            //Actual
            DataTable dt = pm.viewProjectInfo(3);

            //Making actual result comparable by converting into string format
            string rowRead = "";
            foreach (DataRow dr in dt.Rows)
            {
                rowRead = dr["ProjectID"].ToString() + " " + dr["Title"].ToString() + " " + dr["AssocDeanSigned"].ToString() + " " + dr["AssocDeanSigned"].ToString() + " " + dr["ResearcherSigned"].ToString() + " " + dr["RISSigned"].ToString() + " " + dr["CompletionProgress"].ToString() + " " + dr["StatusCode"].ToString();
                Console.WriteLine(rowRead);
            }

            //Testing if strings are equal
            Assert.AreEqual(whatsExpected, rowRead, false, "There was an error with the view for your project.");
        }

        //Method which tests if the correct number of storedfiles results are returned for a specific ProjectID by calling viewProjectInfo() and passing in 51 which 
        //should return 1 file record. 
        [TestMethod]
        public void viewProjectFiles()
        {
            ProjectManager pm = new ProjectManager();

            //Expected number of files returned
            int expected = 1;

            //Actual number of files returned
            DataTable dt = pm.viewProjectFiles(1);
            int actual = dt.Rows.Count;

            Assert.AreEqual(expected, actual);
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
