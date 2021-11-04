<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvaliableCourses.aspx.cs" Inherits="GUCera.AvaliableCourses" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                        <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
         <a href="StudentHome.aspx">Home</a>
         <a class="active" href="AvaliableCourses.aspx">Available Courses</a>
         <a href="CreditCard.aspx">Add Credit Card</a>
         <a href="PromoCode.aspx">Promo Codes</a>
            <a href="viewAssignments.aspx">Assignments</a>
            <a href="SubmitAssignment.aspx">Submit assignment</a>
            <a href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
        <asp:Label runat="server" CssClass="info">
            Here are the available courses
        </asp:Label>
        <asp:Label runat="server" ID="ViewCourse" CssClass="ViewCourse">

        </asp:Label>
    </form>

   
</body>
</html>
