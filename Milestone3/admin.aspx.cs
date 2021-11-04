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

namespace Admin
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 1)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                if (!IsPostBack)
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand com = new SqlCommand("AdminViewNonAcceptedCourses", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlCommand com2 = new SqlCommand("ShowAllStudent", conn);
                    com2.CommandType = CommandType.StoredProcedure;
                    SqlCommand com3 = new SqlCommand("ShowNonAssignedPromoCodes", conn);
                    com3.CommandType = CommandType.StoredProcedure;
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
                    conn.Close();

                    conn.Open();
                    rdr = com2.ExecuteReader(CommandBehavior.CloseConnection);
                    i = 0;
                    while (rdr.Read())
                    {
                        string id = rdr.GetInt32(rdr.GetOrdinal("id")) + "";
                        string name = rdr.GetString(rdr.GetOrdinal("name"));

                        SidPromo.DataBind();
                        SidPromo.Items.Insert(i++, new ListItem(id + " " + name, id));

                    }
                    conn.Close();

                    conn.Open();
                    rdr = com3.ExecuteReader(CommandBehavior.CloseConnection);
                    i = 0;
                    while (rdr.Read())
                    {
                        string code = rdr.GetString(rdr.GetOrdinal("code"));

                        PromocodeId.DataBind();
                        PromocodeId.Items.Insert(i++, new ListItem(code, code));

                    }


                }
            }
        }

        protected void AllCourses_Click(object sender, EventArgs e)
        {
            StringBuilder table = new StringBuilder();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AdminViewAllCourses = new SqlCommand("AdminViewAllCourses", conn);


            AdminViewAllCourses.CommandType = CommandType.StoredProcedure;


            conn.Open();

            SqlDataReader rdr = AdminViewAllCourses.ExecuteReader(CommandBehavior.CloseConnection);

            int k = 0;

            while (rdr.Read())
            {
                if (k == 0)
                {
                    table.Append("<table border = '1'>");
                    table.Append("</th> <th> id </th>" +
                        "</th> <th> name </th>" +
                        " </th> <th> credit hours </th >" +
                        " </th><th> price</th>" +
                        " </th><th> content</th>" +
                         " </th><th> accepted</th> "
                        );
                }
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                int creaditHours = (Int32)rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                String content;
                try
                {
                    content = rdr.GetString(rdr.GetOrdinal("content"));
                }
                catch (Exception e1)
                {
                    content = "";
                }
                bool accepted = (bool)rdr.GetBoolean(rdr.GetOrdinal("accepted")); ;
                int cid = rdr.GetInt32(rdr.GetOrdinal("id"));


                table.Append("<tr>");
                table.Append("<td>" + cid + "</td>");
                table.Append("<td>" + name + "</td>");
                table.Append("<td>" + creaditHours + "</td>");
                table.Append("<td>" + price + "</td>");
                table.Append("<td>" + content + "</td>");
                table.Append("<td>" + accepted + "</td>");


                table.Append("</tr>");
                k++;

            }
            if (k == 0)
            {
                table.Append("no courses available to show");
            }
            
            Panel3.Controls.Add(new Literal { Text = table.ToString()});
            Panel3.CssClass = "tables";
        }

    
        protected void notAccepted_Click(object sender, EventArgs e)
        {
            StringBuilder table = new StringBuilder();
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AdminViewNonAcceptedCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
            AdminViewNonAcceptedCourses.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataReader rdr = AdminViewNonAcceptedCourses.ExecuteReader(CommandBehavior.CloseConnection);
            List<HyperLink> coursesHyperLinks = new List<HyperLink>();

            int k = 0;

            while (rdr.Read())
            {
                if (k == 0)
                {
                    table.Append("<table border = '1'>");
                    table.Append("</th> <th> id </th>" + 
                        "</th> <th> name </th>" +
                        " </th> <th> credit hours </th >" +
                        " </th><th> price</th>" +
                        " </th><th> content</th>" 
                        );
                }
                String name = rdr.GetString(rdr.GetOrdinal("name"));
                int creaditHours = (Int32)rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                int cid = rdr.GetInt32(rdr.GetOrdinal("id"));
                String content;
                try
                {
                    content = rdr.GetString(rdr.GetOrdinal("content"));
                }
                catch (Exception e1)
                {
                    content = "";
                }


                table.Append("<tr>");
                table.Append("<td>" + cid + "</td>");
                table.Append("<td>" + name + "</td>");
                table.Append("<td>" + creaditHours + "</td>");
                table.Append("<td>" + price + "</td>");
                table.Append("<td>" + content + "</td>");


                table.Append("</tr>");
                k++;

            }
            if (k == 0)
            {
                table.Append("no courses available to show");
            }
            Panel2.Controls.Add(new Literal { Text = table.ToString() });
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand AdminAcceptRejectCourse = new SqlCommand("AdminAcceptRejectCourse", conn);
                AdminAcceptRejectCourse.CommandType = CommandType.StoredProcedure;

                int x = Int16.Parse(Session["user"].ToString());
                int y = Int16.Parse(CourseId.SelectedValue);

                CourseId.Items.Remove(CourseId.SelectedItem);

                Label acceptstat = new Label();


                try
                {
                    AdminAcceptRejectCourse.Parameters.Add(new SqlParameter("@AdminId", x));
                    AdminAcceptRejectCourse.Parameters.Add(new SqlParameter("@CourseId", y));

                    acceptstat.Text = "course accepted";
                    conn.Open();
                    AdminAcceptRejectCourse.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    acceptstat.Text = "can not accepte course";
                }

                // Response.Write("<script> alert('" + acceptstat.Text +"') </script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");
            }


        }

        protected void createPromocode_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand AdminCreatePromocode = new SqlCommand("AdminCreatePromocode", conn);
                AdminCreatePromocode.CommandType = CommandType.StoredProcedure;

                string cod = code.Text;
                DateTime y = DateTime.Parse(issueDate.Text);
                DateTime z = DateTime.Parse(expiryDate.Text);
                double d = double.Parse(discount.Text);
                int x = Int16.Parse(Session["user"].ToString());
                Label createPromo = new Label();

                try
                {
                    AdminCreatePromocode.Parameters.Add(new SqlParameter("@code", cod));
                    AdminCreatePromocode.Parameters.Add(new SqlParameter("@isuueDate", y));
                    AdminCreatePromocode.Parameters.Add(new SqlParameter("@expiryDate", z));
                    AdminCreatePromocode.Parameters.Add(new SqlParameter("@discount", d));
                    AdminCreatePromocode.Parameters.Add(new SqlParameter("@adminId", x));

                    createPromo.Text = "Promo code created successfull";


                    conn.Open();
                    AdminCreatePromocode.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {

                    createPromo.Text = "can not create promo code";

                }
                Response.Write("<script> alert('" + createPromo.Text + "') </script>");
            }
            catch (Exception ex)
            {
                Response.Write("enter valid data");
            }
        }

        protected void logout_click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["type"] = null;
            Session["password"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Issue_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand AdminIssuePromocodeToStudent = new SqlCommand("AdminIssuePromocodeToStudent", conn);
                AdminIssuePromocodeToStudent.CommandType = CommandType.StoredProcedure;


                int x = Int16.Parse(SidPromo.SelectedValue);
                string y = PromocodeId.SelectedValue;

                //SidPromo.Items.Remove(SidPromo.SelectedItem);
                PromocodeId.Items.Remove(PromocodeId.SelectedItem);
                Label issueState = new Label();


                try
                {
                    AdminIssuePromocodeToStudent.Parameters.Add(new SqlParameter("@sid", x));
                    AdminIssuePromocodeToStudent.Parameters.Add(new SqlParameter("@pid", y));
                    issueState.Text = "Promo code issued succesfully";

                    conn.Open();
                    AdminIssuePromocodeToStudent.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    issueState.Text = "can not issue promo code";


                }
                Response.Write("<script> alert('" + issueState.Text + "') </script>");
            }
            catch (Exception ex)
            {
                Response.Write("enter valid data");
            }
        }

      
    }
    }
