using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example()
        {
            Example e = new Example();

            int r = e.AddNumbers(1, 2);

            Assert.AreEqual(2, r, "Result is equal to 2");
        }
    }
}
