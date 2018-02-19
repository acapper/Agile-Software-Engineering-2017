using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_2018
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionClass.OpenConnection();
            MySqlConnection connection = new MySqlConnection(ConnectionClass.ConnectionString);
            MySqlDataAdapter sda = new MySqlDataAdapter("viewProjects", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("?uID", Session["uID"]);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dt.Columns.Add("TimeAgo", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["TimeAgo"] = Agile_2018.Time.TimeAgo(DateTime.Parse(dr["DateCreated"].ToString()));
            }
            Projects.DataSource = dt;
            Projects.DataBind();
        }

        protected void ViewProject_Click(object sender, EventArgs e)
        {
            string[] args = ((LinkButton)sender).CommandArgument.ToString().Split(null);
            Session["ProjectID"] = args[0];
            Session["Title"] = args[1];
            Response.Redirect("ViewProject.aspx");
        }
    }
}