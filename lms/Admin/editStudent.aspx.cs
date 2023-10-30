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
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox3.TextChanged += new EventHandler(TextBox3_TextChanged);
            TextBox4.Enabled = false;
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

                    //Label1.Text = "Invalid date format. Please enter a valid date in the format M/d/yyyy (e.g., 7/21/2005).";
                }
            }
            catch (FormatException)
            {
                ShowErrorMessage("Invalid date format. Please enter a valid date in the format M/d/yyyy (e.g., 7/21/2005).");

                //Label1.Text = "Invalid date format. Please enter a valid date in the format M/d/yyyy (e.g., 7/21/2005).";
            }
        }
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

     
        protected void btnedit_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            int age;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) || string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'error', text: 'Please fill out all the textboxes and select a file'})", true);
                return;
            }

            if (int.TryParse(TextBox4.Text, out age))
            {
                string gender = RadioButton1.Checked ? "Male" : "Female";
                string birthday = TextBox3.Text;
                string contact = TextBox5.Text;
                string email = TextBox6.Text;


                if (!IsEmailUnique(email, username))
                {
                    ShowErrorMessage("Email address is already in use. Please choose a different email.");
                    return;
                }

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();

                        byte[] fileBytes = null;

                        if (FileUpload1.HasFile)
                        {
                            fileBytes = new byte[FileUpload1.PostedFile.InputStream.Length];
                            FileUpload1.PostedFile.InputStream.Read(fileBytes, 0, fileBytes.Length);
                        }

                        string existingPassword = GetExistingPassword(username, con);

                        string userUpdateQuery = "UPDATE users SET password = @Password, email = @Email, profileimage = @ProfileImage WHERE username = @Username";
                        using (MySqlCommand userUpdateCmd = new MySqlCommand(userUpdateQuery, con))
                        {
                            userUpdateCmd.Parameters.AddWithValue("@Password", string.IsNullOrWhiteSpace(TextBox7.Text) ? existingPassword : TextBox7.Text);
                            userUpdateCmd.Parameters.AddWithValue("@Email", email);
                            userUpdateCmd.Parameters.AddWithValue("@ProfileImage", fileBytes ?? GetExistingProfileImage(username, con));
                            userUpdateCmd.Parameters.AddWithValue("@Username", username);

                            int userUpdateRowsAffected = userUpdateCmd.ExecuteNonQuery();

                            if (userUpdateRowsAffected > 0)
                            {
                                string studentInfoUpdateQuery = "UPDATE student_Info SET firstname = @FirstName, lastname = @LastName, email = @Email, age = @Age, gender = @Gender, birthday = @Birthday, contact = @Contact, profileimage = @ProfileImage WHERE username = @Username";
                                using (MySqlCommand studentInfoUpdateCmd = new MySqlCommand(studentInfoUpdateQuery, con))
                                {
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@FirstName", firstName);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@LastName", lastName);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@Email", email);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@Username", username);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@Age", age);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@Gender", gender);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@Birthday", birthday);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@Contact", contact);
                                    studentInfoUpdateCmd.Parameters.AddWithValue("@ProfileImage", fileBytes ?? GetExistingProfileImage(username, con));

                                    int studentInfoUpdateRowsAffected = studentInfoUpdateCmd.ExecuteNonQuery();

                                    if (studentInfoUpdateRowsAffected > 0)
                                    {
                                        ShowSuccessMessage("Student updated successfully");
                                        TextBox1.Text = "";
                                        TextBox2.Text = "";
                                        TextBox3.Text = "";
                                        TextBox4.Text = "";
                                        TextBox5.Text = "";
                                        TextBox6.Text = "";
                                        TextBox7.Text = "";
                                    }
                                    else
                                    {
                                        ShowErrorMessage("Error updating student information");

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



        private string GetExistingPassword(string username, MySqlConnection connection)
        {
            string existingPassword = null;
            string query = "SELECT password FROM users WHERE username = @Username";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        existingPassword = reader["password"].ToString();
                    }
                }
            }
            return existingPassword;
        }
        private byte[] GetExistingProfileImage(string username, MySqlConnection con)
        {
            string query = "SELECT profileimage FROM users WHERE username = @Username";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                var result = cmd.ExecuteScalar();
                return result as byte[];
            }
        }

        private bool IsEmailUnique(string email, string username)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND username != @Username " +
                               "UNION ALL " +
                               "SELECT COUNT(*) FROM student_info WHERE email = @Email AND username != @Username " +
                               "UNION ALL " +
                               "SELECT COUNT(*) FROM teacher_info WHERE email = @Email AND username != @Username";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Username", username);

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


    }
}
