using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Agile_2018;
using System.Data;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestViewProjectsToSign
    {
        [TestMethod]
        public void TestViewProjectsToSign()
        {
            DataTable table = new DataTable();

            int status = 0;
            ViewProjects testView = new ViewProjects();
            table = testView.ViewProjectsToSign(status);
            int i = table.Rows.Count;
            //MessageBox.Show(i.ToString() + " records returned");
            
            Assert.AreNotEqual(0,i);
        }
    }
}
