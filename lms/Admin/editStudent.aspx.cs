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

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            string email = TextBox6.Text;
            int age;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) || string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox5.Text) || string.IsNullOrWhiteSpace(TextBox7.Text) || !FileUpload1.HasFile)
            {
                // Not all required fields are filled, or a file is not selected, show an alert.
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'error', text: 'Please fill out all the textboxes and select a file'})", true);
                return; // Exit the method without further processing.
            }

            if (int.TryParse(TextBox4.Text, out age))
            {
                string gender = RadioButton1.Checked ? "Male" : "Female";
                string birthday = TextBox3.Text;
                string contact = TextBox5.Text;
                string password = TextBox7.Text;

                if (IsEmailUnique(email))
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            con.Open();

                            string userQuery = "INSERT INTO users (password, email, usertype, profileimage) VALUES (@Password, @Email, 'teacher', @ProfileImage)";
                            using (MySqlCommand userCmd = new MySqlCommand(userQuery, con))
                            {
                                userCmd.Parameters.AddWithValue("@Password", password);
                                userCmd.Parameters.AddWithValue("@Email", email);

                                if (FileUpload1.HasFile)
                                {
                                    byte[] imageData = FileUpload1.FileBytes;
                                    userCmd.Parameters.Add(new MySqlParameter("@ProfileImage", imageData));
                                }
                                else
                                {
                                    userCmd.Parameters.Add(new MySqlParameter("@ProfileImage", DBNull.Value));
                                }

                                int userRowsAffected = userCmd.ExecuteNonQuery();

                                if (userRowsAffected > 0)
                                {
                                    string teacherQuery = "INSERT INTO teacher_info (firstname, lastname, email, age, gender, birthday, contact, profileimage) VALUES (@FirstName, @LastName, @Email, @Age, @Gender, @Birthday, @Contact, @ProfileImage)";
                                    using (MySqlCommand teacherCmd = new MySqlCommand(teacherQuery, con))
                                    {
                                        teacherCmd.Parameters.AddWithValue("@FirstName", firstName);
                                        teacherCmd.Parameters.AddWithValue("@LastName", lastName);
                                        teacherCmd.Parameters.AddWithValue("@Email", email);
                                        teacherCmd.Parameters.AddWithValue("@Age", age);
                                        teacherCmd.Parameters.AddWithValue("@Gender", gender);
                                        teacherCmd.Parameters.AddWithValue("@Birthday", birthday);
                                        teacherCmd.Parameters.AddWithValue("@Contact", contact);

                                        if (FileUpload1.HasFile)
                                        {
                                            byte[] imageData = FileUpload1.FileBytes;
                                            teacherCmd.Parameters.Add(new MySqlParameter("@ProfileImage", imageData));
                                        }
                                        else
                                        {
                                            teacherCmd.Parameters.Add(new MySqlParameter("@ProfileImage", DBNull.Value));
                                        }

                                        int teacherRowsAffected = teacherCmd.ExecuteNonQuery();

                                        if (teacherRowsAffected > 0)
                                        {
                                            ShowSuccessMessage("Teacher added successfully");
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
                                            ShowErrorMessage("Error adding teacher to table");
                                        }
                                    }
                                }
                                else
                                {
                                    ShowErrorMessage("Error adding teacher to table");
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
                    ShowErrorMessage("Email already Exists");
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

                string query = "SELECT COUNT(*) FROM teacher_info WHERE email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0;
                }
            }
        }
    }
}