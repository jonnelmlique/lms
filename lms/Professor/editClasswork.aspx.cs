using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["roomid"]))
            {
                if (int.TryParse(Request.QueryString["roomid"], out int roomId))
                {

                }
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Professor/Classwork.aspx");
        }
    }
}