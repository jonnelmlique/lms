using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Student
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["roomid"]) && !string.IsNullOrEmpty(Request.QueryString["materialsid"]))
                {
                    if (int.TryParse(Request.QueryString["roomid"], out int roomId) && int.TryParse(Request.QueryString["materialsid"], out int materialsId))
                    {

                        DisplayMaterials(roomId, materialsId);
                        PopulateFileDropdown(roomId, materialsId);
                        ddlFiles.Enabled = false;


                    }
                }
            }
        }
        private void DisplayMaterials(int roomId, int materialsId)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();


             


                    string query = "SELECT materialsid, materialsname, instructions, duedate, topic, posttype, points, dateposted, teachername FROM learningmaterials " +
                                   "WHERE roomid = @roomid AND materialsid = @materialsid";

                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@roomid", roomId);
                        command.Parameters.AddWithValue("@materialsid", materialsId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblteacher.Text = reader["posttype"].ToString();
                                lblpost.Text = reader["posttype"].ToString();
                                lbldateposted.Text = reader["dateposted"].ToString();
                                lblteacher.Text = reader["teachername"].ToString();
                                lblinstructions.Text = reader["instructions"].ToString();
                                lbldue.Text = reader["duedate"].ToString();
                                lblpoints.Text = reader["points"].ToString();

                                //txtinstructions.Text = reader["instructions"].ToString();
                                //txtduedate.Text = reader["duedate"].ToString();
                                //txttopic.Text = reader["topic"].ToString();



                                //// Retrieve and set points
                                //int points = Convert.ToInt32(reader["points"]);
                                //drdpoints.SelectedValue = points.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("An error occurred while retrieving learningmaterials.");
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {

            int selectedFileID = Convert.ToInt32(ddlFiles.SelectedValue);

            byte[] fileData = RetrieveFileData(selectedFileID);

            if (fileData != null)
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", $"attachment; filename={ddlFiles.SelectedItem.Text}");
                Response.BinaryWrite(fileData);
                Response.End();
            }
        }

        protected void ddlFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateFileDropdown(int roomId, int materialsId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT materialsid, FileName FROM learningmaterials WHERE roomid = @roomid AND materialsid = @materialsid";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomid", roomId);
                    command.Parameters.AddWithValue("@materialsid", materialsId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        ddlFiles.DataSource = reader;
                        ddlFiles.DataTextField = "FileName";
                        ddlFiles.DataValueField = "materialsid";
                        ddlFiles.DataBind();
                    }
                }
            }
        }
        private byte[] RetrieveFileData(int materialsid)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FileData FROM learningmaterials WHERE materialsid = @materialsid";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@materialsid", materialsid);
                    return command.ExecuteScalar() as byte[];
                }
            }
        }
    }
}