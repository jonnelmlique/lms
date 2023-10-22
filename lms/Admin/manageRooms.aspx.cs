using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Admin
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindRoomData();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                }
            }

        }

        private void BindRoomData(string searchTerm = "")
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Update the query to select distinct professor names and their email addresses,
                    // along with a room_id associated with each professor
                    string query = "SELECT DISTINCT professorname, professoremail, " +
                                   "(SELECT room_id FROM rooms r WHERE r.professorname = rooms.professorname LIMIT 1) AS room_id " +
                                   "FROM rooms";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE professorname LIKE @searchTerm OR professoremail LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            roomGridView.DataSource = dataTable;
                            roomGridView.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                }
            }
        }
    }
}