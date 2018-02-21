using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Agile_2018;
using System.Data;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestViewResearcherProjects
    {
        [TestMethod]
        public void TestViewResearcherProjects()
        {
            DataTable table = new DataTable();

            //string staffID = "smacgregor";
            ViewProjects testView = new ViewProjects();
            table = testView.ViewResearcherProjects(38);
            int i = table.Rows.Count;
            
            Assert.AreNotEqual(0,i);
        }
    }
}
