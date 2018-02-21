using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestRIS
    {
        [TestMethod]
        public void TestRejectDean()
        {
            RIS testRIS = new RIS();
            int i = testRIS.RISReject(50);
            Assert.AreEqual(1, i);
        }
    }
}