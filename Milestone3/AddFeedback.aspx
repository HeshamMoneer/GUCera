<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFeedback.aspx.cs" Inherits="Milestone3.AddFeedback" %>

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
            <a class="active" href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
        <asp:Label runat="server" CssClass="info">
            Add a Feedback
        </asp:Label>
        <asp:Label runat="server" CssClass="info2">
            Course ID:
        </asp:Label>
        <asp:DropDownList ID="CourseId" runat="server" CssClass="dropDown"></asp:DropDownList>
        <asp:Label runat="server" CssClass="info2">
            Feedback:
        </asp:Label>
        <asp:TextBox ID="Feedback" runat="server" CssClass="labels"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add Feedback" OnClick="Add_Feedback" CssClass="button2"/>
        <br />
    </form>
</body>
</html>
