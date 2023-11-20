using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        private int roomId;

        protected void Page_Load(object sender, EventArgs e)

        {



            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["roomid"]))
                {
                    if (int.TryParse(Request.QueryString["roomid"], out roomId))
                    {
                        {
                            try
                            {
                                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                                using (MySqlConnection con = new MySqlConnection(connectionString))
                                {
                                    con.Open();
                                    string queryRooms = "SELECT * FROM rooms WHERE roomid = @roomid";

                                    using (MySqlCommand commandRooms = new MySqlCommand(queryRooms, con))
                                    {
                                        commandRooms.Parameters.AddWithValue("@roomid", roomId);

                                        using (MySqlDataReader readerRooms = commandRooms.ExecuteReader())
                                        {
                                            if (readerRooms.Read())
                                            {
                                                lblsubjectname.Text = readerRooms["subjectname"].ToString();

                                            }
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    
                }
                }

                DisplayMaterials();
            }
        }
        private void DisplayMaterials()
        {
            if (int.TryParse(Request.QueryString["roomid"], out int roomId))
            {
                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT materialsid, materialsname, instructions, posttype, points, duedate, topic, file FROM learningmaterials " +
                                       "WHERE roomid = @roomid ";

                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@roomid", roomId);

                            DataTable dt = new DataTable();
                            using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                            {
                                da.Fill(dt);
                            }

                            materialsGridView.DataSource = dt;
                            materialsGridView.DataBind();
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

        protected string GetEditClassworkUrl(object materialsId, object roomId)
        {
            if (materialsId != null && roomId != null)
            {
                // Assuming your EditClasswork.aspx expects parameters named 'materialsid' and 'roomid'https://localhost:44304/Professor/Classwork.aspx.cs
                return $"editClasswork.aspx?materialsid={materialsId}&roomid={roomId}";
            }

            return "#"; // Or any default URL if the data is not available
        }
        protected void btncreate_Click (object sender, EventArgs e)
        {

            int teacherId = Convert.ToInt32(Session["LoggedInUserID"]);
            string teacherEmail = Session["LoggedInUserEmail"].ToString();

            int roomId;

            if (int.TryParse(Request.QueryString["roomid"], out roomId))
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string subjectname = lblsubjectname.Text;
                    string materialsname = txtmaterialsname.Text;
                    string instructions = txtinstructions.Text;
                    string posttype = "";

                    if (rbassignment.Checked)
                    {
                        posttype = "Assignment";
                    }
                    else if (rbquiz.Checked)
                    {
                        posttype = "Quiz";
                    }
                    else if (rbmaterials.Checked)
                    {
                        posttype = "Materials";
                    }

                    //int points = Convert.ToInt32(drdpoints.SelectedValue);
                    string points = drdpoints.SelectedValue;
                    string duedate = txtduedate.Text;
                    string topic = txttopic.Text;

                    byte[] fileData = GetFileData(file);

                    string insertQuery = "INSERT INTO learningmaterials (roomid, teacherid, teacheremail, subjectname, materialsname, instructions, posttype, points, duedate, topic, file) " +
                                         "VALUES (@roomid, @teacherid, @teacheremail, @subjectname, @materialsname, @instructions, @posttype, @points, @duedate, @topic, @file)";

                    using (MySqlCommand commandInsert = new MySqlCommand(insertQuery, con))
                    {
                        commandInsert.Parameters.AddWithValue("@roomid", roomId);
                        commandInsert.Parameters.AddWithValue("@teacherid", teacherId);
                        commandInsert.Parameters.AddWithValue("@teacheremail", teacherEmail);
                        commandInsert.Parameters.AddWithValue("@subjectname", subjectname);
                        commandInsert.Parameters.AddWithValue("@materialsname", materialsname);
                        commandInsert.Parameters.AddWithValue("@instructions", instructions);
                        commandInsert.Parameters.AddWithValue("@posttype", posttype);
                        commandInsert.Parameters.AddWithValue("@points", points);
                        commandInsert.Parameters.AddWithValue("@duedate", duedate);
                        commandInsert.Parameters.AddWithValue("@topic", topic);
                        commandInsert.Parameters.AddWithValue("@file", fileData);

                        commandInsert.ExecuteNonQuery();

                        ShowSuccessMessage("Your Materials have been successfully posted");
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "successMessage", "showSuccessMessage();", true);
                DisplayMaterials();
            }
        }

        private byte[] GetFileData(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                using (Stream stream = fileUpload.PostedFile.InputStream)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}