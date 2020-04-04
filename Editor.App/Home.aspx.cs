using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Editor.App
{
    public partial class Document : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void createNewEditor(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("./editor", false);
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }

    }
}