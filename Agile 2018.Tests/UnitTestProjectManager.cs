using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestProjectManager
    {
        [TestMethod]
        public void TestMethod()
        {
            
            ProjectManager testProject = new ProjectManager();

            testProject.viewProject(1);

            //get user input (ID of Project to view)



            //The test should do 
            //1. take in an example id
            //2. runs the method we created. 
            //3. recieves the combined result. 
            //4. make a fake result which is what we expect the real results to be. 
            //5. eg: Check if this example has the same number of files returned as the fake test. 



        }
    }
}
