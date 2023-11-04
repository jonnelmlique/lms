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
    public partial class StudentInvite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Request.QueryString["roomid"] != null)
                {
                    string roomid = Request.QueryString["roomid"];
                    try
                    {
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();
                            string query = "SELECT subjectname FROM rooms WHERE roomid = @roomid";

                            using (MySqlCommand command = new MySqlCommand(query, con))
                            {
                                command.Parameters.AddWithValue("@roomid", roomid);

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string subjectname = reader["subjectname"].ToString();
                                        Label1.Text = subjectname;
                                        BindStudentData(roomid);
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
        protected void BindStudentData(string roomid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string loggedinTeacherEmail = Session["LoggedInUserEmail"] as string;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT s.studentid, s.email AS StudentEmail, t.teacherid, t.email AS TeacherEmail, r.subjectname " +
                               "FROM student_Info s " +
                               "INNER JOIN teacher_info t " +
                               "INNER JOIN rooms r " +
                               "WHERE t.email = @TeacherEmail AND r.roomid = @roomidParam";



                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TeacherEmail", loggedinTeacherEmail);
                    cmd.Parameters.AddWithValue("@roomidParam", roomid);

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        roomlist.DataSource = dt;
                        roomlist.DataBind();
                    }
                }
            }
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            DropDownList ddl = (DropDownList)gvr.FindControl("ddlProcess");
            HiddenField hf = (HiddenField)gvr.FindControl("hfTnIdPkId");
            int tnidpk = int.Parse(hf.Value);
            string status = ddl.SelectedValue;


            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            GridViewRow selectedRow = (GridViewRow)((Button)sender).NamingContainer;

            string studentid = selectedRow.Cells[0].Text;
            string studentemail = selectedRow.Cells[1].Text;
            string teacherid = selectedRow.Cells[2].Text;
            string teacheremail = selectedRow.Cells[3].Text;
            string subjectname = selectedRow.Cells[4].Text;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();


                string checkQuery = "SELECT COUNT(*) FROM invitation WHERE studentid = @studentid AND teacherid = @teacherid AND subjectname = @subjectname";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@studentid", studentid);
                    checkCmd.Parameters.AddWithValue("@teacherid", teacherid);
                    checkCmd.Parameters.AddWithValue("@subjectname", subjectname);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0) 
                    {

                        string query = "INSERT INTO invitation (studentid, teacherid, teacheremail, studentemail, subjectname, status) " +
                                            "VALUES (@studentid, @teacherid, @teacheremail, @studentemail, @subjectname, 'Invited') ";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@studentid", studentid);
                            cmd.Parameters.AddWithValue("@teacherid", teacherid);
                            cmd.Parameters.AddWithValue("@teacheremail", teacheremail);
                            cmd.Parameters.AddWithValue("@studentemail", studentemail);
                            cmd.Parameters.AddWithValue("@subjectname", subjectname);

                            cmd.ExecuteNonQuery();
                        }


                        ShowSuccessMessage("Student Invited Successfully");
                    }
                    else

                    {
                        ShowErrorMessage("This invitation already sent");
                    }
                }
            }
        }
            private void ShowErrorMessage(string message)
{
    string script = $"Swal.fire({{ icon: 'error', text: '{message}' }})";
    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script, true);
}
private void ShowSuccessMessage(string message)
{
    string script = $"Swal.fire({{ icon: 'success', text: '{message}' }})";
    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script, true);
}

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = TextBox1.Text.Trim();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    // If the search term is empty, fetch all student data.
                }
                else
                {
                    // If there is a search term, filter the results.
                    query = "SELECT studentid, email FROM student_info " +
                            "WHERE studentid LIKE @searchTerm OR email LIKE @searchTerm";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            roomlist.DataSource = dataTable; // Update the GridView name to the one for students
                            roomlist.DataBind();
                        }
                    }
                }
            }
        }
    }
}
   