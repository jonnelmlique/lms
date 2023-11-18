using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected int GetTotalRoomsCount()
        {
            int roomscount = 0; try
            {


                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM rooms";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        roomscount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                roomscount = 0;
            }
            return roomscount;
        }
        protected int GetTotalNotificationCount()
        {
            int notificationCount = 0; try
            {


                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM notification";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        notificationCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                notificationCount = 0;
            }
            return notificationCount;
        }
    }
}