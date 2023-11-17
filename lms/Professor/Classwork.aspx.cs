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
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayMaterials();
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
                    // Handle or log the exception
                }
            }
        }
    }
}