using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace lms.Admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ProfID"] != null)
                {
                    int professorID = Convert.ToInt32(Request.QueryString["ProfID"]);

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT professor_id, firstname, Email FROM professor WHERE professor_id = @ProfID";

                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@ProfID", professorID);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    //string name = reader["Name"].ToString();
                                    string email = reader["Email"].ToString();

                                    emailtxt.Text = email;
                                    //emailLabel.Text = email;
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
                else if (Request.QueryString["studentid"] != null)
                {
                    int studentID = Convert.ToInt32(Request.QueryString["studentid"]);

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT student_id, firstname, Email FROM student WHERE student_id = @StudentID";

                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@StudentID", studentID);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string studentFirstName = reader["firstname"].ToString();
                                    string studentEmail = reader["Email"].ToString();

                                    emailtxt.Text = studentEmail;
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
                else
                {

                }
            }
        }
    }
}
