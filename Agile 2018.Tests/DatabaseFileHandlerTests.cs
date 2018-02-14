using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

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
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String path = "U:\\Desktop\\windows-version-copy.txt";
            int id = 50;

            byte[] b = dfh.DownloadFile(id, path);
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void DeleteFile()
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String path = "C:\\windows-version.txt";
            String fileName = "windows-version.txt";
            int id = 50;

            dfh.UploadFile(id, path, fileName);

            int fileID = 0;

            ConnectionClass.OpenConnection();
            MySqlCommand comm = ConnectionClass.con.CreateCommand();
            comm.CommandText = "SELECT FileID FROM storedfiles sf WHERE sf.FileName = @fileName AND sf.ProjectID = @id";
            comm.Parameters.AddWithValue("@fileName", fileName);
            comm.Parameters.AddWithValue("@id", id);
            using(MySqlDataReader sqlQueryResult = comm.ExecuteReader())
                if (sqlQueryResult != null)
            {
                sqlQueryResult.Read();
                    fileID = Int32.Parse(sqlQueryResult["FileID"].ToString());
            }
            ConnectionClass.CloseConnection();

            int i = dfh.DeleteFile(fileID);
            Assert.AreEqual(1, i);
        }
    }
}
