using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_2018
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginControl_Authenticate(object sender, EventArgs e)
        {
            bool authenticated = this.ValidateCredentials(username.Value.ToString(), password.Value.ToString());

            if (authenticated)
            {
                Session["User"] = username;
                FormsAuthentication.RedirectFromLoginPage(username.Value.ToString(), false);
                String returnUrl1 = Request.QueryString["ReturnUrl"];
                Response.Redirect("Pages/AllProjects.aspx");
            }
            Response.Redirect("Login.aspx");
        }

        public bool IsAlphaNumeric(string text)
        {
            return Regex.IsMatch(text, "^[a-zA-Z0-9]+$");
        }

        private bool ValidateCredentials(string userName, string password)
        {
            if (this.IsAlphaNumeric(userName) && userName.Length <= 50 && password.Length <= 50)
            {
                LoginClass lc = new LoginClass();
                return lc.ValidUserAndPass(userName, password);
            }
            else
            {
                return false;
            }
        }
    }
}