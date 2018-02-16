using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestViewResearcherProjects
    {
        [TestMethod]
        public void TestViewResearcherProjects()
        {
            string staffID = "sweeb";
            ViewProjects testView = new ViewProjects();
            int i = testView.ViewResearcherProjects(staffID);
            Assert.IsNotNull(i);
        }
    }
}
