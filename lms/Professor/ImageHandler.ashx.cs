using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lms.Professor
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["room_id"] != null)
            {
                int room_id = Convert.ToInt32(context.Request.QueryString["room_id"]);

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT roomimage FROM rooms WHERE room_id = @room_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@room_id", room_id);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                context.Response.ContentType = "image/jpeg";
                                context.Response.BinaryWrite((byte[])dr["roomimage"]);
                            }
                        }
                    }
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}