<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enroll.aspx.cs" Inherits="GUCera.enroll" %>

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
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
        <asp:Label runat="server" CssClass="info" ID="header">
            Enroll in the course: 
        </asp:Label>
        
        <asp:Label runat="server" CssClass="info2">
            Instructor ID:
        </asp:Label>
        <asp:DropDownList ID="inst" runat="server" CssClass="dropDown">
        </asp:DropDownList>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Enroll" OnClick="Button1_Click" CssClass="button2"/>
        </p>
    </form>
</body>
</html>
