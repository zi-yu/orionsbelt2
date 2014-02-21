<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.ForgotPasswordPage" MasterPageFile="~/OrionsBeltMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div id="loginLogo">
        <OrionsBeltUI:Image Src="logo.png" alt="Orion's Belt" title="Orion's Belt" runat="server" />
    </div>
    <OrionsbeltUI:BoardHandler ID="BoardHandler1" runat="server" />
    <div id="loginPanel">
        <div id="forgotLayout">
            <div style="padding:30px 10px 10px 10px;font-size:16px;">
                <OrionsBelt:Label ID="Label2" Key="ForgotPasswordIntro" runat="server" />
            </div>
            
            <asp:Literal ID="message" EnableViewState="false" runat="server" />
            <div class='name'>
                <OrionsBelt:Label Key="UserName" runat="server" />
            </div>
		    <asp:TextBox ID="username" CssClass="username" runat="server" />
    		
    		<div class='name'>
		        <OrionsBelt:Label ID="Label1" Key="Email" runat="server" />
		    </div>
		    <asp:TextBox ID="mail" CssClass="username" runat="server" />
		    <div class="center">
		        <asp:Button ID="send" CssClass="button" runat="server" />
		    </div>
		</div>
    </div>
    
</asp:Content>