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
            String query = "SELECT * FROM 17agileteam5db.projects;";
            ConnectionClass.OpenConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, ConnectionClass.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ConnectionClass.CloseConnection();
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
            Response.Redirect("Project.aspx?Title=" + ((LinkButton)sender).CommandArgument.ToString());
        }
    }
}