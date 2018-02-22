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
            try
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
            catch (Exception) { Response.Redirect("~/Login.aspx"); }
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
            Project p = new Project();
            int id = Int32.Parse(Session["pID"].ToString());
            int projectID = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
            switch (id)
            {
                case 0:
                    p.ResearcherSign(projectID, Session["uID"].ToString());
                    Response.Redirect(Request.RawUrl);
                    break;
                case 1:
                    p.RISSign(projectID, Session["uID"].ToString());
                    Response.Redirect("/2017-agile/team5/Pages/AllProjects");
                    break;
                case 2:
                    p.AssocDeanSign(projectID, Session["uID"].ToString());
                    Response.Redirect("/2017-agile/team5/Pages/AllProjects");
                    break;
                case 3:
                    p.DeanSign(projectID, Session["uID"].ToString());
                    Response.Redirect("/2017-agile/team5/Pages/AllProjects");
                    break;
                default:
                    break;
            }
        }

        protected void DeleteProject_Click(object sender, EventArgs e)
        {
            int projectID = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
            Project p = new Project();
            p.DeleteProject(projectID);
            Response.Redirect("/2017-agile/team5/Pages/AllProjects#");
        }

        protected void DeleteFile_Click(object sender, EventArgs e)
        {
            int fileID = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
            DatabaseFileHandler dfh = new DatabaseFileHandler();
            dfh.DeleteFile(fileID);
            Response.Redirect(Request.RawUrl);
        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            Project p = new Project();
            int id = Int32.Parse(Session["pID"].ToString());
            int projectID = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
            switch (id)
            {
                case 0:
                    p.ResearcherReject(projectID);
                    break;
                case 1:
                    p.RISReject(projectID);
                    break;
                case 2:
                    p.AssocDeanReject(projectID);
                    break;
                case 3:
                    p.DeanReject(projectID);
                    break;
                default:
                    break;
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}