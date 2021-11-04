<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="instructorRegister.aspx.cs" Inherits="GUCera.instructorRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                    <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" CssClass="login">
            Register as an Instructor
        </asp:Label>
            <asp:Label runat="server" CssClass="info2">
            First Name: 
        </asp:Label>
            <asp:TextBox ID="firstName" runat="server" CssClass="labels"></asp:TextBox>
            <asp:Label runat="server" CssClass="info2">
            Last Name: 
        </asp:Label>
            <asp:TextBox ID="lastName" runat="server" CssClass="labels"></asp:TextBox>
     
            <asp:Label runat="server" CssClass="info2">
            Password:  
        </asp:Label>
            <asp:TextBox ID="password" input type="password" runat="server" CssClass="labels"></asp:TextBox>
       
            <asp:Label runat="server" CssClass="info2">
            Email: 
        </asp:Label>
            <asp:TextBox ID="email" runat="server" CssClass="labels"></asp:TextBox>
        
            <asp:Label runat="server" CssClass="info2">
            Gender:
        </asp:Label>
            <asp:DropDownList ID="gender" runat="server" CssClass="dropDown">
                <asp:ListItem Text="male" Value="1"></asp:ListItem>
                <asp:ListItem Text="female" Value="0"></asp:ListItem>
            </asp:DropDownList>
       
            <asp:Label runat="server" CssClass="info2">
            Address: 
        </asp:Label>
            <asp:TextBox ID="address" runat="server" CssClass="labels"></asp:TextBox>
        <br />
        
        <asp:Button ID="register" runat="server" Text="Register" OnClick="Register" CssClass=" button2"/>
    </form>
</body>
</html>
