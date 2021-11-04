<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Milestone3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>

<body >
    <form id="form1" runat="server">
        <asp:Label runat="server" CssClass="login" font-family='Agency FB'>
            Welcome to GUCera
        </asp:Label>
        <br />
        <div class ="div">
            <asp:TextBox ID="username" runat="server" BorderStyle="Solid" CssClass="labels" placeholder="UserID" required="required" Width="304px"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="password" runat="server" input type="password" BorderStyle="Solid" CssClass="labels" placeholder="Password" required="required" Width="307px"></asp:TextBox>
            <br />
            <br />
        <asp:Button ID="login" runat="server" OnClick="login1" Text="Login" CssClass="btn btn-primary btn-block btn-large" Width="311px" />
                     <br />

                    <asp:Button ID="addMobileNumber" runat="server" OnClick="AddNu" Text="Add mobile number" CssClass="btn btn-primary btn-block btn-large" Width="312px" formnovalidate="formnovalidate"
/>
               <br />
            <br />
                     <a href="RegisterStudent.aspx" style="color: #FFFFFF; font-size:25px;font-family:'Agency FB';" >Register as Student</a> 
                    <br />
            <br />
            <a href="instructorRegister.aspx" style="color: #FFFFFF; font-size:25px;font-family:'Agency FB';">Register as Instructor</a>
        </div>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
