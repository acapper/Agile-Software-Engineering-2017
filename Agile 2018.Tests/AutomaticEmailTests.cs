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
            ae.SendConfirmationEmail();
            Assert.IsTrue(true);
        }
    }
}
