using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace lms.Shared
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string userEmail = Session["LoggedInUserEmail"] as string;
            //string userRole = Session["LoggedInUserRole"] as string;

            if (!string.IsNullOrEmpty(userEmail)) 
                /*&& !string.IsNullOrEmpty(userRole)*/
            {
                lblUserEmail.Text = userEmail;
                //lblUserRole.Text = "Role: " + userRole;
            }
            else
            {
                //Response.Redirect("Login.aspx");
            }
        }
    }
}