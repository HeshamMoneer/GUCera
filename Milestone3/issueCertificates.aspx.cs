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
    public partial class issueCertificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 0)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand data = new SqlCommand("ShowCoursesAndStudents", conn);
                data.CommandType = CommandType.StoredProcedure;
                data.Parameters.Add(new SqlParameter("@instID", Int16.Parse(Session["user"].ToString())));//to be edited by the session

                conn.Open();
                SqlDataReader rdr = data.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    int sid = rdr.GetInt32(rdr.GetOrdinal("studentID"));
                    int cid = rdr.GetInt32(rdr.GetOrdinal("courseID"));
                    string sname = rdr.GetString(rdr.GetOrdinal("studentName"));
                    string cname = rdr.GetString(rdr.GetOrdinal("courseName"));

                    Label lbl = new Label();
                    lbl.Text = "Student ID: " + sid + "<br />" +
                    "Student Name: " + sname + "<br />" +
                    "Course ID: " + cid + "<br />" +
                    "Course Name: " + cname + "<br />";
                    lbl.CssClass = "info2";
                    form1.Controls.Add(lbl);

                    Button certify = new Button();
                    certify.Text = "Calculate grade Certify this studnet in this course";
                    certify.CommandName = sid + "," + cid;
                    certify.Click += Certify;
                    certify.CssClass = "button2";
                    form1.Controls.Add(certify);

                    Label line1 = new Label();
                    line1.Text = "<br /><br />";
                    form1.Controls.Add(line1);

                }
            }
        }
        protected void Certify(object sender, EventArgs e)
        {
                string tmp = ((Button)sender).CommandName;
                string sidtmp = "";
                string cidtmp = "";
                bool f = false;
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == ',')
                    {
                        f = true;
                        continue;
                    }
                    if (f)
                    {
                        cidtmp += tmp[i];
                    }
                    else
                    {
                        sidtmp += tmp[i];
                    }
                }
                int sid = Int16.Parse(sidtmp);
                int cid = Int16.Parse(cidtmp);
                int insid = Int16.Parse(Session["user"].ToString()); //to be edited by the session

                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand c1 = new SqlCommand("calculateFinalGrade", conn);
                c1.CommandType = CommandType.StoredProcedure;
                c1.Parameters.Add(new SqlParameter("@sid", sid));
                c1.Parameters.Add(new SqlParameter("@cid", cid));
                c1.Parameters.Add(new SqlParameter("@insId", insid));

                SqlCommand c2 = new SqlCommand("InstructorIssueCertificateToStudent", conn);
                c2.CommandType = CommandType.StoredProcedure;
                c2.Parameters.Add(new SqlParameter("@sid", sid));
                c2.Parameters.Add(new SqlParameter("@cid", cid));
                c2.Parameters.Add(new SqlParameter("@insId", insid));
                c2.Parameters.Add(new SqlParameter("@issueDate", DateTime.Now));
                SqlParameter check = c2.Parameters.Add(new SqlParameter("@check", SqlDbType.Int));
                check.Direction = ParameterDirection.Output;

                conn.Open();
                c1.ExecuteNonQuery();
                c2.ExecuteNonQuery();
                conn.Close();

            
            if (check.Value.ToString() == "1")
            {
                Response.Write("<script> alert('This Studnet has not yet passed this course')</script>");
            }
            else
            {

               Response.Redirect("issueCertificates.aspx");
            }
        }
    }
}