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
    public partial class Assignments : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                if (!IsPostBack) {
                    string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand com = new SqlCommand("ViewMyCourses", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@sid", Session["user"].ToString()));
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                    int i = 0;
                    while (rdr.Read())
                    {
                        int cid = rdr.GetInt32(rdr.GetOrdinal("id"));
                        string name = rdr.GetString(rdr.GetOrdinal("name"));

                        CourseId.DataBind();
                        CourseId.Items.Insert(i++, new ListItem(cid + " " + name, cid + ""));

                    }
                }
            }
        }

        protected void ViewAssignments(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewAssignproc = new SqlCommand("viewAssign", conn);
            viewAssignproc.CommandType = CommandType.StoredProcedure;
            conn.Open();
            string sid = Session["user"].ToString() ;
            string cid = CourseId.SelectedValue;
            if (cid == "")
            {
                //Response.Redirect("ViewAssignments.aspx"); 
                Response.Write("<script> alert('Please Enter Valid Data' ) </script>");

            }
            else
            {
                try
                {
                    viewAssignproc.Parameters.Add(new SqlParameter("@courseId", cid));
                    viewAssignproc.Parameters.Add(new SqlParameter("@Sid ", sid));
                    SqlDataReader rdr = viewAssignproc.ExecuteReader(CommandBehavior.CloseConnection);
                    //  Response.Redirect("Assignments.aspx");
                    int k = 0;

                    while (rdr.Read())
                    {
                        if (k == 0)
                        {
                            table.Append("<table border = '1'>");
                            table.Append("<tr> <th> CourseId </th> <th> Assignment number </th> <th> Assignment type </th> <th> Assignment content</th> </tr>");
                        }
                        int courseId = (Int32)rdr[0];
                        int assignmentnumber = (Int32)rdr[1];
                        String assignmenttype = rdr.GetString(rdr.GetOrdinal("type"));
                        String assignmentcontent = rdr.GetString(rdr.GetOrdinal("content"));
                        table.Append("<tr>");
                        table.Append("<td>" + courseId + "</td>");
                        table.Append("<td>" + assignmentnumber + "</td>");
                        table.Append("<td>" + assignmenttype + "</td>");
                        table.Append("<td>" + assignmentcontent + "</td>");
                        table.Append("</tr>");
                        k++;

                    }
                    if (k == 0)
                    {
                        table.Append("No assignments to show here");
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