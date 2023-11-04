using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {


                    BindRoomData();
                    //PopulateSubjectsDropDown();

                }
                catch (Exception ex)
                {
                    //lblMessage.Text = "An error occurred while processing your request. Please try again later.";
                }
            }
        }
        protected void BindRoomData()
        {
            string teacheremail = Session["LoggedInUserEmail"] as string;

            if (string.IsNullOrEmpty(teacheremail))
            {
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT roomid, subjectname, section FROM rooms WHERE teacheremail = @teacheremail";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@teacheremail", teacheremail);

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        roomdetailsGridView.DataSource = dt;
                        roomdetailsGridView.DataBind();
                    }
                }
            }
        }
        //protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        //{
        //    int index = Int32.Parse(e.Item.Value);
        //    MultiView1.ActiveViewIndex = index;
        //}
    }
}