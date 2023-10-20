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

            if (!IsPostBack)
            {
                if (Session["LoggedInUserEmail"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    string userType = Session["LoggedInUserusertype"] as string;

                    if (userType == "student")
                    {
                        Response.Redirect("~/Student/DashBoard.aspx");
                    }
                    else if (userType == "professor")
                    {
                        Response.Redirect("~/Professor/DashBoard.aspx");
                    }
                    else
                    {
                        string userEmail = Session["LoggedInUserEmail"] as string;

                        if (!string.IsNullOrEmpty(userEmail))
                        {
                            lblUserEmail.Text = userEmail;
                        }
                    }
                }
            }
        }
    }
}