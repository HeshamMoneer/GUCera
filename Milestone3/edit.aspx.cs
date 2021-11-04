using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand Edit = new SqlCommand("editMyProfile", conn);
            Edit.CommandType = CommandType.StoredProcedure;
            try
            {
                int sid = (int)Session["user"];
                Edit.Parameters.Add(new SqlParameter("@id", sid));
                Edit.Parameters.Add(new SqlParameter("@firstName", TextBox1.Text));
                Edit.Parameters.Add(new SqlParameter("@lastName", TextBox2.Text));
                Edit.Parameters.Add(new SqlParameter("@password", TextBox3.Text));
                Int16 s = Int16.Parse(TextBox4.Text);
                Edit.Parameters.Add(new SqlParameter("@gender", s));
                Edit.Parameters.Add(new SqlParameter("@email", TextBox5.Text));
                Edit.Parameters.Add(new SqlParameter("@address", TextBox6.Text));

                conn.Open();
                Edit.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("myProfile.aspx");
            }
            catch (Exception e1)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");
            }
        }
      
    }
}