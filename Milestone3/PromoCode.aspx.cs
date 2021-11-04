using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class PromoCode : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connstr);
                SqlCommand viewpromoproc = new SqlCommand("viewPromocode", conn);
                viewpromoproc.CommandType = CommandType.StoredProcedure;
                try
                {
                    int sid = (int)Session["user"];
                    viewpromoproc.Parameters.Add(new SqlParameter("@sid", sid));
                    conn.Open();
                    SqlDataReader rd = viewpromoproc.ExecuteReader(CommandBehavior.CloseConnection);
                    table.Append("<table border = '1'>");
                    table.Append("<tr><th>code</th><th>isuueDate</th><th>expiryDate</th><th>discount</th><th>adminId</th>");
                    table.Append("</tr>");
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {

                            String code = rd.GetString(rd.GetOrdinal("code"));
                            DateTime issue = rd.GetDateTime(rd.GetOrdinal("isuueDate"));
                            DateTime expiryDate = rd.GetDateTime(rd.GetOrdinal("expiryDate"));
                            Decimal discount = (decimal)rd.GetValue(rd.GetOrdinal("discount"));
                            int aid = (int)rd.GetValue(rd.GetOrdinal("adminId"));

                            table.Append("<tr>");
                            table.Append("<td>" + rd[0] + "</td>");
                            table.Append("<td>" + rd[1] + "</td>");
                            table.Append("<td>" + rd[2] + "</td>");
                            table.Append("<td>" + rd[3] + "</td>");
                            table.Append("<td>" + rd[4] + "</td>");
                            table.Append("</tr>");


                        }
                    }

                    table.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                    conn.Close();
                }
                catch (Exception e1)
                {
                    Response.Write("<script> alert('Please Enter Valid Data')</script>");
                }
            }
        }
    }
}