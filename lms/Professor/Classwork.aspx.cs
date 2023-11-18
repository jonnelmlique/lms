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
                // Assuming your EditClasswork.aspx expects parameters named 'materialsid' and 'roomid'
                return $"editClasswork.aspx?materialsid={materialsId}&roomid={roomId}";
            }

            return "#"; // Or any default URL if the data is not available
        }

    }
}