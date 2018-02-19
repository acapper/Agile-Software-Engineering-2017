using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestDean
    {
        [TestMethod]
        public void TestRejectDean()
        {
            Dean testDean = new Dean();
            int i = testDean.Reject(50);
            Assert.AreEqual(1, i);
        }
    }
}
