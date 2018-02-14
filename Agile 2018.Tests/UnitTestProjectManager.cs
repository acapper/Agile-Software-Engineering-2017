using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using MySql.Data.MySqlClient;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestProjectManager
    {
        //Method which tests if the search function works correctly by calling the searchProject() method and comparing
        //its returned results to what the results should be.
        [TestMethod]
        public void searchProject()
        {
            //Create test datatable containing test datarow which has the expected row values when a ProjectID
            //of 1 is entered. This is to be used to compare results to see if search is correct. 
            /*
            DataTable testTable = new DataTable();
            testTable.Clear();
            DataRow expected = testTable.NewRow();
            testTable.Columns.Add("ProjectID");
            testTable.Columns.Add("Title");
            testTable.Columns.Add("DeanSigned");
            testTable.Columns.Add("AssocDeanSigned");
            testTable.Columns.Add("ResearcherSigned");
            testTable.Columns.Add("RISSigned");
            testTable.Columns.Add("CompletionProgress");
            testTable.Columns.Add("StatusCode");
            expected["ProjectID"] = "1";
            expected["Title"] = "Dylan";
            expected["DeanSigned"] = "0";
            expected["AssocDeanSigned"] = "0";
            expected["ResearcherSigned"] = "0";
            expected["RISSigned"] = "0";
            expected["CompletionProgress"] = "0";
            expected["StatusCode"] = "0";
            */
            //testTable.Rows.Add(expected);

            ConnectionClass.OpenConnection();
            ProjectManager pm = new ProjectManager();
            String actual = pm.searchProject(1);
            String expected = "Dylan";
            Assert.AreEqual(expected, actual, false, "There was an error with the search for your project.");



            //Calling method with user input of 1 passed in, which should return the above expected results. 



            //ProjectManager testProject = new ProjectManager();

            //Runs viewProject method passing in 1 as the ProjectID.
            //This should return Dylan, 0, 0, 0, 0, 0, null.
            //testProject.viewProject(1);


            //The test should do 
            //1. take in an example id
            //2. runs the method we created. 
            //3. recieves the combined result. 
            //4. make a fake result which is what we expect the real results to be. 
            //5. eg: Check if this example has the same number of files returned as the fake test. 



        }
    }
}
