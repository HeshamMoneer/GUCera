<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewFeedbacks.aspx.cs" Inherits="GUCera.viewFeedbacks" %>

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
            <asp:Label ID="header" runat="server" Text="Students feedbacks on course: " CssClass="info"></asp:Label>
        </div>
        <br />
    </form>
</body>
</html>
