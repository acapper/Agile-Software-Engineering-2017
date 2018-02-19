using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class UnitTestLoginDatabase
    {
        [TestMethod]
        public void Login()
        {
            ConnectionClass.OpenConnection();
            LoginClass test = new LoginClass();
            Boolean result = test.MyMethod("20", "33");
            Assert.IsTrue(result);
            ConnectionClass.CloseConnection();
        }
    }
}
