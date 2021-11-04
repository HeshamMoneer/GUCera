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
    public partial class addAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"]==null||Session["type"]==null||Session["password"]==null||(Int32.Parse(Session["type"].ToString()))!=0|| Session["courseID"]==null)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {

                int courseID = Int16.Parse((string)Session["courseID"]);
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand getCourseName = new SqlCommand("getCourseName", conn);
                getCourseName.CommandType = CommandType.StoredProcedure;
                getCourseName.Parameters.Add(new SqlParameter("@courseID", courseID));
                SqlParameter name = getCourseName.Parameters.Add("@courseName", SqlDbType.VarChar, 10);
                name.Direction = ParameterDirection.Output;

                conn.Open();
                getCourseName.ExecuteNonQuery();
                conn.Close();

                string courseName = name.Value.ToString();

                header.Text = header.Text + courseName;
            }
        }

        protected void Submit(object sender, EventArgs e)
        {
            try
            {
                int Anumber = Int16.Parse(number.Text);
                string Atype = type.Text;
                int AfullGrade = Int16.Parse(fullGrade.Text);
                double Aweight = Double.Parse(weight.Text);
                DateTime Adeadline = DateTime.Parse(deadline.Text);
                string Acontent = content.Text;


                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand assignment = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
                assignment.CommandType = CommandType.StoredProcedure;
                assignment.Parameters.Add(new SqlParameter("@instId", Int16.Parse(Session["user"].ToString())));//to be added through the session
                assignment.Parameters.Add(new SqlParameter("@cid", Session["courseID"]));
                assignment.Parameters.Add(new SqlParameter("@number", Anumber));
                assignment.Parameters.Add(new SqlParameter("@type", Atype));
                assignment.Parameters.Add(new SqlParameter("@fullGrade", AfullGrade));
                assignment.Parameters.Add(new SqlParameter("@weight", Aweight));
                assignment.Parameters.Add(new SqlParameter("@deadline", Adeadline));
                assignment.Parameters.Add(new SqlParameter("@content ", Acontent));

                conn.Open();
                assignment.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("myAcceptedCourses.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");
            }
        }
    }
}