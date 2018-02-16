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
            bool r = ae.SendConfirmationEmail("testemail@acapper.tk", "Test", "This is an automated test");
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void GetEmail()
        {
            AutomaticEmail ae = new AutomaticEmail();
            String r = ae.getUserEmail(3);
            Assert.AreEqual("testemail@acapper.tk", r);
        }
    }
}
