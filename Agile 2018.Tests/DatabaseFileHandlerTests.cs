using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.IO;

namespace Agile_2018.Tests
{
    [TestClass]
    public class DatabaseFileHandlerTests
    {
        [TestMethod]
        public void UploadFile()
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String path = "C:\\windows-version.txt";
            String fileName = "windows-version.txt";
            int id = 50;

            int i = dfh.UploadFile(id, path, fileName);

            Assert.AreEqual(1, i);
        }

        [TestMethod]
        public void DownloadFile()
        {

        }
    }
}
