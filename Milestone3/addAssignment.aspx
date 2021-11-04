<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addAssignment.aspx.cs" Inherits="GUCera.addAssignment" %>

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
  <a href="addCourse.aspx">Add Course</a>
  <a href="issueCertificates.aspx">Certify</a>
    </div>
        <div>
            <asp:Label ID="header" runat="server" Text="Add assignment to the course: " CssClass="info"></asp:Label>
        </div>

        <br />
            <asp:Label ID="x1" runat="server" Text="Number: " CssClass="info2"></asp:Label>
        <asp:TextBox ID="number" runat="server" ToolTip="insert a unique number" CssClass="labels"></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="x2" runat="server" Text="Type: " CssClass="info2"></asp:Label>
        <asp:RadioButtonList ID="type" runat="server" CssClass="info3">
                <asp:ListItem Text="Quiz "></asp:ListItem>
            <asp:ListItem Text="Exam "></asp:ListItem>
            <asp:ListItem Text="Project"></asp:ListItem>
        </asp:RadioButtonList>
        <br />
            <asp:Label ID="x3" runat="server" Text="Full grade: " CssClass="info2"></asp:Label>
        <asp:TextBox ID="fullGrade" runat="server" ToolTip="insert an integer value" CssClass="labels"></asp:TextBox>
            <br />
        <br />
            <asp:Label ID="x4" runat="server" Text="Weight: " CssClass="info2"></asp:Label>
        <asp:TextBox ID="weight" runat="server" ToolTip="insert an numeric value" CssClass="labels"></asp:TextBox>
            <br />
        <br />
            <asp:Label ID="x5" runat="server" Text="Deadline: " CssClass="info2"></asp:Label>
        <asp:TextBox ID="deadline" runat="server" ToolTip="insert a date" CssClass="labels"></asp:TextBox>
            <br />
        <br />
            <asp:Label ID="x6" runat="server" Text="Content: " CssClass="info2"></asp:Label>
        <asp:TextBox ID="content" runat="server" CssClass="labels"></asp:TextBox>
            <br />
            <br />


            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Submit" CssClass="button2"/>


            </form>
</body>
</html>
