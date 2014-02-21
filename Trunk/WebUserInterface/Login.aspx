<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.Login" MasterPageFile="~/OrionsBeltMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:FacebookScript ID="FacebookScript1" runat="server" />
    <OrionsBeltUI:FlagMenu runat="server" />
    <div id="loginLogo">
        <OrionsBeltUI:Image Src="logo.png" alt="Orion's Belt" title="Orion's Belt" runat="server" />
    </div>
    
    <div id="loginPanel">
	<OrionsBeltUI:OrionRoleVisible Role="guest" runat="server">
		<OrionsBelt:Login ID="Login1" AlwaysRememberMe="true" DestinationPageUrl="Default.aspx" runat="server">
			<LayoutTemplate>
				<div id="loginLayout">
					<div>
						<div class="name"><OrionsBelt:Label ID="Label1" Key="UserName" runat="server" /></div>
						<asp:TextBox ID="UserName" CssClass="username" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="*" ToolTip="Required" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
					</div>
					<div>
						<div class="name"><OrionsBelt:Label ID="Label2" Key="Password" runat="server" /></div>
						<asp:TextBox ID="Password" CssClass="password" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="*" ToolTip="Required" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
					</div>
					<div>
						<div class="forgotPassword"><a href="ForgotPassword.aspx"><OrionsBelt:Label Key="ForgotPassword" runat="server" /></a></div>
						<div class="forgotPassword"><a href="ResendConfirmation.aspx"><OrionsBelt:Label Key="ResendConfirmation" runat="server" /></a></div>
					</div>
					<div>
						<asp:CheckBox ID="RememberMe" Checked="true" runat="server" /><OrionsBelt:Label Key="RememberMe" runat="server" />
					</div>
					<div class="loginButton">
						<asp:Button ID="loginButton" CssClass="button" runat="server" CommandName="Login" Text="Log In" />
					</div>
					<div class="socialLogin">
					    <div style="margin-right:10px;"><OrionsBelt:FacebookConnect runat="server" /></div>
                        <div><OrionsBeltUI:TwitterConnect runat="server" /></div>
					</div>
					<div class="registerLoginButton">
					    <div class='buttonLarge'>
					        <asp:Literal ID="langAppend" runat="server" />
					    </div>
					</div>
					<div><asp:Label ID="error" runat="server" /></div>
				</div>
			</LayoutTemplate>
		</OrionsBelt:Login>
	</OrionsBeltUI:OrionRoleVisible>
    <OrionsBeltUI:Redirect runat="server" />
    </div>   
</asp:Content>
