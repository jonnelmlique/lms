using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace lms.Professor
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {


                    BindRoomData();
                    PopulateSubjectsDropDown();

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred while processing your request. Please try again later.";
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

                string query = "SELECT roomid, subjectname, description, schedule, section FROM rooms WHERE teacheremail = @teacheremail";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@teacheremail", teacheremail);

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        roomRepeater.DataSource = dt;
                        roomRepeater.DataBind();
                    }
                }
            }
        }
        private void PopulateSubjectsDropDown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DISTINCT subjectname FROM rooms";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["subjectname"].ToString();
                            DropDownList1.Items.Add(new ListItem(subjectName, subjectName));
                        }
                    }
                }
            }
        }
    }
}
