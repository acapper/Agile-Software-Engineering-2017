using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading;

namespace Agile_2018.Tests
{
    [TestClass]
    public class DatabaseFileHandlerTests
    {
        [TestMethod]
        public void UploadFile()
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String fileName = "test.txt";
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String fullPath = System.IO.Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("TEST FILE :)");
                    sw.WriteLine("Maybe it needs lots of text????");
                }
                while (!File.Exists(fullPath))
                {
                    Thread.Sleep(1000);
                }
            }
            int id = 50;

            int i = dfh.UploadFile(id, File.Open(fullPath, FileMode.Open), fileName);

            Assert.AreEqual(1, i);
            File.Delete(fullPath);
        }

        [TestMethod]
        public void DownloadAllFiles()
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String fileName = "test.txt";
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String fullPath = System.IO.Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("TEST FILE :)");
                    sw.WriteLine("Maybe it needs lots of text????");
                }
                while (!File.Exists(fullPath))
                {
                    Thread.Sleep(1000);
                }
            }
            int id = 50;

            int i = dfh.UploadFile(id, File.Open(fullPath, FileMode.Open), fileName);

            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            id = 50;

            List<String> fileList = dfh.DownloadAllFiles(id, path);

            foreach (String f in fileList)
            {
                if (File.Exists(f))
                {
                    Assert.IsTrue(true);
                    File.Delete(f);
                }
            }

            int fileID = 0;

            ConnectionClass.OpenConnection();
            MySqlCommand comm = ConnectionClass.con.CreateCommand();
            comm.CommandText = "SELECT FileID FROM storedfiles sf WHERE sf.FileName = @fileName AND sf.ProjectID = @id";
            comm.Parameters.AddWithValue("@fileName", fileName);
            comm.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader sqlQueryResult = comm.ExecuteReader())
                if (sqlQueryResult != null)
                {
                    sqlQueryResult.Read();
                    fileID = Int32.Parse(sqlQueryResult["FileID"].ToString());
                }
            ConnectionClass.CloseConnection();

            dfh.DeleteFile(fileID);
        }

        [TestMethod]
        public void DownloadFile()
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int id = 21;

            List<String> fileList = dfh.DownloadFile(id, path);

            foreach (String f in fileList)
            {
                if (File.Exists(f))
                {
                    Assert.IsTrue(true);
                    File.Delete(f);
                }
            }
        }

        [TestMethod]
        public void DeleteFile()
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();

            String fileName = "test.txt";
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String fullPath = System.IO.Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                FileStream f = File.Create(fullPath);
                f.Close();
            }
            int id = 50;

            dfh.UploadFile(id, File.Open(fullPath, FileMode.Open), fileName);

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