using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Admin
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox3.TextChanged += new EventHandler(TextBox3_TextChanged);
            TextBox4.Enabled = false;

            if (Request.QueryString["teacherid"] != null)
            {
                int teacherid;
                if (int.TryParse(Request.QueryString["teacherid"], out teacherid))
                {
                    try
                    {
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();

                            string queryTeacher = "SELECT * FROM teacher_info WHERE teacherid = @teacherid";

                            using (MySqlCommand commandStudent = new MySqlCommand(queryTeacher, con))
                            {
                                commandStudent.Parameters.AddWithValue("@teacherid", teacherid);

                                using (MySqlDataReader readerStudent = commandStudent.ExecuteReader())
                                {
                                    if (readerStudent.Read())
                                    {
                                        TextBox1.Text = readerStudent["firstname"].ToString();
                                        TextBox2.Text = readerStudent["lastname"].ToString();
                                        txtusername.Text = readerStudent["username"].ToString();
                                        TextBox3.Text = readerStudent["birthday"].ToString();
                                        TextBox4.Text = readerStudent["age"].ToString();

                                        string gender = readerStudent["gender"].ToString();
                                        if (gender == "Male")
                                        {
                                            RadioButton1.Checked = true;
                                        }
                                        else if (gender == "Female")
                                        {
                                            RadioButton2.Checked = true;
                                        }

                                        TextBox5.Text = readerStudent["contact"].ToString();
                                        TextBox6.Text = readerStudent["email"].ToString();

                                        byte[] imageBytes = (byte[])readerStudent["profileimage"];
                                        if (imageBytes != null && imageBytes.Length > 0)
                                        {
                                            string base64String = Convert.ToBase64String(imageBytes);
                                            ImagePreview.ImageUrl = "data:image/jpeg;base64," + base64String;
                                        }

                                        string status = readerStudent["status"].ToString();
                                        if (status == "Activated")
                                        {
                                            RadioButton3.Checked = true;
                                        }
                                        else if (status == "Deactivated")
                                        {
                                            RadioButton4.Checked = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception here
                    }
                }
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dateStr = TextBox3.Text;
                DateTime dob;

                if (DateTime.TryParseExact(dateStr, "M/d/yyyy", null, DateTimeStyles.None, out dob))
                {
                    int age = CalculateAge(dob);

                    TextBox4.Text = "" + age + "";
                }
                else
                {
                    ShowErrorMessage("Invalid date format. Please enter a valid date in the format M/d/yyyy (e.g., 7/21/2005).");
                }
            }
            catch (FormatException)
            {
                ShowErrorMessage("Invalid date format. Please enter a valid date in the format M/d/yyyy (e.g., 7/21/2005).");

            }
        }
        //newedit
        private int CalculateAge(DateTime dob)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dob.Year;

            if (currentDate.Month < dob.Month || (currentDate.Month == dob.Month && currentDate.Day < dob.Day))
            {
                age--;
            }

            return age;
        }
            protected void btnedit_Click(object sender, EventArgs e)
            {
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            string email = TextBox6.Text;
            string username = txtusername.Text; // Username should not be updated
            int age;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) || string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox5.Text) || string.IsNullOrWhiteSpace(TextBox7.Text))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'error', text: 'Please fill out all the textboxes and select a file'})", true);
                return;
            }

            if (int.TryParse(TextBox4.Text, out age))
            {
                string gender = RadioButton1.Checked ? "Male" : "Female";
                string birthday = TextBox3.Text;
                string contact = TextBox5.Text;
                string password = TextBox7.Text;
                string status = RadioButton3.Checked ? "Activated" : "Deactivated";

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();

                        // Update user information based on the username (which remains constant)
                        string userQuery = "UPDATE users SET email = @Email, password = @Password WHERE username = @Username";
                        using (MySqlCommand userCmd = new MySqlCommand(userQuery, con))
                        {
                            userCmd.Parameters.AddWithValue("@Username", username);
                            userCmd.Parameters.AddWithValue("@Email", email);
                            userCmd.Parameters.AddWithValue("@Password", password);

                            int userRowsAffected = userCmd.ExecuteNonQuery();

                            if (userRowsAffected > 0)
                            {
                                // Update teacher information based on the username (which remains constant)
                                string teacherQuery = "UPDATE teacher_info SET firstname = @FirstName, lastname = @LastName, email = @Email, age = @Age, gender = @Gender, birthday = @Birthday, contact = @Contact WHERE username = @Username";
                                using (MySqlCommand teacherCmd = new MySqlCommand(teacherQuery, con))
                                {
                                    teacherCmd.Parameters.AddWithValue("@Username", username);
                                    teacherCmd.Parameters.AddWithValue("@FirstName", firstName);
                                    teacherCmd.Parameters.AddWithValue("@LastName", lastName);
                                    teacherCmd.Parameters.AddWithValue("@Email", email);
                                    teacherCmd.Parameters.AddWithValue("@Age", age);
                                    teacherCmd.Parameters.AddWithValue("@Gender", gender);
                                    teacherCmd.Parameters.AddWithValue("@Birthday", birthday);
                                    teacherCmd.Parameters.AddWithValue("@Contact", contact);

                                    int teacherRowsAffected = teacherCmd.ExecuteNonQuery();

                                    if (teacherRowsAffected > 0)
                                    {
                                        ShowSuccessMessage("The Teacher account has been updated successfully.");
                                        // Clear form fields or perform other actions as needed

                                        ClientScript.RegisterStartupScript(this.GetType(), "successMessage", "showSuccessMessage();", true);
                                    }
                                    else
                                    {
                                        ShowErrorMessage("Error updating Teacher information");
                                    }
                                }
                            }
                            else
                            {
                                ShowErrorMessage("Error updating user information");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Error Processing");
                    }
                }
            }
            else
            {
                ShowErrorMessage("Invalid Age");
            }
        }
        
    


        private bool IsEmailUnique(string email)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM users WHERE email = @Email " +
                               "UNION ALL " +
                               "SELECT COUNT(*) FROM student_info WHERE email = @Email " +
                               "UNION ALL " +
                               "SELECT COUNT(*) FROM teacher_info WHERE email = @Email";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int totalCount = 0;

                        while (reader.Read())
                        {
                            totalCount += reader.GetInt32(0);
                        }

                        return totalCount == 0;
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

      
    }
}
