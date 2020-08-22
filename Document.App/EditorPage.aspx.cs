using Document.App.App_Start;
using Document.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Document.App
{
    public partial class EditorPage : System.Web.UI.Page
    {
        UserProfile _user = AuthManager.CurrentUser;
        string id = string.Empty;
        FileEditor editor = null;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    id = GetRequestedId();

                    if (_user == null)
                        Response.Redirect(FormsAuthentication.LoginUrl);


                    if (string.IsNullOrWhiteSpace(id))
                        Response.Redirect(FormsAuthentication.DefaultUrl);


                    //editor = EditorServices.GetAll(id);

                }
            }
            catch
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    id = GetRequestedId();
                    editorId.Value = Page.RouteData.Values["editorId"].ToString();
                }
            }
            catch
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

        }

        private string GetRequestedId()
        {
            string editorId = string.Empty;
            try
            {
                int oldId = 0;
                if (Page.RouteData.Values["editorId"] != null)
                {
                    if (int.TryParse(Page.RouteData.Values["editorId"].ToString(), out oldId))
                    {
                        return oldId.ToString();
                    }
                    else
                    {
                        return Page.RouteData.Values["editorId"].ToString();
                    }
                }
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["editorId"]))
                {

                    if (int.TryParse(Request.QueryString["editorId"], out oldId))
                    {
                        return oldId.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }

                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}