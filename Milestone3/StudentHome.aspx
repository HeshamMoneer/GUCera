<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="Milestone3.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                    <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
         <a class="active" href="StudentHome.aspx">Home</a>
         <a href="AvaliableCourses.aspx">Available Courses</a>
         <a href="CreditCard.aspx">Add Credit Card</a>
         <a href="PromoCode.aspx">Promo Codes</a>
            <a href="viewAssignments.aspx">Assignments</a>
            <a href="SubmitAssignment.aspx">Submit assignment</a>
            <a href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
        <br />
        <br />
<div class="card">
  <asp:Image runat="server" id="avatar" src="Images/male.png" class="avatar"/>
        <asp:Label ID="info" runat="server" Text="" CssClass="info4"></asp:Label>
</div>
        <br />
        <br />
                    <asp:Button ID="edit" runat="server" Text="Edit Profile" OnClick="edit_click" CssClass="button2"/>
<br />
        <br />
            <asp:Button ID="logout" runat="server" Text="Log out" OnClick="logoutButton" CssClass="btn btn-primary btn-block btn-large"/>
    <br />
        <br />
    </form>
</body>
</html>
