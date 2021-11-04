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
    public partial class enroll : System.Web.UI.Page
    {
        int cid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2|| Session["courses"]==null)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                try
                {
                    cid = Int16.Parse((string)Session["courses"]);
                    string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
                    SqlConnection conn = new SqlConnection(connstr);
                    SqlCommand insts = new SqlCommand("showInstructorTeachCourse", conn);
                    insts.CommandType = CommandType.StoredProcedure;
                    insts.Parameters.Add(new SqlParameter("@cid", cid));
                    conn.Open();
                    SqlDataReader rdr = insts.ExecuteReader(CommandBehavior.CloseConnection);
                    int i = 0;
                    while (rdr.Read())
                    {
                        int instId = rdr.GetInt32(rdr.GetOrdinal("id"));
                        string name = rdr.GetString(rdr.GetOrdinal("name"));

                        inst.DataBind();
                        inst.Items.Insert(i++, new ListItem(instId + " " + name, instId + ""));
                    }
                    conn.Close();

                    SqlCommand getCourseName = new SqlCommand("getCourseName", conn);
                    getCourseName.CommandType = CommandType.StoredProcedure;
                    getCourseName.Parameters.Add(new SqlParameter("@courseID", cid));
                    SqlParameter nameX = getCourseName.Parameters.Add("@courseName", SqlDbType.VarChar, 10);
                    nameX.Direction = ParameterDirection.Output;

                    conn.Open();
                    getCourseName.ExecuteNonQuery();
                    conn.Close();

                    string courseName = nameX.Value.ToString();

                    header.Text = header.Text + courseName;
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('You should not be accessing this page')</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            int instrid = Int32.Parse(inst.SelectedValue);
            int z = (int)Session["user"];
            SqlCommand SIN = new SqlCommand("enrollInCourse", conn);
            SIN.CommandType = CommandType.StoredProcedure;
            SIN.Parameters.Add(new SqlParameter("@sid",z));
            SIN.Parameters.Add(new SqlParameter("@cid",cid));
            SIN.Parameters.Add(new SqlParameter("@instr",instrid));
            conn.Open();
            SIN.ExecuteNonQuery();
            conn.Close();
            if (checkinst(cid,instrid) == true)
            {
               checkcourse(cid);
            }
            else
            {
                Response.Write("<script> alert('This instructor does not teach this course')</script>");
            }

        }

        protected Boolean checkinst(int cid, int instid)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                string query = @"SELECT [dbo].[InstTeachCourse](@inst,@cid) AS TotalEmployees;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@inst", instid));
                cmd.Parameters.Add(new SqlParameter("@cid", cid));
                conn.Open();
                Boolean c1 = (bool)cmd.ExecuteScalar();
                conn.Close();
                if (c1 == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e1)
            {
                Response.Write("<script> alert('Refresh')</script>");
                return false;

            }
        }
        protected void checkcourse(int cid)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                SqlCommand check = new SqlCommand("availableCourses", conn);
                check.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rd = check.ExecuteReader(CommandBehavior.CloseConnection);
                Boolean flag = false;

                while (rd.Read())
                {
                    int temp = (int)rd.GetValue(rd.GetOrdinal("id"));
                    if (cid == temp)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Response.Write("<script> alert('You have to take its prerequisites')</script>");//messages
                    //Response.Redirect("AvaliableCourses.aspx");

                }
                else
                {
                    Response.Write("<script> alert('Enrolled Successfully')</script>");//messages
                    Response.Redirect("AvaliableCourses.aspx");

                }
            }
            catch (Exception e1)
            {
                Response.Write("<script> alert('Refresh')</script>");
            }

        }
    }
}