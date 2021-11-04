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
    public partial class RegisterStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Session["type"] != null || Session["password"] != null)
            {
                Response.Redirect("unauthorized.aspx");

            }
        }

        protected void Register_Student(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand studentRegister = new SqlCommand("studentRegister", conn);
            studentRegister.CommandType = CommandType.StoredProcedure;
            string first_name = first.Text;
            string last_name = last.Text;
            string pass = password.Text;
            string gend = gender.SelectedValue;
            string em = email.Text;
            string add = address.Text;
            int id = 0;

            studentRegister.Parameters.Add(new SqlParameter("@first_name", first_name));
            studentRegister.Parameters.Add(new SqlParameter("@last_name",last_name));
            studentRegister.Parameters.Add(new SqlParameter("@password", pass));
            studentRegister.Parameters.Add(new SqlParameter("@email", em));
            studentRegister.Parameters.Add(new SqlParameter("@gender", gend));
            studentRegister.Parameters.Add(new SqlParameter("@address", add));
            SqlParameter par = studentRegister.Parameters.Add(new SqlParameter("@id",SqlDbType.Int));
            par.Direction = ParameterDirection.Output;
            conn.Open();
            try
            {
                studentRegister.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");

            }
            conn.Close();
            id = (int)par.Value;
            Response.Write("<script language='javascript'>window.alert('Your id is "+id+", Welcome to the family of GUCera');window.location='Login.aspx';</script>");

            //Response.Redirect("Login.aspx");          
        }

    }
}