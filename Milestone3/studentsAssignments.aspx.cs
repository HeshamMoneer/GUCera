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
    public partial class studentsAssignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["type"] == null || Session["password"] == null || (Int32.Parse(Session["type"].ToString())) != 0|| Session["courseID"]==null)
            {
                Response.Redirect("unauthorized.aspx");
            }
            else {
                int courseID = Int16.Parse((string)Session["courseID"]);
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand getCourseName = new SqlCommand("getCourseName", conn);
                getCourseName.CommandType = CommandType.StoredProcedure;
                getCourseName.Parameters.Add(new SqlParameter("@courseID", courseID));
                SqlParameter name = getCourseName.Parameters.Add("@courseName", SqlDbType.VarChar, 10);
                name.Direction = ParameterDirection.Output;

                conn.Open();
                getCourseName.ExecuteNonQuery();
                conn.Close();

                string courseName = name.Value.ToString();

                header.Text = header.Text + courseName;

                //Session["courseID"] = null;

                SqlCommand viewAssignments = new SqlCommand("InstructorViewAssignmentsStudents", conn);
                viewAssignments.CommandType = CommandType.StoredProcedure;
                viewAssignments.Parameters.Add(new SqlParameter("@cid", courseID));
                viewAssignments.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(Session["user"].ToString()))); //session

                conn.Open();
                SqlDataReader rdr = viewAssignments.ExecuteReader(CommandBehavior.CloseConnection);
                int i = 0;
                while (rdr.Read())
                {
                    int sid = rdr.GetInt32(rdr.GetOrdinal("sid"));
                    int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                    int assignmentNumber = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                    string assignmenttype = rdr.GetString(rdr.GetOrdinal("assignmenttype"));
                    decimal grade;


                    try { grade = rdr.GetDecimal(rdr.GetOrdinal("grade")); }
                    catch (Exception e1) { grade = 0; }

                    Label data = new Label();
                    data.Text = "Student ID: " + sid + "<br />" +
                                "Course ID: " + cid + "<br />" +
                                "Assignment Number: " + assignmentNumber + "<br />" +
                                "Assignment Type: " + assignmenttype + "<br />" +
                                "Grade: " + grade + "  ";
                    data.CssClass = "info";
                    data.Style.Add("text-align", "left");
                    form1.Controls.Add(data);

                    addLine();

                    TextBox enterGrade = new TextBox();
                    enterGrade.ID = "gradeTextBox" + i;
                    enterGrade.CssClass = "labels";
                    form1.Controls.Add(enterGrade);

                    Button submitButton = new Button();
                    submitButton.Text = "Update assignment grade";
                    submitButton.Click += updateAssignmentGrade;
                    submitButton.CommandName = sid + "," + cid + "," + assignmentNumber + "," + assignmenttype + "," + i;
                    submitButton.CssClass = "button2";
                    form1.Controls.Add(submitButton);

                    Label line2 = new Label();
                    line2.Text = "<br />";
                    form1.Controls.Add(line2);

                    Label line3 = new Label();
                    line3.Text = "<br />";
                    form1.Controls.Add(line3);

                    i++;
                }
            }
        }

        protected void updateAssignmentGrade(object sender, EventArgs e)
        {
            string tmp = ((Button)sender).CommandName;
            string[] values = new string[5];
            int pointer = 0;
            for(int i = 0; i < tmp.Length; i++)
            {
                if(tmp[i] == ',')
                {
                    pointer++;
                    continue;
                }
                values[pointer] += tmp[i];
            }
            int sid = Int16.Parse(values[0]);
            int cid = Int16.Parse(values[1]);
            Session["courseID"] = cid + "";
            int assignmentNumber = Int16.Parse(values[2]);
            string type = values[3];
            int j = Int16.Parse(values[4]);
            decimal grade = Decimal.Parse(((TextBox)form1.FindControl("gradeTextBox" + j)).Text);

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand update = new SqlCommand("InstructorgradeAssignmentOfAStudent",conn);
            update.CommandType = CommandType.StoredProcedure;
            update.Parameters.Add(new SqlParameter("@instrId", Int16.Parse(Session["user"].ToString())));//session
            update.Parameters.Add(new SqlParameter("@sid", sid));
            update.Parameters.Add(new SqlParameter("@cid", cid));
            update.Parameters.Add(new SqlParameter("@assignmentNumber", assignmentNumber));
            update.Parameters.Add(new SqlParameter("@type", type));
            update.Parameters.Add(new SqlParameter("@grade", grade));

            conn.Open();
            try
            {
                update.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            
            conn.Close();

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