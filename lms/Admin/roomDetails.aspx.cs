using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace lms.Admin
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["professor_email"] != null)
                {
                    string profemail = Request.QueryString["professor_email"];

                    try
                    {
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();

                            string query = "SELECT room_id, professoremail FROM rooms WHERE professoremail = @professoremail";

                            using (MySqlCommand command = new MySqlCommand(query, con))
                            {
                                command.Parameters.AddWithValue("@professoremail", profemail);

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string professorEmail = Request.QueryString["professor_email"];
                                        Label2.Text = professorEmail;
                                        BindSubjectData(professorEmail);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }

        private void BindSubjectData(string professorEmail)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT subjectname, room_id FROM rooms WHERE professoremail = @professorEmail";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@professorEmail", professorEmail);

                    connection.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable subjectsDataTable = new DataTable();
                        adapter.Fill(subjectsDataTable);

                        roomdetailsGridView.DataSource = subjectsDataTable;
                        roomdetailsGridView.DataBind();
                    }
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("manageRooms.aspx");
        }
    }
}