<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGrades.aspx.cs" Inherits="Milestone3.ViewGrades" %>

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
            <a class="active" href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
            <asp:Label runat="server" CssClass="info">
            View Grade in an Assignment
        </asp:Label>
            <asp:Label runat="server" CssClass="info2">
            Select Assignment:
        </asp:Label>
        <asp:DropDownList ID="Assignment" runat="server" CssClass="dropDown"></asp:DropDownList>
            <br />

            <asp:Button ID="Button1" runat="server" OnClick="ViewGrade" Text="View Grade" CssClass="button2"/>

        </div>
    </form>
</body>
</html>
