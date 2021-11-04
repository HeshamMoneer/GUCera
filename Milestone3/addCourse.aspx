<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCourse.aspx.cs" Inherits="GUCera.addCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
  <a href="homeInstructor.aspx">Home</a>
  <a href="myAcceptedCourses.aspx">Accepted Courses</a>
  <a class="active" href="addCourse.aspx">Add Course</a>
  <a href="issueCertificates.aspx">Certify</a>
    </div>
        <div>
            <asp:Label runat="server" CssClass="info">
                Add a new course with its details
            </asp:Label>
            <br />
            <asp:Label runat="server" CssClass="info2">Credit hours:</asp:Label>
            <asp:TextBox ID="creditHours" runat="server" ToolTip="enter an integer value" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Name: 
            </asp:Label>
            <asp:TextBox ID="name" runat="server" ToolTip="maximum 10 characters" CssClass="labels"></asp:TextBox>
            <br />
            <asp:Label runat="server" CssClass="info2">
                Price: 
            </asp:Label>
            <asp:TextBox ID="price" runat="server" ToolTip="enter a decimal value" CssClass="labels"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submit_button" runat="server" OnClick="submit_click" Text="Submit" CssClass="button2" />
        </div>
    </form>
</body>
</html>
