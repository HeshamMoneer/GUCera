using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class CreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand CreditCardproc = new SqlCommand("addCreditCard", conn);
            CreditCardproc.CommandType = CommandType.StoredProcedure;
            try
            {
                string number = TextBox1.Text;
                string Holder = TextBox2.Text;
                DateTime expiry = DateTime.Parse(exp.Text);
                string CVV = TextBox4.Text;
                int sid = (int)Session["user"];
                CreditCardproc.Parameters.Add(new SqlParameter("@sid", sid));
                CreditCardproc.Parameters.Add(new SqlParameter("@number", number));
                CreditCardproc.Parameters.Add(new SqlParameter("@cardHolderName", Holder));
                CreditCardproc.Parameters.Add(new SqlParameter("@expiryDate", expiry));
                CreditCardproc.Parameters.Add(new SqlParameter("@cvv", CVV));
                conn.Open();
                CreditCardproc.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("CreditCard.aspx");
            }
            catch (Exception e1)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");

            }

        }
    }
}