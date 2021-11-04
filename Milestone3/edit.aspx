<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="GUCera.edit" %>

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

        <div>
            <br />
            <asp:Label runat="server" CssClass="info2">
                First Name:
            </asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Last Name:
            </asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Password:
            </asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Gender:
            </asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Email:
            </asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Address:
            </asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="labels"></asp:TextBox>
            <br />
                        <br />

            <asp:Button ID="Button1" runat="server" Text="Update Profile" OnClick="Button1_Click" CssClass="button2"/>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
