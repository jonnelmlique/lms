using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Student
{
    public partial class classroomMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["roomid"]))
                {

                    if (int.TryParse(Request.QueryString["roomid"], out int roomId))

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
                                            lblschedule.Text = readerRooms["schedule"].ToString();

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
        }
    }
}