using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace lms.Account
{
    public partial class Reset_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tableName = Request.QueryString["table"];
                string token = Request.QueryString["token"];

                if (!string.IsNullOrEmpty(tableName) && IsValidToken(token, tableName))
                {
                    txtnewpassword.Enabled = true;
                    txtconfirmpassword.Enabled = true;

                }
                else
                {
                    lblMessage.Text = "Invalid or expired reset token. Please request a new one.";
                    txtnewpassword.Enabled = false;
                    txtconfirmpassword.Enabled = false;

                }
            }
        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
            string tableName = Request.QueryString["table"];
            string token = Request.QueryString["token"];
            string newPassword = txtnewpassword.Text;
            string confirmPassword = txtconfirmpassword.Text;

            if (!string.IsNullOrEmpty(tableName) && IsValidToken(token, tableName))
            {
                if (newPassword == confirmPassword)
                {
                    ResetPassword(token, newPassword, tableName);
                    lblMessage.Text = "Password reset successful. You can now log in with your new password.";
                    txtnewpassword.Text = "";
                    txtconfirmpassword.Text = "";
                    txtnewpassword.Enabled = false;
                    txtconfirmpassword.Enabled = false;
                }
                else
                {
                    lblMessage.Text = "New Password and Confirm Password must match.";
                }
            }
            else
            {
                lblMessage.Text = "Invalid or expired reset token. Please request a new one.";
            }
        }
    
        private bool IsValidToken(string token, string tableName)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = $"SELECT TokenExpiration FROM {tableName} WHERE ResetToken = @Token";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Token", token);
                    object tokenExpiration = cmd.ExecuteScalar();

                    if (tokenExpiration != null && DateTime.Now <= Convert.ToDateTime(tokenExpiration))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void ResetPassword(string token, string newPassword, string tableName)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string updateQuery = $"UPDATE {tableName} SET Password = @NewPassword, ResetToken = NULL, TokenExpiration = NULL WHERE ResetToken = @Token";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@Token", token);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}