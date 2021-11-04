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
    public partial class ViewGrades : System.Web.UI.Page
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
                    SqlCommand comm = new SqlCommand("ViewSubmittedAssignments", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@sid", (Int32)Session["user"]));
                    conn.Open();
                    SqlDataReader rdr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                    int i = 0;
                    while (rdr.Read())
                    {
                        string type = rdr.GetString(rdr.GetOrdinal("type"));
                        string number = rdr.GetInt32(rdr.GetOrdinal("number")) + "";
                        string name = rdr.GetString(rdr.GetOrdinal("name"));
                        string id = rdr.GetInt32(rdr.GetOrdinal("id")) + "";

                        string tmp = type + " " + number + " " + id + " " + name;
                        string txt = type + " " + number + " in " + name;
                        Assignment.DataBind();
                        Assignment.Items.Insert(i, new ListItem(txt, tmp));
                    }
                }
            }
        }

        protected void ViewGrade(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand viewAssignGradesproc = new SqlCommand("viewAssignGrades", conn);
                viewAssignGradesproc.CommandType = CommandType.StoredProcedure;
                int sid = (Int32)Session["user"];
                string tmp = Assignment.SelectedValue;
                string[] arr = new string[4];
                int j = 0;
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == ' ')
                    {
                        j++;
                        continue;
                    }
                    arr[j] += tmp[i];
                }
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@assignnumber", arr[1]));
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@assignType", arr[0]));
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@cid", arr[2]));
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@sid", sid));
                SqlParameter Grade = viewAssignGradesproc.Parameters.Add(new SqlParameter("@assignGrade", SqlDbType.Decimal));
                Grade.Direction = ParameterDirection.Output;
                conn.Open();
                viewAssignGradesproc.ExecuteNonQuery();
                conn.Close();
                Label grade = new Label();
                grade.Text = Grade.Value.ToString();
                form1.Controls.Add(new Literal { Text = "<p style='color:red'>" + "Your Grade is : " + grade.Text + "</p>" });
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data' ) </script>");
            }
        }
    }
}