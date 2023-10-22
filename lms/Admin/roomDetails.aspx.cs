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
                if (Request.QueryString["room_id"] != null)
                {
                    int roomID = Convert.ToInt32(Request.QueryString["room_id"]);
                    try
                    {
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();

                            string query = "SELECT room_id, professoremail FROM rooms WHERE room_id = @room_id";

                            using (MySqlCommand command = new MySqlCommand(query, con))
                            {
                                command.Parameters.AddWithValue("@room_id", roomID);

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string email = reader["professoremail"].ToString();
                                        Label2.Text = email;
                                        BindSubjectData(email); // Bind subject data based on the professor's email
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                    }
                }
            }
        }

        private void BindSubjectData(string professorEmail)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT subjectname FROM rooms WHERE professoremail = @professorEmail";

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
    }
}