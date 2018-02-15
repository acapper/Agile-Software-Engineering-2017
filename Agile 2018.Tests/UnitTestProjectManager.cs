using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;
using System.Data;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestProjectManager
    {
        //Method which tests if the search function works correctly by calling the searchProject() method and comparing
        //its returned results to what the results should be.
        [TestMethod]
        public void viewProject()
        {
            
            ConnectionClass.OpenConnection();
            ProjectManager pm = new ProjectManager();
            //Calling method with user input of 1 passed in, which should return the above expected results. 

            //Runs viewProject method passing in 1 as the ProjectID.
      
          
            String whatsExpected = "1 Dylan 0 11 0 0 0";
            DataTable dt = pm.viewProject(1);
            string rowRead = "";

            foreach (DataRow dr in dt.Rows)
            {
                rowRead = dr["ProjectID"].ToString() + " " + dr["Title"].ToString() + " " + dr["AssocDeanSigned"].ToString() + " " + dr["ResearcherSigned"].ToString() + " " + dr["RISSigned"].ToString() + " " + dr["CompletionProgress"].ToString() + " " + dr["StatusCode"].ToString();
                Console.WriteLine(rowRead);
            }
            
            Assert.AreEqual(whatsExpected, rowRead, false, "There was an error with the view for your project.");

            //The test should do 
            //1. take in an example id
            //2. runs the method we created. 
            //3. recieves the combined result. 
            //4. make a fake result which is what we expect the real results to be. 
            //5. eg: Check if this example has the same number of files returned as the fake test. 

            
        }
    }
}
