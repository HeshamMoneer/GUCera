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
    public partial class myAcceptedCourses : System.Web.UI.Page
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

                SqlCommand courses = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);
                courses.CommandType = CommandType.StoredProcedure;

                int instructorID = Int16.Parse(Session["user"].ToString()); //to be retrieved from the session 
                courses.Parameters.Add(new SqlParameter("@instrId", instructorID));

                conn.Open();
                SqlDataReader rdr = courses.ExecuteReader(CommandBehavior.CloseConnection);
                int i = 0;
                while (rdr.Read())
                {
                    int courseID = rdr.GetInt32(rdr.GetOrdinal("id"));
                    string courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    int creditHrs = rdr.GetInt32(rdr.GetOrdinal("creditHours"));

                    Label lbl = new Label();
                    lbl.Text = "Course ID: " + courseID + "<br />" +
                    "Course name: " + courseName + "<br />" +
                    "Credit hours: " + creditHrs + "<br />";
                    lbl.CssClass = "info";
                    lbl.Style.Add("text-align", "left");
                    form1.Controls.Add(lbl);

                    TextBox contentTxt = new TextBox();
                    contentTxt.CssClass = "labels";
                    contentTxt.ID = "content" + i;
                    form1.Controls.Add(contentTxt);

                    Button content = new Button();
                    content.Text = "Update course content";
                    content.CommandName = courseID + "," + i;
                    content.Click += UpdateCourseContent;
                    content.CssClass = "button2";
                    form1.Controls.Add(content);

                    addLine();

                    TextBox descriptionTxt = new TextBox();
                    descriptionTxt.CssClass = "labels";
                    descriptionTxt.ID = "description" + i;
                    form1.Controls.Add(descriptionTxt);

                    Button description = new Button();
                    description.Text = "Update course description";
                    description.CommandName = courseID + "," + i;
                    description.Click += UpdateCourseDescription;
                    description.CssClass = "button2";
                    form1.Controls.Add(description);

                    addLine();

                    DropDownList instTxt = new DropDownList();
                    instTxt.ID = "addInst" + i;
                    string connStr2 = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                    SqlConnection conn2 = new SqlConnection(connStr2);
                    SqlCommand getInstr = new SqlCommand("ShowInstructorsNotTeachingCourse", conn2);
                    getInstr.CommandType = CommandType.StoredProcedure;
                    getInstr.Parameters.Add(new SqlParameter("@cid", courseID));

                    conn2.Open();
                    SqlDataReader rdr2 = getInstr.ExecuteReader(CommandBehavior.CloseConnection);
                    int i2 = 0;
                    while (rdr2.Read())
                    {
                        int instID = rdr2.GetInt32(rdr2.GetOrdinal("id"));
                        string instName = rdr2.GetString(rdr2.GetOrdinal("name"));
                        string txt = instID + " " + instName;

                        instTxt.DataBind();
                        instTxt.Items.Insert(i2++, new ListItem(txt, instID + ""));
                    }
                    instTxt.CssClass = "dropDown";
                    form1.Controls.Add(instTxt);

                    Button inst = new Button();
                    inst.Text = "Add another instructor to course";
                    inst.CommandName = courseID + "," + i;
                    inst.Click += AddAnotherInstructor;
                    inst.CssClass = "button2";
                    form1.Controls.Add(inst);

                    addLine();

                    DropDownList preTxt = new DropDownList();
                    preTxt.ID = "pre" + i;
                    string connStr3 = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                    SqlConnection conn3 = new SqlConnection(connStr3);
                    SqlCommand getCourses = new SqlCommand("ShowNonPrerequisitedCourses", conn3);
                    getCourses.CommandType = CommandType.StoredProcedure;
                    getCourses.Parameters.Add(new SqlParameter("@cid", courseID));

                    conn3.Open();
                    SqlDataReader rdr3 = getCourses.ExecuteReader(CommandBehavior.CloseConnection);
                    int i3 = 0;
                    while (rdr3.Read())
                    {
                        int cid = rdr3.GetInt32(rdr3.GetOrdinal("id"));
                        string cname = rdr3.GetString(rdr3.GetOrdinal("name"));
                        string txt = cid + " " + cname;

                        preTxt.DataBind();
                        preTxt.Items.Insert(i3++, new ListItem(txt, cid + ""));
                    }
                    preTxt.CssClass = "dropDown";
                    form1.Controls.Add(preTxt);


                    Button pre = new Button();
                    pre.Text = "Define course prerequisites";
                    pre.CommandName = courseID + "," + i;
                    pre.Click += DefineCoursePrerequisites;
                    pre.CssClass = "button2";
                    form1.Controls.Add(pre);

                    addLine();

                    Button viewAssign = new Button();
                    viewAssign.Text = "View submitted assignments";
                    viewAssign.CommandName = courseID + "";
                    viewAssign.Click += ViewSubmittedAssignments;
                    viewAssign.CssClass = "button2";
                    form1.Controls.Add(viewAssign);

                    Button assignment = new Button();
                    assignment.Text = "Add assignment to the course";
                    assignment.CommandName = courseID + "";
                    assignment.Click += AddAssignment;
                    assignment.CssClass = "button2";
                    form1.Controls.Add(assignment);

                    Button feedback = new Button();
                    feedback.Text = "View students feedbacks";
                    feedback.CommandName = courseID + "";
                    feedback.Click += ViewFeedbacks;
                    feedback.CssClass = "button2";
                    form1.Controls.Add(feedback);

                    addLine();
                    addLine();
                    addLine();

                    i++;
                }
            }
        }

        protected void UpdateCourseContent(object sender, EventArgs e)
        {
            string tmp = ((Button)sender).CommandName;
            bool f = false;
            string cidX = "";
            string iX = "";
            for(int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == ',')
                {
                    f = true;
                    continue;
                }
                if (f)
                {
                    iX += tmp[i];
                }
                else
                {
                    cidX += tmp[i];
                }
            }
            int cid = Int32.Parse(cidX);
            int j = Int32.Parse(iX);
            string content = ((TextBox)form1.FindControl("content"+j)).Text;

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand updateContent = new SqlCommand("UpdateCourseContent", conn);
            updateContent.CommandType = CommandType.StoredProcedure;

            updateContent.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(Session["user"].ToString()))); //instID to be edited with session
            updateContent.Parameters.Add(new SqlParameter("@courseId", cid));
            updateContent.Parameters.Add(new SqlParameter("@content", content));

            conn.Open();
            updateContent.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("myAcceptedCourses.aspx");
        }

        protected void UpdateCourseDescription(object sender, EventArgs e)
        {
            string tmp = ((Button)sender).CommandName;
            bool f = false;
            string cidX = "";
            string iX = "";
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == ',')
                {
                    f = true;
                    continue;
                }
                if (f)
                {
                    iX += tmp[i];
                }
                else
                {
                    cidX += tmp[i];
                }
            }
            int cid = Int32.Parse(cidX);
            int j = Int32.Parse(iX);
            string description = ((TextBox)form1.FindControl("description" + j)).Text;

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand updateDescription = new SqlCommand("UpdateCourseDescription", conn);
            updateDescription.CommandType = CommandType.StoredProcedure;

            updateDescription.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(Session["user"].ToString()))); //instID to be edited with session
            updateDescription.Parameters.Add(new SqlParameter("@courseId", cid));
            updateDescription.Parameters.Add(new SqlParameter("@courseDescription", description));

            conn.Open();
            updateDescription.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("myAcceptedCourses.aspx");
        }

        protected void AddAnotherInstructor(object sender, EventArgs e)
        {
            try
            {
                string tmp = ((Button)sender).CommandName;
                bool f = false;
                string cidX = "";
                string iX = "";
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == ',')
                    {
                        f = true;
                        continue;
                    }
                    if (f)
                    {
                        iX += tmp[i];
                    }
                    else
                    {
                        cidX += tmp[i];
                    }
                }
                int cid = Int32.Parse(cidX);
                int j = Int32.Parse(iX);
                int instId = Int32.Parse(((DropDownList)form1.FindControl("addInst" + j)).SelectedValue);

                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand addInst = new SqlCommand("AddAnotherInstructorToCourse", conn);
                addInst.CommandType = CommandType.StoredProcedure;
                addInst.Parameters.Add(new SqlParameter("@insid", instId));
                addInst.Parameters.Add(new SqlParameter("@cid", cid));
                addInst.Parameters.Add(new SqlParameter("@adderIns", Session["user"]));

                conn.Open();
                addInst.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("myAcceptedCourses.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Wrong entry')</script>");
            }
        }

        protected void DefineCoursePrerequisites(object sender, EventArgs e)
        {
            try
            {
                string tmp = ((Button)sender).CommandName;
                bool f = false;
                string cidX = "";
                string iX = "";
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == ',')
                    {
                        f = true;
                        continue;
                    }
                    if (f)
                    {
                        iX += tmp[i];
                    }
                    else
                    {
                        cidX += tmp[i];
                    }
                }
                int cid = Int32.Parse(cidX);
                int j = Int32.Parse(iX);
                int preCid = Int32.Parse(((DropDownList)form1.FindControl("pre" + j)).SelectedValue);

                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand addPrerequisite = new SqlCommand("DefineCoursePrerequisites", conn);
                addPrerequisite.CommandType = CommandType.StoredProcedure;
                addPrerequisite.Parameters.Add(new SqlParameter("@prerequsiteId", preCid));
                addPrerequisite.Parameters.Add(new SqlParameter("@cid", cid));

                conn.Open();
                addPrerequisite.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("myAcceptedCourses.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Wrong entry')</script>");

            }
        }

        protected void AddAssignment(object sender, EventArgs e)
        {
            Session["courseID"] = ((Button)sender).CommandName;
            Response.Redirect("addAssignment.aspx");
        }

        protected void ViewFeedbacks(object sender, EventArgs e)
        {
            Session["courseID"] = ((Button)sender).CommandName;
            Response.Redirect("viewFeedbacks.aspx");
        }

        protected void ViewSubmittedAssignments(object sender, EventArgs e)
        {
            Session["courseID"] = ((Button)sender).CommandName;
            Response.Redirect("studentsAssignments.aspx");
        }

        protected void addLine()
        {
            Label x = new Label();
            x.Text = "<br />";
            form1.Controls.Add(x);
        }
    }
}