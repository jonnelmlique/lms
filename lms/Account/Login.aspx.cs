using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace lms.LOGIN
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtemail.Focus();
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtemail.Text.Trim();
                string password = txtpassword.Text.Trim();

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                bool emailValid = false;
                bool passwordValid = false;
                string userStatus = "";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    emailValid = CheckEmail(con, email);

                    if (emailValid)
                    {
                        passwordValid = CheckPassword(con, email, password);
                        userStatus = GetUserStatus(con, email);
                    }

                    if (emailValid && passwordValid && userStatus == "Activated")
                    {
                        string usertype = DetermineUserUsertype(con, email);
                        if (!string.IsNullOrEmpty(usertype))
                        {
                            Session["LoggedInUserEmail"] = email;
                            Session["LoggedInUserType"] = usertype;

                            if (usertype == "admin")
                            {
                                Response.Redirect("/Admin/DashBoard.aspx");
                            }
                            else if (usertype == "student")
                            {
                                Response.Redirect("/Student/DashBoard.aspx");
                            }
                            else if (usertype == "teacher")
                            {
                                Response.Redirect("/Professor/DashBoard.aspx");
                            }
                        }
                        else
                        {
                            ShowErrorMessage("Invalid User Type");
                        }
                    }
                    else
                    {
                        if (userStatus == "Deactivated")
                        {
                            ShowErrorMessage("Your account is deactivated. Email the admin for more info.");
                        }
                        else if (!emailValid)
                        {
                            ShowErrorMessage("Invalid Email");
                        }
                        else
                        {
                            ShowErrorMessage("Invalid Password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("An error occurred while processing your request. Please try again later.");
            }
        
    }
        private string GetUserStatus(MySqlConnection con, string email)
        {
            string query = "SELECT Status FROM users WHERE Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                object status = cmd.ExecuteScalar();
                if (status != null)
                {
                    return status.ToString();
                }
                return null;
            }
        }

        private bool CheckEmail(MySqlConnection con, string email)
        {
            string query = "SELECT Email FROM users WHERE BINARY Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                return cmd.ExecuteScalar() != null;
            }
        }
        private bool CheckPassword(MySqlConnection con, string email, string password)
        {
            string query = "SELECT Password FROM users WHERE Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["Password"].ToString();
                        return VerifyPassword(password, storedPassword);
                    }
                }
                return false;
            }
        }

        private string DetermineUserUsertype(MySqlConnection con, string email)
        {
            string query = "SELECT usertype FROM users WHERE Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                return (string)cmd.ExecuteScalar();
            }
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return inputPassword.Equals(hashedPassword);
        }

        private void ShowErrorMessage(string message)
        {
            string script = $"Swal.fire({{ icon: 'error', text: '{message}' }})";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script, true);
        }
    }
}
    