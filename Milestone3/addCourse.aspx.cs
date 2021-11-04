using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class addCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 0)
            {
                Response.Redirect("unauthorized.aspx");

            }
        }

        protected void submit_click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int creditHrs = Int16.Parse(creditHours.Text);
                string courseName = name.Text;
                double coursePrice = Double.Parse(price.Text);
                int instructorID = Int16.Parse(Session["user"].ToString()); //to be retrieved from the session

                SqlCommand addCourse = new SqlCommand("InstAddCourse", conn);
                addCourse.CommandType = CommandType.StoredProcedure;
                addCourse.Parameters.Add(new SqlParameter("@creditHours", creditHrs));
                addCourse.Parameters.Add(new SqlParameter("@name", courseName));
                addCourse.Parameters.Add(new SqlParameter("@price", coursePrice));
                addCourse.Parameters.Add(new SqlParameter("@instructorId", instructorID));

                conn.Open();
                addCourse.ExecuteNonQuery();
                conn.Close();

                Response.Write("<script> alert ('Added Successfully') </script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Etner Valid Data')</script>");
            }
        }
    }
}