<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentsAssignments.aspx.cs" Inherits="GUCera.studentsAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
  <a href="homeInstructor.aspx">Home</a>
  <a href="myAcceptedCourses.aspx">Accepted Courses</a>
  <a href="addCourse.aspx">Add Course</a>
  <a href="issueCertificates.aspx">Certify</a>
    </div>
        <div>
            <asp:Label ID="header" runat="server" Text="Submitted assignments for the course: " CssClass="info"></asp:Label>
        </div>
    </form>
</body>
</html>
