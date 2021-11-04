<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignments.aspx.cs" Inherits="Milestone3.Assignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                            <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body style="height: 641px">
    <form id="form1" runat="server">
        <div class="topnav">
         <a href="StudentHome.aspx">Home</a>
         <a href="AvaliableCourses.aspx">Available Courses</a>
         <a href="CreditCard.aspx">Add Credit Card</a>
         <a href="PromoCode.aspx">Promo Codes</a>
            <a class="active" href="viewAssignments.aspx">Assignments</a>
            <a href="SubmitAssignment.aspx">Submit assignment</a>
            <a href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>

        <asp:Label runat="server" CssClass="info">
            Your assignments
        </asp:Label>
        
        <asp:Label runat="server" CssClass="info2">
            Course ID:
        </asp:Label>
        <br />
        <asp:DropDownList ID="CourseId" runat="server" CssClass="dropDown"></asp:DropDownList>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="ViewAssignments" Text="View Assignments " CssClass="button2"/>
        </p>
        <p>
            &nbsp;</p>
      
    </form>
</body>
</html>
