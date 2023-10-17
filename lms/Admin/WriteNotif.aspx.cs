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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (!string.IsNullOrEmpty(Request.QueryString["professor_id"]))
            //    {
            //        string professorId = Request.QueryString["professor_id"];

            //        string email = GetEmailForProfessor(professorId);

            //        txtTitle.Text = email;
            //    }
            //}
        }
    }
}
//        private string GetEmailForProfessor(string professorId)
//        {

//            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
//            try
//            {
//                using (MySqlConnection con = new MySqlConnection(connectionString))
//                {
//                    con.Open();

//                    string query = "SELECT email FROM professor WHERE professor_id = @professorId";

//                    using (MySqlCommand cmd = new MySqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddWithValue("@professorId", professorId);

//                        object result = cmd.ExecuteScalar();

//                        if (result != null)
//                        {
//                            return result.ToString();
//                        }
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
              
//            }

          
//            return "example@email.com";
//        }
//    }
//}
