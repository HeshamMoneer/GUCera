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
    public partial class home : System.Web.UI.Page
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

                SqlCommand updateRate = new SqlCommand("updateInstructorRate", conn);
                updateRate.CommandType = CommandType.StoredProcedure;
                updateRate.Parameters.Add(new SqlParameter("@insid", Int16.Parse(Session["user"].ToString()))); //to be added with the session


                SqlCommand viewProfile = new SqlCommand("ViewInstructorProfile", conn);
                viewProfile.CommandType = CommandType.StoredProcedure;
                viewProfile.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(Session["user"].ToString()))); //to be added with the session

                conn.Open();
                updateRate.ExecuteNonQuery();
                SqlDataReader rdr = viewProfile.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    string g = "";
                    string firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    string lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                    Byte[] gender = (byte[])rdr.GetSqlBinary(rdr.GetOrdinal("gender"));
                    if (gender[0] == 0)
                    {
                        g = "female";
                        Avatar.Attributes["src"] = "Images/female.png";
                    }
                    else
                    {
                        g = "male";
                    }

                    string email = rdr.GetString(rdr.GetOrdinal("email"));
                    string address = rdr.GetString(rdr.GetOrdinal("address"));
                    decimal rating;
                    try
                    {
                        rating = rdr.GetDecimal(rdr.GetOrdinal("rating"));
                    }
                    catch (Exception m)
                    {
                        rating = 0;
                    }

                    info.Text = "First Name: " + firstName + "<br />" +
                    "Last Name: " + lastName + "<br />" +
                    "Gender: " + g + "<br />" +
                    "Email: " + email + "<br />" +
                   "Address: " + address + "<br />" +
                    "Rating: " + rating + "<br />";

                }
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["type"] = null;
            Session["password"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}