using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class ViewCertificates : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                if (!IsPostBack)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand com = new SqlCommand("ViewCoursesCertified", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@sid", (Int32)Session["user"]));
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                    int i = 0;
                    while (rdr.Read())
                    {
                        string id = rdr.GetInt32(rdr.GetOrdinal("id")) + "";
                        string name = rdr.GetString(rdr.GetOrdinal("name"));

                        CourseId.DataBind();
                        CourseId.Items.Insert(i++, new ListItem(id + " " + name, id));
                    }
                }
            }
        }

        protected void ViewCertificate(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewCertificateproc = new SqlCommand("viewCertificate", conn);
            viewCertificateproc.CommandType = CommandType.StoredProcedure;
            conn.Open();
            int sid = (Int32)Session["user"];
            string cid = CourseId.SelectedValue;
            if (cid == "")
            {
                Response.Redirect("ViewCertificates.aspx");

            }
            else
            {
                try
                {
                    viewCertificateproc.Parameters.Add(new SqlParameter("@cid", cid));
                    viewCertificateproc.Parameters.Add(new SqlParameter("@sid", sid));
                    SqlDataReader rdr = viewCertificateproc.ExecuteReader(CommandBehavior.CloseConnection);
                    //  Response.Redirect("Assignments.aspx");
                    int k = 0;

                    while (rdr.Read())
                    {
                        if (k == 0)
                        {
                            table.Append("<table border = '1'>");
                            table.Append("<tr> <th> Student ID </th> <th> Course ID  </th> <th> Issue Date </th> <th> Grade </th> </tr>");
                        }
                        int studentid = (Int32)rdr[0];
                        int courseid = (Int32)rdr[1];
                        DateTime time = (DateTime)rdr[2];
                        decimal grade = (decimal)rdr[3];
                        table.Append("<tr>");
                        table.Append("<td>" + studentid + "</td>");
                        table.Append("<td>" + courseid + "</td>");
                        table.Append("<td>" + time + "</td>");
                        table.Append("<td>" + grade + "</td>");
                        table.Append("</tr>");
                        k++;

                    }
                    if (k == 0)
                    {
                        table.Append("You have no certifications in this course ");
                    }
                    form1.Controls.Add(new Literal { Text = table.ToString() });
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('Please Enter Valid Data' ) </script>");

                }


            }
        }
    }
}