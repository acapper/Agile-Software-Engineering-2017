using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace Agile_2018.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        //Declaring instance of ProfileManager to use the getUserInfo to return the current user's info into the thisProfile database. 
        ProfileManager pm = new ProfileManager();
        DataTable thisProfile = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            // On load, the users information will be presented to them on the web form. 
            thisProfile = pm.getUserInfo(Convert.ToInt32(Session["uID"]));
            username.Value = thisProfile.Rows[0].Field<string>(1);
            email.Value = thisProfile.Rows[0].Field<string>(6);
            firstname.Value = thisProfile.Rows[0].Field<string>(3);
            lastname.Value = thisProfile.Rows[0].Field<string>(2);
        }

         protected void Save_Click(object sender, EventArgs e)
        {
            //Check if user is changing top half
            bool changingTop = false; ;
            if ((firstname.Value != thisProfile.Rows[0].Field<string>(3)) || (lastname.Value != thisProfile.Rows[0].Field<string>(2)) || (email.Value != thisProfile.Rows[0].Field<string>(6)))
            {
                changingTop = true;
            }

            //Check if current password is correct for this user.
            if (currentpassword.Value == thisProfile.Rows[0].Field<string>(4))
            {
                //Check if email value is valid
                if (IsValidEmail(email.Value) == true)
                {
                    //update forename, surname, email
                    pm.updateNamesEmail(Convert.ToInt32(Session["uID"]), firstname.Value, lastname.Value, email.Value);
                    if (newpassword.Value == null)
                    {
                        Response.Redirect("/2017-agile/team5/Pages/AllProjects");
                    }
                }
                else
                {
                    //update forename, surname, email (using previous email)
                    pm.updateNamesEmail(Convert.ToInt32(Session["uID"]), firstname.Value, lastname.Value, thisProfile.Rows[0].Field<string>(6));
                    errorLabel.Text = "Email entered is invalid. This must use the following format: 'johnsmyth@mail.com'.";

                }



                //Check if user wants to change password or not.
                if (newpassword.Value != null) //User wants to change password
                {
                    if (newpassword.Value == confirmpassword.Value)
                    {
                        pm.updatePassword(Convert.ToInt32(Session["uID"]), Convert.ToString(newpassword.Value));
                        if (IsValidEmail(email.Value) == true)
                        {
                            Response.Redirect("/2017-agile/team5/Pages/AllProjects");
                        }

                        if(changingTop == false)
                        {
                            Response.Redirect("/2017-agile/team5/Pages/AllProjects");
                        }
                    }
                    else
                    {
                        errorLabel.Text = "New Password and Confirm Password fields must be equal.";
                    }
                }

            }
            //Else if password is not correct
            else
            {
                errorLabel.Text = "Current Password is not correct for this user profile.";

            }
            
        }



        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}