<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="Milestone3.RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                    <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" CssClass="login">
            Register as Student
        </asp:Label>
            <asp:Label runat="server" CssClass="info2">
            First Name: 
        </asp:Label>
            <asp:TextBox ID="first" runat="server" CssClass="labels"></asp:TextBox>
      
        <asp:Label runat="server" CssClass="info2">
            Last Name: 
        </asp:Label>
        <asp:TextBox ID="last" runat="server"  CssClass="labels"></asp:TextBox>
        <asp:Label runat="server" CssClass="info2">
            Password:  
        </asp:Label>
        <asp:TextBox ID="password" input type="password" runat="server"  CssClass="labels"></asp:TextBox>
        <br />
        <asp:Label runat="server" CssClass="info2">
            Email: 
        </asp:Label>
        <asp:TextBox ID="email" runat="server"  CssClass="labels"></asp:TextBox>
        <br />
        <asp:Label runat="server" CssClass="info2">
            Gender:  
        </asp:Label>
        <asp:DropDownList ID="gender" runat="server" CssClass="dropDown">
            <asp:ListItem Value="1">male</asp:ListItem>
            <asp:ListItem Value="0">female</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat="server" CssClass="info2">
            Address:  
        </asp:Label>
        <asp:TextBox ID="address" runat="server"  CssClass="labels"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Student" CssClass="button2"/>
        <br />
    </form>
</body>
</html>
