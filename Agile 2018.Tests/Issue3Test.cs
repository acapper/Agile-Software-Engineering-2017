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

            //
            string teststring = "ISSUE3TESTRECORD";//test name

            Assert.IsTrue(Issue3.SubmitDB(teststring));
        }
    }
}
