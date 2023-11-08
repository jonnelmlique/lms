using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Account
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedInUserEmail"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    string userType = Session["LoggedInUserType"] as string;

                    if (userType == "student")
                    {
                        Response.Redirect("~/Student/DashBoard.aspx");
                    }
                    else if (userType == "admin")
                    {
                        Response.Redirect("~/Admin/DashBoard.aspx");
                    }
                    else
                    {
                        string userEmail = Session["LoggedInUserEmail"] as string;

                        if (!string.IsNullOrEmpty(userEmail))
                        {
                            lblUserEmail.Text = userEmail;


                            byte[] profileImageBytes = GetUserProfileImage(userEmail);
                            if (profileImageBytes != null)
                            {
                                string base64Image = Convert.ToBase64String(profileImageBytes);
                                string imageSrc = "data:image/jpeg;base64," + base64Image;
                                Image1.ImageUrl = imageSrc;
                            }

                            DisplayTeacherProfileInfo(userEmail);
                        }
                    }
                }
            }
        }


        private byte[] GetUserProfileImage(string userEmail)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT profileimage FROM users WHERE email = @userEmail";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!(reader["profileimage"] is DBNull))
                            {
                                return (byte[])reader["profileimage"];
                            }
                        }
                    }
                }
            }

            return null;
        }

        private void DisplayTeacherProfileInfo(string userEmail)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT teacherid, firstname, lastname, age, birthday, email, profileimage, username FROM teacher_info WHERE email = @userEmail";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBox1.Text = reader["firstname"].ToString();
                            TextBox2.Text = reader["lastname"].ToString();
                            TextBox3.Text = reader["teacherid"].ToString();
                            TextBox4.Text = reader["age"].ToString();
                            TextBox8.Text = reader["birthday"].ToString();
                            TextBox9.Text = reader["email"].ToString();
                            txtusername.Text = reader["username"].ToString();

                            byte[] imageBytes = reader["profileimage"] as byte[];
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                string base64String = Convert.ToBase64String(imageBytes);
                                Image2.ImageUrl = "data:image/jpeg;base64," + base64String;
                            }
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userEmail = Session["LoggedInUserEmail"] as string;
            string currentPassword = TextBox5.Text;
            string newPassword = TextBox6.Text;
            string confirmPassword = TextBox7.Text;

            if (ValidateCurrentPassword(userEmail, currentPassword) && newPassword == confirmPassword)
            {
                ChangePassword(userEmail, newPassword);
                ShowSuccessMessage("Password updated successfully.");
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";

            }
            else
            {
                ShowErrorMessage("Failed to update password.");

            }

        }
        private void ChangePassword(string userEmail, string newPassword)
        {


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE users SET password = @newPassword WHERE email = @userEmail";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool ValidateCurrentPassword(string userEmail, string currentPassword)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT password FROM users WHERE email = @userEmail";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();

                            if (currentPassword == storedPassword)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
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



        protected void btnchangeimage_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    byte[] fileBytes = null;

                    if (FileUpload1.HasFile)
                    {
                        fileBytes = new byte[FileUpload1.PostedFile.InputStream.Length];
                        FileUpload1.PostedFile.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    }


                    string userQuery = "UPDATE users SET profileimage = @ProfileImage WHERE username = @Username";
                    using (MySqlCommand userCmd = new MySqlCommand(userQuery, con))
                    {
                        userCmd.Parameters.AddWithValue("@Username", username);
                        userCmd.Parameters.AddWithValue("@ProfileImage", fileBytes ?? GetExistingProfileImage(username, con));

                        int userRowsAffected = userCmd.ExecuteNonQuery();

                        string teacherQuery = "UPDATE teacher_info SET  profileimage = @ProfileImage WHERE username = @Username";
                        using (MySqlCommand teacherCmd = new MySqlCommand(teacherQuery, con))
                        {
                            teacherCmd.Parameters.AddWithValue("@Username", username);
                            teacherCmd.Parameters.AddWithValue("@ProfileImage", fileBytes ?? GetExistingProfileImage(username, con));

                            int teacherRowsAffected = teacherCmd.ExecuteNonQuery();

                            if (userRowsAffected > 0 && teacherRowsAffected > 0)
                            {
                                ShowSuccessMessage("The Teacher Profile Picture has been updated successfully.");
                                ClearInputFields();
                                ClientScript.RegisterStartupScript(this.GetType(), "successMessage", "showSuccessMessage();", true);

                            }
                            else
                            {
                                ShowErrorMessage("Error updating Teacher Profile Picture");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error processing: " + ex.Message);
            } 
        }
        private void ClearInputFields()
        {
            Image2.ImageUrl = "";

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
    }
}

