using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class Issue9Test
    {
        [TestMethod]
        public void UpdateProjectTest(int projectID, int userID, string title)
        {
            Project newProject = new Project();

            //Name of new project to be added
            string teststring = "AnotherTest";

            Assert.IsTrue(newProject.CreateProject(teststring));
        }
    }
}
