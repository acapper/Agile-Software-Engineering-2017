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
            string result = test.ValidateLoginDetails("11", "11");
            Assert.AreEqual("1",result);
            ConnectionClass.CloseConnection();
        }
    }
}
