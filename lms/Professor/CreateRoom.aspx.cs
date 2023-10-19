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

                string query = "SELECT room_id, roomname, rooomdescription, schedule FROM rooms WHERE professoremail = @professorEmail";

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
    }
}