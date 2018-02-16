using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;

namespace Agile_2018.Tests
{
    [TestClass]
    public class AutomaticEmailTests
    {
        [TestMethod]
        public void SendConfirmationEmail()
        {
            AutomaticEmail ae = new AutomaticEmail();
            bool r = ae.SendConfirmationEmail("acapper56@gmail.com", "Test", "This is an automated test");
            Assert.IsTrue(r);
        }
    }
}
