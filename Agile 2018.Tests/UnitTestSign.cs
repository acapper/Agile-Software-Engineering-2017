using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;
using MySql.Data.MySqlClient;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestSign
    {
        string researcherID;
        int projectID;
        Project newProject = new Project();

        [TestInitialize]
        public void TestInit()
        {
            MySqlCommand cmd, cmd1, cmd2, cmd3;
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand(); //New Connection object
            cmd1 = ConnectionClass.con.CreateCommand();
            cmd2 = ConnectionClass.con.CreateCommand();
            cmd3 = ConnectionClass.con.CreateCommand();

            cmd.CommandText = "INSERT INTO Logindetails(staffID,Forename,Surname,Pass,Position,Email)VALUES(researcher,a,a,a,researcher,a);SELECT LAST_INSERT_ID();";
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                researcherID = r.GetString("LAST_INSERT_ID()");
            }
            r.Close();
            
            cmd1.CommandText = "INSERT INTO Logindetails(staffID,Forename,Surname,Pass,Position,Email)VALUES(ris,a,a,a,ris,a);";
            cmd1.ExecuteNonQuery();
            cmd2.CommandText = "INSERT INTO Logindetails(staffID,Forename,Surname,Pass,Position,Email)VALUES(assdean,a,a,a,assocdean,a);";
            cmd2.ExecuteNonQuery();
            cmd3.CommandText = "INSERT INTO Logindetails(staffID,Forename,Surname,Pass,Position,Email)VALUES(dean,a,a,a,dean,a);";
            cmd3.ExecuteNonQuery();

            ConnectionClass.CloseConnection();

            string testString = "SigningTest";
            projectID = Int32.Parse(newProject.CreateProject(testString, Int32.Parse(researcherID)));
        }

        [TestMethod]
        public void TestSignResearcher()
        {
            Project testResearcher = new Project();
            int i = testResearcher.ResearcherSign(80, "researcher");
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void TestSignRIS()
        {
            Project testRIS = new Project();
            int i = testRIS.RISSign(80, "ris");
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void TestSignAssocDean()
        {
            Project testAssocDean = new Project();
            int i = testAssocDean.AssocDeanSign(80, "assdean");
            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void TestSignDean()
        {
            Project testDean = new Project();
            int i = testDean.DeanSign(80, "dean");
            Assert.AreEqual(1, i);
        }

        [TestCleanup]
        public void CleanUp()
        {
            MySqlCommand cmd;
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand(); //New Connection object

            cmd.CommandText = "DELETE FROM userprojectpairing WHERE Projects_ProjectID = " + projectID;
            cmd.ExecuteReader();
            ConnectionClass.CloseConnection();
            newProject.DeleteProject(projectID);
            ConnectionClass.OpenConnection();
            cmd = ConnectionClass.con.CreateCommand();
            cmd.CommandText = "DELETE FROM logindetails WHERE staffID = researcher or staffID = ris or staffID = assdean or staffID = dean";
            cmd.ExecuteNonQuery();
            ConnectionClass.CloseConnection();
        }
    }
}