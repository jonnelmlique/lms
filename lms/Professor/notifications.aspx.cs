using MySql.Data.MySqlClient;
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

        //protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        //{
        //    int index = Int32.Parse(e.Item.Value);
        //    MultiView1.ActiveViewIndex = index;
        //}
        private void BindRoomData(string searchTerm = "")
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT DISTINCT  subject, " +
                                   "(SELECT notifid  FROM notification r WHERE r.receiver = notification.receiver LIMIT 1) AS notifid " +
                                   "FROM notification";
                   

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                       
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

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 0;

        //}
    }
}