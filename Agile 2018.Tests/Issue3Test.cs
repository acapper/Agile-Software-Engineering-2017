using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class Issue3Test
    {
        [TestMethod]
        public void CreateProjectTest()
        {
            Project newProject = new Project();

            //Name of new project to be added
            string teststring = "AnotherTest"; //random teststring
            int userID = 15; //just a random userID

            Assert.IsNotNull(newProject.CreateProject(teststring,userID));
        }
    }
}
