using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_2018
{
    public partial class ViewProject : Page
    {
        private int numOfFiles;
        public int NumOfFiles { get { return numOfFiles; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = Session["Title"].ToString();
            ProjectManager pm = new ProjectManager();
            DataTable pn = pm.viewProjectInfo(Int32.Parse(Session["projectID"].ToString()));
            DataTable pf = pm.viewProjectFiles(Int32.Parse(Session["projectID"].ToString()));

            Files.DataSource = pf;
            Files.DataBind();

            numOfFiles = pf.Rows.Count;

            ProjectName.DataSource = pn;
            ProjectName.DataBind();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    String fileName = Path.GetFileName(file.FileName);
                    DatabaseFileHandler dfh = new DatabaseFileHandler();
                    dfh.UploadFile(Int32.Parse(Session["projectID"].ToString()), file.InputStream, fileName);
                    Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            string[] args = ((LinkButton)sender).CommandArgument.ToString().Split('|');
            DatabaseFileHandler dfh = new DatabaseFileHandler();
            byte[] blob = dfh.GetFile(Int32.Parse(args[0]));
            try
            {
                if (args[1].EndsWith(".xlxs") || args[1].EndsWith(".xls"))
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                else
                {
                    Response.ContentType = "application/octet-stream";
                }
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + args[1] + "\"");
                Response.OutputStream.Write(blob, 0, blob.Length);
                Response.Flush();
            }
            catch (Exception){}
        }

        protected void Sign_Click(object sender, EventArgs e)
        {
            ProjectManager pm = new ProjectManager();
            int id = Int32.Parse(Session["pID"].ToString());
            int projectID = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
            switch (id)
            {
                case 0:
                    pm.researcherConfirmation(projectID, Session["uID"].ToString());
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}