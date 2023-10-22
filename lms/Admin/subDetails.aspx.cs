using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace lms.Admin
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["room_id"] != null)
                {
                    int roomID;
                    if (int.TryParse(Request.QueryString["room_id"], out roomID))
                    {
                        try
                        {
                            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                            using (MySqlConnection con = new MySqlConnection(connectionString))
                            {
                                con.Open();

                                string query = "SELECT room_id, rooomdescription, professorname FROM rooms WHERE room_id = @room_id";

                                using (MySqlCommand command = new MySqlCommand(query, con))
                                {
                                    command.Parameters.AddWithValue("@room_id", roomID);

                                    using (MySqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            string description = reader["rooomdescription"].ToString();
                                            lbldetails.Text = description;

                                            string name = reader["professorname"].ToString();
                                            lblowner.Text = name;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                    else
                    {
                 
                        lbldetails.Text = "Invalid room_id provided.";
                    }
                }
            }
        
    }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }

      
    }
}