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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT student_id, CONCAT(firstName, ' ', lastName) AS Fullname, email FROM student";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, con))
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                               studentRepeater.DataSource = dataTable;
                                studentRepeater.DataBind();
                            }
                        }
                    }
                }
            }
        }
    }
}