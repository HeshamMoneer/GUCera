using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class mobileAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Session["type"] != null || Session["password"] != null)
            {
                Response.Redirect("unauthorized.aspx");

            }
        }

        protected void addMob(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand command = new SqlCommand("addMobile", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", id.Text));
                command.Parameters.Add(new SqlParameter("@password", pw.Text));
                command.Parameters.Add(new SqlParameter("@mobile_number", no.Text));

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('This Mobile Number Already Exists') </script>"); 
            }
        
        }
    }
}