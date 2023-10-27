using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace lms.Professor
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string teacherEmail = Session["LoggedInUserEmail"] as string;
                if (string.IsNullOrEmpty(teacherEmail))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    try
                    {


                        string teacherFullName = GetTeacherFullNameFromDatabase(teacherEmail);
                        if (!string.IsNullOrEmpty(teacherFullName))
                        {
                            instructorname.Text = teacherFullName;
                            instructorname.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        //lblMessage.Text = "An error occurred while processing your request. Please try again later.";
                    }
                }
            }
        }

        private string GetTeacherFullNameFromDatabase(string professorEmail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string fullName = "";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT firstname, lastname FROM teacher_info WHERE email = @email";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email", professorEmail);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["firstname"].ToString();
                            string lastName = reader["lastname"].ToString();
                            fullName = $"{firstName} {lastName}";
                        }
                    }
                }
            }

            return fullName;
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

            //if (e.Item.Value == "1")
            //{
            //    if (!AreTextboxesPopulated())
            //    {

            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
            //                    "Swal.fire({icon: 'error',text: 'Please fill out all required fields.'})", true);

            //        Menu1.Items[0].Selected = true;
            //        return;
            //    }
            //}


            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateRoom.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CreateRoom.aspx");
        }
        //private bool AreTextboxesPopulated()
        //{
        //    //if (string.IsNullOrEmpty(instructorname.Text) || string.IsNullOrEmpty(roomname.Text) || string.IsNullOrEmpty(subjectname.Text))
        //    //{
        //    //    return false;
        //    //}
        //    //return true;
        //}
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //string professorEmail = Session["LoggedInUserEmail"] as string;
            //try
            //{


            //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            //    using (MySqlConnection con = new MySqlConnection(connectionString))
            //    {
            //        con.Open();

            //        string query = "INSERT INTO rooms (professorname, professoremail, roomname, subjectname, roomimage, schedule, section, rooomdescription) " +
            //                       "VALUES (@professorname, @professoremail, @roomname, @subjectname, @roomimage, @schedule, @section, @rooomdescription)";
            //        using (MySqlCommand cmd = new MySqlCommand(query, con))
            //        {
            //            cmd.Parameters.AddWithValue("@professorname", instructorname.Text);
            //            cmd.Parameters.AddWithValue("@professoremail", professorEmail);
            //            cmd.Parameters.AddWithValue("@roomname", roomname.Text);
            //            cmd.Parameters.AddWithValue("@subjectname", subjectname.Text);

            //            if (roomimage.HasFile)
            //            {
            //                byte[] imageData = roomimage.FileBytes;
            //                cmd.Parameters.Add(new MySqlParameter("@roomimage", imageData));

            //                ImagePreview.Visible = true;
            //                ImagePreview.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
            //            }
            //            else
            //            {
            //                cmd.Parameters.Add(new MySqlParameter("@roomimage", DBNull.Value));
            //            }

            //            cmd.Parameters.AddWithValue("@schedule", schedule.Text);
            //            cmd.Parameters.AddWithValue("@section", txtsection.Text);
            //            cmd.Parameters.AddWithValue("@rooomdescription", txtdescription.Text);

            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //    Response.Redirect("CreateRoom.aspx");
            //}
            //catch (Exception ex)
            //{
            //    //lblMessage.Text = "An error occurred while processing your request. Please try again later.";
            //}
        }

        protected void GradeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStrandDropdown();

        }

        protected void StrandDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSubjectDropdown();


        }
        private void UpdateStrandDropdown()
        {
            string selectedGrade = g11.Checked ? "11" : g12.Checked ? "12" : "";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT strand FROM subjects WHERE gradeyear = @Grade", con);
                cmd.Parameters.AddWithValue("@Grade", selectedGrade);
                MySqlDataReader reader = cmd.ExecuteReader();

                ddlStrand.Items.Clear();
                ddlStrand.Items.Add(new ListItem("Select Strand", "")); 

                while (reader.Read())
                {
                    ddlStrand.Items.Add(new ListItem(reader["strand"].ToString(), reader["strand"].ToString()));
                }
                reader.Close();
            }

            UpdateSubjectDropdown();
        }

        private void UpdateSubjectDropdown()
        {
            string selectedGrade = g11.Checked ? "11" : g12.Checked ? "12" : "";
            string selectedStrand = ddlStrand.SelectedValue;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subjectname FROM subjects WHERE strand = @Strand AND gradeyear = @GradeYear", con);
                cmd.Parameters.AddWithValue("@Strand", selectedStrand);
                cmd.Parameters.AddWithValue("@GradeYear", selectedGrade); 

                MySqlDataReader reader = cmd.ExecuteReader();

                ddlSubject.Items.Clear();
                ddlSubject.Items.Add(new ListItem("Select Subject", "")); 

                while (reader.Read())
                {
                    ddlSubject.Items.Add(new ListItem(reader["subjectname"].ToString(), reader["subjectname"].ToString()));
                }
                reader.Close();
            }
        }
    }
}