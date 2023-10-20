using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class professorMasterPage : System.Web.UI.MasterPage
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
                        else if (userType == "admin")
                        {
                            Response.Redirect("~/Admin/DashBoard.aspx");
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