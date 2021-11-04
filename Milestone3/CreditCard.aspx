<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCard.aspx.cs" Inherits="GUCera.CreditCard" %>

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
         <a class="active" href="CreditCard.aspx">Add Credit Card</a>
         <a href="PromoCode.aspx">Promo Codes</a>
            <a href="viewAssignments.aspx">Assignments</a>
            <a href="SubmitAssignment.aspx">Submit assignment</a>
            <a href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
        <div>
            <asp:Label runat="server" CssClass="info">
            Enter Your Credit Card Data Details
        </asp:Label>
            <asp:Label runat="server" CssClass="info2">
            Card Number:
        </asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="labels"></asp:TextBox>
        <br />
        <asp:Label runat="server" CssClass="info2">
            Holder Name:
        </asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="labels"></asp:TextBox>
        <br />
        <asp:Label runat="server" CssClass="info2">
            Expiry Date:
        </asp:Label>
        <asp:TextBox ID="exp" runat="server" CssClass="labels"></asp:TextBox>
        <br />
        <asp:Label runat="server" CssClass="info2">
            CVV:
        </asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="labels"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Credit Card" CssClass="button2"/>
    </form>
</body>
</html>
