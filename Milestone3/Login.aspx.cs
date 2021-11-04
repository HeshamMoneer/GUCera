using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Session["type"] != null || Session["password"] != null)
            {
                Response.Redirect("unauthorized.aspx");

            }
        }



        protected void login1(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand loginproc = new SqlCommand("userLogin", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            int id = Int16.Parse(username.Text);
            string pass = password.Text;
            loginproc.Parameters.Add(new SqlParameter("@id", id));
            loginproc.Parameters.Add(new SqlParameter("password", pass));
            SqlParameter sucess = loginproc.Parameters.Add(new SqlParameter("@success", SqlDbType.Int));
            SqlParameter type = loginproc.Parameters.Add(new SqlParameter("@type", SqlDbType.Int));
            sucess.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;
            conn.Open();
            Session["user"] = id;
            Session["password"] = pass;

            loginproc.ExecuteNonQuery();
            conn.Close();
            if (sucess.Value.ToString() == "1")
            {
                Session["type"] = type.Value.ToString();
                if (type.Value.ToString() == "0")
                {
                    Response.Redirect("homeInstructor.aspx");
                }
                else if (type.Value.ToString() == "1")
                {
                    Response.Redirect("admin.aspx");
                }
                else if (type.Value.ToString() == "2") { 

                    Response.Redirect("StudentHome.aspx");
                }
            }

                else
                {
                Session["user"] = null;
                Session["type"] = null;
                Session["password"] = null;
                Response.Write("<script> alert('Wrong User ID or Password')</script>");
                }
        }

        protected void AddNu(object sender, EventArgs e)
        {
            Response.Redirect("mobileAdd.aspx");
        }
    }

}