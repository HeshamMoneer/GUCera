<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mobileAdd.aspx.cs" Inherits="Milestone3.mobileAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                    <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" CssClass="login">
            Add a Mobile Number
        </asp:Label>
        <div>
            <asp:Label runat="server" CssClass="info2">
            User ID: 
        </asp:Label>
            <asp:TextBox ID="id" runat="server" CssClass="labels"></asp:TextBox>
        </div>
        <asp:Label runat="server" CssClass="info2">
            Password:  
        </asp:Label>
        <p>
            <asp:TextBox ID="pw" runat="server" CssClass="labels"></asp:TextBox>
        </p>
        <p>
            <asp:Label runat="server" CssClass="info2">
            Mobile Number:  
        </asp:Label>
        <asp:TextBox ID="no" runat="server" CssClass="labels"></asp:TextBox>
        <p>
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="addMob" CssClass="button2"/>
        </p>
    </form>
</body>
</html>
