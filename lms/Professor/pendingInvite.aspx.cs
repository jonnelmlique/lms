using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InvitationData();


        }
        private void InvitationData(string searchTerm = "")
        {
            string loggedInProfessorEmail = Session["LoggedInUserEmail"] as string;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT invitationid, studentid, teacherid, teacheremail, studentemail, subjectname, status FROM invitation WHERE teacheremail = @loggedInProfessorEmail AND status = 'Pending' ";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " AND (studentid LIKE @searchTerm OR teacheremail LIKE @searchTerm OR studentemail LIKE @searchTerm OR subjectname LIKE @searchTerm)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@loggedInProfessorEmail", loggedInProfessorEmail);

                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            pendinggrv.DataSource = dataTable;
                            pendinggrv.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                }
            }
        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtsearch.Text;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query;
                string loggedInProfessorEmail = Session["LoggedInUserEmail"] as string;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    query = "SELECT invitationid, studentid, teacherid, teacheremail, studentemail, subjectname, status FROM invitation WHERE teacheremail = @loggedInProfessorEmail AND status = 'Pending'";
                }
                else
                {
                    query = "SELECT invitationid, studentid, teacherid, teacheremail, studentemail, subjectname, status FROM invitation WHERE teacheremail = @loggedInProfessorEmail AND status = 'Pending' AND (studentid LIKE @searchTerm OR teacheremail LIKE @searchTerm OR studentemail LIKE @searchTerm OR subjectname LIKE @searchTerm OR status LIKE @searchTerm)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@loggedInProfessorEmail", loggedInProfessorEmail);

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        pendinggrv.DataSource = dataTable;
                        pendinggrv.DataBind();
                    }
                }
            }
        }
    }
}