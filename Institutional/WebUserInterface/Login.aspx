<%@ Page Language="C#" AutoEventWireup="true" Inherits="Institutional.WebUserInterface.Login" %>
<%@ Register TagPrefix="Institutional" Assembly="Institutional.WebUserInterface" Namespace="Institutional.WebComponents.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form" runat="server">
    <div>
        <Institutional:RoleVisible Role="user" runat="server">
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </Institutional:RoleVisible>
        
        <Institutional:RoleVisible Role="guest" runat="server">
		<Institutional:Login runat="server">
			<LayoutTemplate>
					<div id="loginLayout">
						<div>
							<div class="name"><Institutional:Label Key="UserName" runat="server" /></div>
							<asp:TextBox ID="UserName" CssClass="username" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="*" ToolTip="Required" ValidationGroup="login">*</asp:RequiredFieldValidator>
						</div>
						<div>
							<div class="name"><Institutional:Label Key="Password" runat="server" /></div>
							<asp:TextBox ID="Password" CssClass="password" runat="server" TextMode="Password"></asp:TextBox>
							<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="*" ToolTip="Required" ValidationGroup="login">*</asp:RequiredFieldValidator>
						</div>
						<div>
							<asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
						</div>
						<div class="loginButton">
							<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="login" />
						</div>
						<div>
							<asp:Label ID="error" runat="server" />
						</div>
					</div>
				</LayoutTemplate>
			</Institutional:Login>

		</Institutional:RoleVisible>
					
    </div>
    </form>
</body>
</html>
