using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class instructorClassroom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (!string.IsNullOrEmpty(Request.QueryString["roomid"]))
                {

                    if (int.TryParse(Request.QueryString["roomid"], out int roomId))

                    {
                        try
                        {
                            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                            using (MySqlConnection con = new MySqlConnection(connectionString))
                            {
                                con.Open();
                                string queryRooms = "SELECT * FROM rooms WHERE roomid = @roomid";

                                using (MySqlCommand commandRooms = new MySqlCommand(queryRooms, con))
                                {
                                    commandRooms.Parameters.AddWithValue("@roomid", roomId);

                                    using (MySqlDataReader readerRooms = commandRooms.ExecuteReader())
                                    {
                                        if (readerRooms.Read())
                                        {
                                            lblsubjectname.Text = readerRooms["subjectname"].ToString();
                                            lblschedule.Text = readerRooms["schedule"].ToString();
                                            lblinstructormain.Text = readerRooms["teacheremail"].ToString();
                                        }
                                    }
                                }
                                string queryStudents = "SELECT studentemail FROM invitation WHERE roomid = @roomid AND status = 'Accepted'";
                                using (MySqlCommand commandStudents = new MySqlCommand(queryStudents, con))
                                {
                                    commandStudents.Parameters.AddWithValue("@roomid", roomId);

                                    DataTable dt = new DataTable();
                                    using (MySqlDataAdapter da = new MySqlDataAdapter(commandStudents))
                                    {
                                        da.Fill(dt);
                                    }

                                    if (dt.Rows.Count > 0)
                                    {
                                        studentlist.DataSource = dt;
                                        studentlist.DataBind();
                                    }
                                    else
                                    {
                                        studentlist.EmptyDataText = "No Students Found for this Room";
                                        studentlist.DataSource = null;
                                        studentlist.DataBind();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                DisplayAnnouncements();
            }

        }

        protected void btncreatepost_Click(object sender, EventArgs e)
        {
            int teacherId = Convert.ToInt32(Session["LoggedInUserID"]);
            string teacherEmail = Session["LoggedInUserEmail"].ToString();

            string postContent = TextBox1.Text;
            DateTime currentDate = DateTime.Now;

            int roomId;

            if (int.TryParse(Request.QueryString["roomid"], out roomId))
            {

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO announcements (roomid, teacherid, teacheremail, postcontent, date) " +
                                         "VALUES (@roomid, @teacherid, @teacheremail, @postcontent, @date)";

                    using (MySqlCommand commandInsert = new MySqlCommand(insertQuery, con))
                    {
                        commandInsert.Parameters.AddWithValue("@roomid", roomId);
                        commandInsert.Parameters.AddWithValue("@teacherid", teacherId);
                        commandInsert.Parameters.AddWithValue("@teacheremail", teacherEmail);
                        commandInsert.Parameters.AddWithValue("@postcontent", postContent);
                        commandInsert.Parameters.AddWithValue("@date", currentDate);

                        commandInsert.ExecuteNonQuery();

                        ShowSuccessMessage("Your post has been successfully posted");



                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "successMessage", "showSuccessMessage();", true);
                DisplayAnnouncements();
    
            }
        }
        private void DisplayAnnouncements()
        {


            if (int.TryParse(Request.QueryString["roomid"], out int roomId))
            {
                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT teacheremail, postcontent, date FROM announcements " +
                  "WHERE roomid = @roomid AND teacherid = @teacherid " +
                  "ORDER BY date DESC ";
                  


                        int teacherId = Convert.ToInt32(Session["LoggedInUserID"]);

                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@roomid", roomId);
                            command.Parameters.AddWithValue("@teacherid", teacherId);

                            DataTable dt = new DataTable();
                            using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                            {
                                da.Fill(dt);
                            }

                            postGridView.DataSource = dt;
                            postGridView.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {

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

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    InsertLearningMaterial();

        //}
        //    private void InsertLearningMaterial()
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        //        int teacherId;
        //        string teacherEmail;
        //        string subjectname;
        //          string materialType = "";


        //              if (rbassignment.Checked)
        //                 {
        //                  materialType = "Assignment";
        //                      }
        //                     else if (rbquiz.Checked)
        //                       {
        //              materialType = "Quiz";
        //           }
        //           else if (rbmaterials.Checked)
        //       {
        //        materialType = "Materials";
        //    }
        //    else
        //    {
        //        // Handle the case where none of the radio buttons are checked
        //    }

        //    // Now, the variable materialType contains the selected material type

        //    string materialsname = TextBox2.Text;
        //    string instructions = TextBox3.Text;
        //    string points = DropDownList2.SelectedValue;
        //    string duedate = TextBox5.Text;
        //    string topic = TextBox6.Text;



        //    if (int.TryParse(Request.QueryString["roomid"], out int roomId))
        //        {
        //            try
        //            {
        //                using (MySqlConnection con = new MySqlConnection(connectionString))
        //                {
        //                    con.Open();
        //                    string queryRooms = "SELECT teacherid, teacheremail, subjectname FROM rooms WHERE roomid = @roomid";

        //                    using (MySqlCommand commandRooms = new MySqlCommand(queryRooms, con))
        //                    {
        //                        commandRooms.Parameters.AddWithValue("@roomid", roomId);

        //                        using (MySqlDataReader readerRooms = commandRooms.ExecuteReader())
        //                        {
        //                            if (readerRooms.Read())
        //                            {
        //                                teacherId = Convert.ToInt32(readerRooms["teacherid"]);
        //                                teacherEmail = readerRooms["teacheremail"].ToString();
        //                                subjectname = readerRooms["subjectname"].ToString();

        //                            }
        //                            else
        //                            {

        //                                return;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"An error occurred while fetching teacher information: {ex.Message}");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }


        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string query = "INSERT INTO learningmaterials (subjectname, roomid, teacherid, teacheremail, materialsname, instructions, posttype, points, duedate, topic, file) " +
        //                            "VALUES (@subjectname, @roomid, @teacherid, @teacheremail, @materialsname, @instructions, @posttype ,@topic, @points, @duedate, @topic, @file)";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@subjectname", subjectname);
        //                command.Parameters.AddWithValue("@roomid", roomId);
        //                command.Parameters.AddWithValue("@teacherid", teacherId);
        //                command.Parameters.AddWithValue("@teacheremail", teacherEmail);
        //                command.Parameters.AddWithValue("@materialsname", materialsname);
        //                command.Parameters.AddWithValue("@instructions", instructions);
        //                command.Parameters.AddWithValue("@posttype", materialType);

        //                command.Parameters.AddWithValue("@points", points);
        //                command.Parameters.AddWithValue("@duedate", duedate);
        //                command.Parameters.AddWithValue("@topic", topic);


        //            if (FileUpload1 != null && FileUpload1.HasFile)
        //            {
        //                byte[] fileContent = FileUpload1.FileBytes;
        //                command.Parameters.AddWithValue("@file", fileContent);
        //            }
        //            else
        //            {
        //                command.Parameters.AddWithValue("@file", DBNull.Value);
        //            }


        //            try
        //            {
        //                    connection.Open();
        //                    command.ExecuteNonQuery();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine($"An error occurred while inserting learning material: {ex.Message}");
        //                }
        //            }
        //        }
        //    }

        protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }
    }
}