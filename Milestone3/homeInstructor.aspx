<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeInstructor.aspx.cs" Inherits="GUCera.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">

    <div class="topnav">
  <a class="active" href="homeInstructor.aspx">Home</a>
  <a href="myAcceptedCourses.aspx">Accepted Courses</a>
  <a href="addCourse.aspx">Add Course</a>
  <a href="issueCertificates.aspx">Certify</a>
    </div>
    <br />
        <div class="card">
  <asp:Image id="Avatar" runat="server" src="Images/male.png" class="avatar" />
        <asp:Label ID="info" runat="server" Text="" CssClass="info4"></asp:Label>
</div>
        <br />
        <asp:Button ID="logout" runat="server" Text="Log out" OnClick="logout_Click" CssClass="btn btn-primary btn-block btn-large"/>
    <br /><br />
    </form>
</body>
</html>
