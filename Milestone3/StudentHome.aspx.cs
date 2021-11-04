using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                string connstr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connstr);
                SqlCommand viewproc = new SqlCommand("viewMyProfile", conn);
                viewproc.CommandType = CommandType.StoredProcedure;
                int sid = Int32.Parse(Session["user"].ToString());
                viewproc.Parameters.Add(new SqlParameter("@id", sid));
                conn.Open();
                SqlDataReader rd = viewproc.ExecuteReader(CommandBehavior.CloseConnection);


                while (rd.Read())
                {
                    string g = "";
                    string FN = rd.GetString(rd.GetOrdinal("firstName"));
                    string LN = rd.GetString(rd.GetOrdinal("lastName"));
                    string PA = rd.GetString(rd.GetOrdinal("password"));
                    string EM = rd.GetString(rd.GetOrdinal("email"));
                    string ADD = rd.GetString(rd.GetOrdinal("address"));
                    String upid = rd.GetValue(rd.GetOrdinal("id")).ToString();
                    String upgpa = rd.GetValue(rd.GetOrdinal("GPA")).ToString();
                    Byte[] gender = (byte[])rd.GetSqlBinary(rd.GetOrdinal("gender"));
                    if (gender[0] == 0)
                    {
                        g = "female";
                        avatar.Attributes["src"] = "Images/female.png";
                    }
                    else
                    {
                        g = "male";
                    }
                    info.Text = "ID: " + upid + "<br >" +
                    "GPA: " + upgpa + "<br >" +
                    "First Name: " + FN + "<br >" +
                    "Last Name: " + LN + "<br >" +
                    "Password: " + PA + "<br >" +
                    "Email: " + EM + "<br >" +
                    "Address: " + ADD + "<br >" +
                    "Gender: " + g + "<br >";

                }
                conn.Close();
            }
        }

        protected void logoutButton(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["type"] = null;
            Session["password"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void edit_click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx");
        }
    }
}