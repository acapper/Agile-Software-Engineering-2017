using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_2018
{
    public partial class Project1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = Session["Title"].ToString();
            ProjectManager pm = new ProjectManager();
            DataTable pn = pm.viewProjectInfo(Int32.Parse(Session["projectID"].ToString()));
            DataTable pf = pm.viewProjectFiles(Int32.Parse(Session["projectID"].ToString()));

            Files.DataSource = pf;
            Files.DataBind();

            ProjectName.DataSource = pn;
            ProjectName.DataBind();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            DatabaseFileHandler dfh = new DatabaseFileHandler();
            dfh.SelectFile();
        }
    }
}