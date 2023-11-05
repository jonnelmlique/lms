﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lms.Professor
{
    public partial class WebForm4 : System.Web.UI.Page
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
                }
            }
        }

        private void BindRoomData(string searchTerm = "")
        {

            string receiver = Session["LoggedInUserEmail"] as string;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT notifid, subject, date " +
               "FROM notification " +
               "WHERE receiver = @receiver";



                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@receiver", receiver);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            roomdetailsGridView.DataSource = dataTable;
                            roomdetailsGridView.DataBind();
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