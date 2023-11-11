using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Admin
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["roomid"] != null)
                {
                    int roomID;
                    if (int.TryParse(Request.QueryString["roomid"], out roomID))
                    {
                        try
                        {
                            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                            using (MySqlConnection con = new MySqlConnection(connectionString))
                            {
                                con.Open();

                                string query = "SELECT roomid, description, teachername FROM rooms WHERE roomid = @roomid";

                                using (MySqlCommand command = new MySqlCommand(query, con))
                                {
                                    command.Parameters.AddWithValue("@roomid", roomID);

                                    using (MySqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            string description = reader["description"].ToString();
                                            lbldetails.Text = description;

                                            string name = reader["teachername"].ToString();
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
                 
                        lbldetails.Text = "Invalid roomid provided.";
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