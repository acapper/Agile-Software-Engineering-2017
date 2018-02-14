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
        public int UploadFile(int id, string path, string fileName)
        {
            byte[] file;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }

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

        public byte[] DownloadFile(int id, string path)
        {
            /*using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
            using (var sqlQuery = new SqlCommand(@"SELECT [RaportPlik] FROM [dbo].[Raporty] WHERE [RaportID] = @varID", varConnection))
            {
                sqlQuery.Parameters.AddWithValue("@varID", varID);
                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null)
                    {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        using (var fs = new FileStream(varPathToNewLocation, FileMode.Create, FileAccess.Write))
                            fs.Write(blob, 0, blob.Length);
                    }
            }*/

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