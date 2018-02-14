using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class Issue3Test
    {
        [TestMethod]
        public void Test()
        {
            Project newProject = new Project();

            //Name of new project to be added
            string teststring = "ISSUE3TESTRECORD";

            Assert.IsTrue(newProject.CreateProject(teststring));
        }
    }
}
