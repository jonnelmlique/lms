﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class NotificationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["notifid"] != null)
                {
                    string notifid = Request.QueryString["notifid"];
                    try
                    {
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();
                            string query = "SELECT sender, subject, message FROM notification WHERE notifid = @notifid";

                            using (MySqlCommand command = new MySqlCommand(query, con))
                            {
                                command.Parameters.AddWithValue("@notifid", notifid);

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string senders = reader["sender"].ToString();
                                        string subject = reader["subject"].ToString();
                                        string message = reader["message"].ToString();

                                        TextBox1.Text = senders;
                                        TextBox2.Text = subject;
                                        TextBox3.Text = message;

                                        //BindStudentData(roomid);
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
                
            

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("notifications.aspx");
        }
    }
}