<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Admin.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                    <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" CssClass="login">
            Admin Controls
        </asp:Label>
        <br /> 

				<asp:Button ID="Button1" runat="server" Text="List all courses" OnClick="AllCourses_Click" CssClass="button2"/>
                	<br />

				 <table style="width:100%;" id ="Table1">
					 <tr>
			 <asp:Panel ID="Panel3" runat="server">
                	</asp:Panel>

					 </tr>
					
				 </table>
				 <br />
                 <br/>
		

         <br/>
                  <br/>
				<asp:Button runat="server" Text="Courses not yet accepted" OnClick="notAccepted_Click" ID="NotAcceptedButton" CssClass="button2"/>
			  	<br />
                 <table style="width:100%;" id ="Table2">
					 <tr>
            <asp:Panel ID="Panel2" runat="server">
             </asp:Panel>
				  <br />
			  <br/>
             </tr>
			</table>
         <br/>
         <br />


        <asp:Panel ID="panelAccept" runat="server">
        <asp:Label runat="server" CssClass="login">
            Accept Courses
        </asp:Label>
        <br/>
            <br />
        <asp:Label runat="server" CssClass="info2">
            Course ID
        </asp:Label>
            <asp:DropDownList ID="CourseId" CssClass="dropDown" runat="server"></asp:DropDownList>
        <br/>
	    <asp:Button ID="Accept" runat="server" Text="Accept" OnClick="Accept_Click" CssClass="button2"/>
        <br/>
             <br/>
        </asp:Panel>


         <asp:Panel ID="panelPromo" runat="server">
         <asp:Label runat="server" CssClass="login">
            Create Promo Code
        </asp:Label>
         <asp:Label runat="server" CssClass="info2">
            Code
        </asp:Label>
		 <asp:TextBox ID="code" runat="server" CssClass="labels"></asp:TextBox>
         <br/>
         <asp:Label runat="server" CssClass="info2">
            Issue Date
        </asp:Label>
	     <asp:TextBox ID="issueDate" runat="server" CssClass="labels"></asp:TextBox>
         <br/>
         <asp:Label runat="server" CssClass="info2">
            Expiry Date
        </asp:Label>
		<asp:TextBox ID="expiryDate" runat="server" CssClass="labels"></asp:TextBox>
        <br/>
        <asp:Label runat="server" CssClass="info2">
            Discount
        </asp:Label>
        <asp:TextBox ID="discount" runat="server" CssClass="labels"></asp:TextBox>
             <br />
        <br/>
	    <asp:Button ID="Button2" runat="server" Text="Create Promo code" OnClick="createPromocode_Click" CssClass="button2"/>
        <br/>
              <br/>
        </asp:Panel>


		<asp:Panel ID="panelIssue" runat="server">
        <br/>
        <asp:Label runat="server" CssClass="login">
            Issue Promo Code
        </asp:Label>
        <asp:Label runat="server" CssClass="info2">
            Student ID
        </asp:Label>
        <br/>
            <asp:DropDownList ID="SidPromo" CssClass="dropDown" runat="server"></asp:DropDownList>
        <br/>
        <asp:Label runat="server" CssClass="info2">
            Promo Code Number
        </asp:Label>
            <asp:DropDownList ID="PromocodeId" runat="server" CssClass="dropDown"></asp:DropDownList>
        <br/>
            <br />
		<asp:Button ID="Issue" runat="server" Text="Issue" OnClick="Issue_Click" CssClass="button2"/>
         <br/>
             <br/>
		</asp:Panel>
		 <br/>
        <asp:Button ID="logout" runat="server" Text="Log out" OnClick="logout_click" CssClass="btn btn-primary btn-block btn-large"/>
   <br/>
        <br/>
        
    </form>
</body>

</html>
