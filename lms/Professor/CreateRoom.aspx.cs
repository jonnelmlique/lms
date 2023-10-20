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
                BindRoomData();
                PopulateSubjectsDropDown();

            }
        }

        protected void BindRoomData()
        {
            string professorEmail = Session["LoggedInUserEmail"] as string;

            if (string.IsNullOrEmpty(professorEmail))
            {
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT room_id, roomname, rooomdescription, schedule, section FROM rooms WHERE professoremail = @professorEmail";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@professorEmail", professorEmail);

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
