using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Agile_2018
{
    public class DatabaseFileHandler
    {
        /// <summary>
        /// Uploads the file at the path location to the database. 
        /// </summary>
        /// <param name="id">Project ID that the file belongs to</param>
        /// <param name="path">Path to the file that you are uploading</param>
        /// <param name="fileName">File name to display to the user</param>
        /// <returns>Number of rows effected</returns>
        public int UploadFile(int id, string path, string fileName)
        {
            //Convert file to bytes
            byte[] file;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }

            //Insert bytes into the storedfiles table
            ConnectionClass.OpenConnection();
            MySqlCommand comm = ConnectionClass.con.CreateCommand();
            comm.CommandText = "INSERT INTO storedfiles(ProjectID, FileName, FileData) VALUES(@id, @fileName, @fileData)";
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@fileName", fileName);
            comm.Parameters.Add("@fileData", MySqlDbType.LongBlob, file.Length).Value = file;
            int i = comm.ExecuteNonQuery();
            ConnectionClass.CloseConnection();

            return i;
        }

        /// <summary>
        /// Takes a file primary key (fileID) and deletes all rows from storedfiles with that key.
        /// </summary>
        /// <param name="fileID">Database primary key that you want to delete</param>
        /// <returns>Number of rows effected</returns>
        public int DeleteFile(int fileID)
        {
            //Deletes all rows with primary key = fileID
            ConnectionClass.OpenConnection();
            MySqlCommand comm = ConnectionClass.con.CreateCommand();
            comm.CommandText = "DELETE FROM storedfiles WHERE FileID = @id";
            comm.Parameters.AddWithValue("@id", fileID);
            int i = comm.ExecuteNonQuery();
            ConnectionClass.CloseConnection();

            return i;
        }

        public byte[] DownloadFile(int id, string path)
        {
            byte[] blob = null;

            ConnectionClass.OpenConnection();
            MySqlCommand comm = ConnectionClass.con.CreateCommand();
            comm.CommandText = "SELECT FileData FROM storedfiles sf WHERE sf.ProjectID = @id";
            comm.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader sqlQueryResult = comm.ExecuteReader())
                if (sqlQueryResult != null)
                {
                    sqlQueryResult.Read();
                    blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                    sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                        fs.Write(blob, 0, blob.Length);
                }
            ConnectionClass.CloseConnection();
            
            return blob;
        }

        /*Stream myStream = null;
        DatabaseFileHandler dfh = new DatabaseFileHandler();

        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        openFileDialog1.InitialDirectory = "C:";
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;

        String path = "";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        path = openFileDialog1.FileName;
                        Console.WriteLine(path);
                        //dfh.UploadFile(path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }*/
    }
}