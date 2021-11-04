<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCertificates.aspx.cs" Inherits="Milestone3.ViewCertificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
              <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>

<body>
    <form id="form1" runat="server">
         <div class="topnav">
         <a href="StudentHome.aspx">Home</a>
         <a href="AvaliableCourses.aspx">Available Courses</a>
         <a href="CreditCard.aspx">Add Credit Card</a>
         <a href="PromoCode.aspx">Promo Codes</a>
            <a href="viewAssignments.aspx">Assignments</a>
            <a href="SubmitAssignment.aspx">Submit assignment</a>
            <a href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a class="active" href="ViewCertificates.aspx">Certificates</a>
    </div>
        <asp:Label runat="server" CssClass="info">
            View your certificates
        </asp:Label>
        <asp:Label runat="server" CssClass="info2">
            Course ID:
        </asp:Label>
        <asp:DropDownList ID="CourseId" runat="server" CssClass="dropDown"></asp:DropDownList>
            <br />
        <asp:Button ID="Button1" runat="server" OnClick="ViewCertificate" Text="View Certificates" CssClass="button2" />

    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
