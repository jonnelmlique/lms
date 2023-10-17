using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Admin
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                String query = "SELECT professor_id, firstname, lastname, email FROM professor";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string professor_id = reader["professor_id"].ToString();
                            string firstname = reader["firstname"].ToString();
                            string lastname = reader["lastname"].ToString();
                            string email = reader["email"].ToString();

                            string fullName = $"{firstname} {lastname}";

                            trprofessor.Text += $"<tr><td>{professor_id}</td><td>{fullName}</td><td>{email}</td><td><a class='send-message-link' data-email='{email}' href='#'>Send Message</a></td></tr>";
                        }
                    }
                }
            }
        }
    }
}