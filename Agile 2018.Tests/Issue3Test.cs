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
            Issue3 Issue3 = new Issue3();
            string teststring = "Testsdbasdhasjk";
            //Issue3.SubmitDB(teststring);
            //We put a record in
            //Check if record is in (Use display project method)
            //If the record title matches our given title
            //Pass
            Assert.IsTrue(teststring == Issue3.SubmitDB(teststring));


            //Assert.AreEqual(2, r, "Result is equal to 2");
        }
    }
}
