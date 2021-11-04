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
    public partial class AddFeedback : System.Web.UI.Page
    {
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
                    SqlCommand com = new SqlCommand("ViewMyCourses", conn);
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

        protected void Add_Feedback(object sender, EventArgs e)
        {
            try {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand addFeedbackproc = new SqlCommand("addFeedback", conn);
                addFeedbackproc.CommandType = CommandType.StoredProcedure;
                string comment = Feedback.Text;
                int cid = Int32.Parse(CourseId.SelectedValue);
                int sid = (Int32)Session["user"];
                addFeedbackproc.Parameters.Add(new SqlParameter("@comment", comment));
                addFeedbackproc.Parameters.Add(new SqlParameter("@cid", cid));
                addFeedbackproc.Parameters.Add(new SqlParameter("@sid", sid));
                conn.Open();
                addFeedbackproc.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script> alert('Feedback Added Successfully')</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");
            }
        }
        
    }
}