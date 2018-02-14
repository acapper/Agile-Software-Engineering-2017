using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Agile_2018
{
    /*
     * Method which takes in the project ID the user wants to search for from 
     * the user and returns it from the database. 
     */
    public class ProjectManager
    {
        //object [] returnedRow = new object[9];
        public DataRow returnedRow;
        public DataTable dt = new DataTable();
        public int ProjectID;

        public String searchProject(int input)
        {
            String Title;
            ConnectionClass.OpenConnection();
            int userInput = input;
            MySqlCommand cmd = ConnectionClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM projects WHERE ProjectID = '" + userInput + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            ProjectID = Convert.ToInt32(dt.Rows[0]["ProjectID"]);
            Title = Convert.ToString(dt.Rows[0]["Title"]);
            return Title;
            //returnedRow = dt.Select("ProjectID = '" + userInput + "'");
        }

            public void viewProject(int input)
        {
            ConnectionClass.OpenConnection();
            int userInput = input;
            MySqlCommand cmd = ConnectionClass.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM projects WHERE ProjectID = '" + userInput + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            /*
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;

           // DataTable dt;
           // DataRow dr;

            int idToView = input;

            //adp.SelectCommand = new MySqlCommand("Select * from project where ProjectID = '" + idToView + "'", ConnectionClass.con);

            //adp.Fill(ds, "result");
            //dt = ds.Tables["result"];
           // dr = dt.Rows[0];

            //dg.DataSource = ds.Tables["results"];


            string[] results = new string[8];

            MySqlCommand viewProjectSQL = new MySqlCommand("Select ProjectID from projects where ProjectID = '" + idToView + "'", ConnectionClass.con);

            MySqlDataReader reader = viewProjectSQL.ExecuteReader();
                while(reader.Read())
                    {
                        results[0] = (string)reader[0];
                        results[1] = (string)reader[1];
                        results[2] = (string)reader[2];
                        results[3] = (string)reader[3];
                        results[4] = (string)reader[4];
                        results[5] = (string)reader[5];
                        results[6] = (string)reader[6];
                        results[7] = (string)reader[7];
                    }

            reader.Close();

            for(int i = 0; i < 7; i++)
            {
                Console.WriteLine(results[i]);
            }

            MySqlCommand viewProjectFilesSQL = new MySqlCommand("Select ProjectID from storedfiles where ProjectID = '" + idToView + "'", ConnectionClass.con);




            return idToView;




            //1. take in project id
            //2. query projects in database for the row with this id
            //3. query stored files for all files with this id in the database. 
            //4. you should have 2 arrays at this point. one with the first query and one with the second query, 
            //5. Combine these in some way, such as with a json
            //6. return the combined results from the json file. 
            */
        }





    }
}