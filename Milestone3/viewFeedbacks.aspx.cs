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
    public partial class viewFeedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 0|| Session["courseID"]==null)
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

                SqlCommand feedback = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
                feedback.CommandType = CommandType.StoredProcedure;
                feedback.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(Session["user"].ToString())));//to be edited when the session is ready
                feedback.Parameters.Add(new SqlParameter("@cid", Session["courseID"]));

                conn.Open();
                SqlDataReader rdr = feedback.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    int number = rdr.GetInt32(rdr.GetOrdinal("number"));
                    string comment = rdr.GetString(rdr.GetOrdinal("comment"));
                    int likes = rdr.GetInt32(rdr.GetOrdinal("numberOfLikes"));

                    Label lbl = new Label();
                    lbl.Text = "Feedback number: " + number +
                    " <br /> Student's comment: " + comment +
                    "<br /> Number of Likes: " + likes + "<br /><br />";
                    lbl.CssClass = "info2";
                    form1.Controls.Add(lbl);
                }
            }
        }
    }
}