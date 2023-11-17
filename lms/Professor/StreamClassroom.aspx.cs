using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayAnnouncements();
          
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

                    string insertQuery = "INSERT INTO announcements (roomid, teacherid, teacheremail, postcontent, datepost) " +
                                         "VALUES (@roomid, @teacherid, @teacheremail, @postcontent, @datepost)";

                    using (MySqlCommand commandInsert = new MySqlCommand(insertQuery, con))
                    {
                        commandInsert.Parameters.AddWithValue("@roomid", roomId);
                        commandInsert.Parameters.AddWithValue("@teacherid", teacherId);
                        commandInsert.Parameters.AddWithValue("@teacheremail", teacherEmail);
                        commandInsert.Parameters.AddWithValue("@postcontent", postContent);
                        commandInsert.Parameters.AddWithValue("@datepost", currentDate);

                        commandInsert.ExecuteNonQuery();
                        TextBox1.Text = "";
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

                        string query = "SELECT teacheremail, postcontent, datepost FROM announcements " +
                           "WHERE roomid = @roomid AND teacherid = @teacherid " +
                            "ORDER BY datepost DESC ";



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
       
        
    }
}