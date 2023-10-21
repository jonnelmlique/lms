using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace lms.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindProfessorData();
                }
                catch (Exception ex)
                {

                }

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {


                        con.Open();
                        string query = "SELECT professor_id, CONCAT(firstName, ' ', lastName) AS Fullname, email FROM professor";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            using (MySqlCommand command = new MySqlCommand(query, con))
                            {
                                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                                {
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);

                                    professorGridView.DataSource = dataTable;
                                    professorGridView.DataBind();
                                }
                            }
                        }
                    }


                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred while processing your request. Please try again later.";

                    }
                }
            }
        }
        private void BindProfessorData(string searchTerm = "")
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {


                    con.Open();

                    string query = "SELECT professor_id, CONCAT(firstName, ' ', lastName) AS Fullname, email FROM professor ";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE professor_id LIKE @searchTerm OR CONCAT(firstName, ' ', lastName) LIKE @searchTerm OR email LIKE @searchTerm";
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

                            professorGridView.DataSource = dataTable;
                            professorGridView.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred while processing your request. Please try again later.";

                }
            }
        }

        protected void btnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchTerm = txtsearch.Text;
            BindProfessorData(searchTerm);
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            BindProfessorData();
            txtsearch.Text = "";
        }
    }
}