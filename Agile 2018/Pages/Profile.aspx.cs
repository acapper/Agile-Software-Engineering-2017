using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_2018.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            username.Value = "THIS IS MY TEXT";
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string Username = username.Value.ToString();
            string userID = Session["uID"].ToString();
            //exec query
        }
    }
}