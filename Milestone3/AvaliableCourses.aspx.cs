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
    public partial class AvaliableCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 2)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connstr);
                SqlCommand avaliableproc = new SqlCommand("availableCourses", conn);
                avaliableproc.CommandType = CommandType.StoredProcedure;
                avaliableproc.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                conn.Open();
                SqlDataReader rd = avaliableproc.ExecuteReader(CommandBehavior.CloseConnection);
                while (rd.Read())
                {
                    string n = rd.GetString(rd.GetOrdinal("name"));
                    Label coursename = new Label();
                    coursename.Text = "Course Name: " + n + "<br >";
                    coursename.CssClass = "info2";
                    form1.Controls.Add(coursename);

                    Button c = new Button();
                    c.Text = "View";
                    c.Click += action;
                    c.CssClass = "button2";
                    c.CommandName = rd.GetInt32(rd.GetOrdinal("id")) + "";

                    Button enroll = new Button();
                    enroll.Text = "Enroll";
                    enroll.Click += enrollaction;
                    enroll.CommandName += rd.GetInt32(rd.GetOrdinal("id")) + "";
                    enroll.CssClass = "button2";

                    form1.Controls.Add(c);
                    form1.Controls.Add(enroll);
                }
            }
            
        }
        protected void action(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                SqlCommand viewProc = new SqlCommand("courseInformation", conn);
                viewProc.CommandType = CommandType.StoredProcedure;
                viewProc.Parameters.Add(new SqlParameter("@id", Int16.Parse(((Button)sender).CommandName)));
                conn.Open();
                SqlDataReader rd2 = viewProc.ExecuteReader(CommandBehavior.CloseConnection);
                while (rd2.Read())

                {
                    int courseid = (int)rd2.GetValue(rd2.GetOrdinal("id"));
                    int CH = (int)rd2.GetValue(rd2.GetOrdinal("creditHours"));
                    string CD = rd2.GetString(rd2.GetOrdinal("courseDescription"));
                    decimal Price = (decimal)rd2.GetValue(rd2.GetOrdinal("price"));
                    string con = rd2.GetString(rd2.GetOrdinal("content"));
                    int ID = (int)rd2.GetValue(rd2.GetOrdinal("instructorId"));
                    int AID = (int)rd2.GetValue(rd2.GetOrdinal("adminId"));
                    string instName = rd2.GetString(rd2.GetOrdinal("firstName")) +" "+ rd2.GetString(rd2.GetOrdinal("lastName"));
                    string courseName = rd2.GetString(rd2.GetOrdinal("name"));
                    bool acc = rd2.GetBoolean(rd2.GetOrdinal("accepted"));


                    String tmp = "<br>" + "The details of the course you clicked:- <br/> " +
                    "Name: "+courseName + "<br>"+
                    "ID: "+ courseid + "<br>" +
                    "Accepted: "+ acc+ "<br>"+
                    "Credit Hours: " + CH.ToString() + "<br>"+
                    "Course Description: " + CD + "<br>" +
                    "Price: € " + Price.ToString() + "<br>" +
                    "Content: " + con + "<br>" +
                    "Instructor: " + ID + ") " + instName+"<br>" +
                    "Adder Admin ID: " + AID.ToString() + "<br>";
                    ViewCourse.Text = tmp;


                }
            }
            catch (Exception e1)
            {
                Response.Write("<script> alert('Refersh the Page')</script>");
            }

        }





        protected void enrollaction(object sender, EventArgs e)
        {
            Session["courses"] = ((Button)sender).CommandName;
            Response.Redirect("enroll.aspx");

        }

    }
}