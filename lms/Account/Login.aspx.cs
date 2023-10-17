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

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string password = txtpassword.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            bool emailValid = false;
            bool passwordValid = false;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                emailValid = CheckEmail(con, "admin", email) || CheckEmail(con, "student", email) || CheckEmail(con, "Professors", email);

                if (emailValid)
                {
                    passwordValid = CheckPassword(con, "admin", email, password) || CheckPassword(con, "student", email, password) || CheckPassword(con, "professor", email, password);
                }

                if (emailValid && passwordValid)
                {
                    string usertype = DetermineUserUsertype(con, "admin", email) ?? DetermineUserUsertype(con, "student", email) ?? DetermineUserUsertype(con, "professor", email);
                    if (usertype != null)

                        Session["LoggedInUserEmail"] = email;
                    Session["LoggedInUserusertype"] = usertype;

                    {
                        if (usertype == "admin")
                        {
                            Response.Redirect("Admin/DashBoard.aspx");
                        }
                        else if (usertype == "student")
                        {
                            Response.Redirect("Student/DashBoard.aspx");
                        }
                        else if (usertype == "professor")
                        {
                            Response.Redirect("Professor/DashBoard.aspx");
                        }
                    }
                }
                else
                {
                    if (!emailValid && !passwordValid)
                    {
                        lblMessage.Text = "Invalid email and password.";
                    }
                    else if (!emailValid)
                    {
                        lblMessage.Text = "Invalid email.";
                    }
                    else
                    {
                        lblMessage.Text = "Invalid password.";
                    }
                }
            }
        }
        private bool CheckEmail(MySqlConnection con, string tableName, string email)
        {
            string query = $"SELECT Email FROM {tableName} WHERE Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                return cmd.ExecuteScalar() != null;
            }
        }
        private bool CheckPassword(MySqlConnection con, string tableName, string email, string password)
        {
            string query = $"SELECT Password FROM {tableName} WHERE Email = @Email AND Password = @Password";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                return cmd.ExecuteScalar() != null;
            }

        }
        private string DetermineUserUsertype(MySqlConnection con, string tableName, string email)
        {
            string query = $"SELECT usertype FROM {tableName} WHERE Email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}