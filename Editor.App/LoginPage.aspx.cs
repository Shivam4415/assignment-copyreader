using Editor.App.Authentication;
using Editor.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Editor.App
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnButtonClick(object sender, EventArgs e)
        {
            Response.Redirect(FormsAuthentication.DefaultUrl, false);
        }

        protected void btnLogin(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Value;
                string password = txtPassword.Value;

                UserProfile user = AuthServices.GetUser(email);

                if (user.Password != password)
                {
                    MessageBox.InnerText = "The email and password you entered did not match our record";
                    MessageBox.Visible = true;
                    return;
                }

                HttpCookie cookie = AuthServices.SignIn(user);
                Response.SetCookie(cookie);

                Response.Redirect(FormsAuthentication.DefaultUrl, false);

            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}