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
    public partial class SubmitAssignment : System.Web.UI.Page
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
                    SqlCommand com = new SqlCommand("ViewNotYetSubmittedAssignments", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@sid", (Int32)Session["user"]));
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader(CommandBehavior.CloseConnection);
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

        protected void SubmitAssign(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand submitAssignproc = new SqlCommand("submitAssign", conn);
                submitAssignproc.CommandType = CommandType.StoredProcedure;
                conn.Open();
                int sid = (Int32)Session["user"];
                string tmp = Assignment.SelectedValue;
                string[] arr = new string[4];
                int j = 0;
                for(int i = 0; i < tmp.Length; i++)
                {
                    if(tmp[i]==' ')
                    {
                        j++;
                        continue;
                    }
                    arr[j] += tmp[i];
                }
                string cid = arr[2];
                string asstype = arr[0];
                int assnum = Int32.Parse(arr[1]);
                submitAssignproc.Parameters.Add(new SqlParameter("@assignType", asstype));
                submitAssignproc.Parameters.Add(new SqlParameter("@assignnumber", assnum));
                submitAssignproc.Parameters.Add(new SqlParameter("@sid", sid));
                submitAssignproc.Parameters.Add(new SqlParameter("@cid", cid));
                try
                {
                    submitAssignproc.ExecuteNonQuery();
                    Response.Write("<script> alert('Submitted successfully ' ) </script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('This assignment is already submitted or not defined yet ' ) </script>");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data' ) </script>");

            }
        }

       
    }
}