using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.Net;
using System.Net.Mail;


namespace lms.Admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["professorid"] != null)
                {
                    int professorID = Convert.ToInt32(Request.QueryString["professorid"]);

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT professor_id, firstname, Email FROM professor WHERE professor_id = @professorid";

                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@professorid", professorID);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    //string name = reader["Name"].ToString();
                                    string email = reader["Email"].ToString();

                                    emailtxt.Text = email;
                                    //emailLabel.Text = email;
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
                else if (Request.QueryString["studentid"] != null)
                {
                    int studentID = Convert.ToInt32(Request.QueryString["studentid"]);

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT student_id, firstname, Email FROM student WHERE student_id = @StudentID";

                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@StudentID", studentID);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string studentFirstName = reader["firstname"].ToString();
                                    string studentEmail = reader["Email"].ToString();

                                    emailtxt.Text = studentEmail;
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
                else
                {

                }
            }
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            string recipientEmail = emailtxt.Text;
            string subject = txtsubject.Text;
            string messageText = txtMessage.Text;
            string gmailSignature = "Novaliches Senior High School Learning Management System";

            messageText += "\n\n" + gmailSignature;
            if (txtMessage.Text == "")
            {
                ErroSub2.Text = " * Please input a message";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "Swal.fire({icon: 'error',text: 'Something went wrong!'})",true);
              
            }
            else
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("novalichesseniorhighschool@gmail.com", "jpscuyqtbmgpkcqw");
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("novalichesseniorhighschool@gmail.com");
                    mailMessage.To.Add(recipientEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = messageText;

                    smtpClient.Send(mailMessage);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                     "Swal.fire({icon: 'success',text: 'Email sent Successfully!'})", true);

                    txtsubject.Text = "";
                    txtMessage.Text = "";
                    ErroSub2.Text = "";
                }
                catch (Exception ex)
                {
                  
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                   "Swal.fire({icon: 'error',text: 'Something went wrong!'})", true);
                }
            }
        }
    }
}