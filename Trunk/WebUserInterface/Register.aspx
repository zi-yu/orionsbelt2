<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/OrionsBeltMaster.Master" Inherits="OrionsBelt.WebUserInterface.Register" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:FacebookScript runat="server" />

    <OrionsBeltUI:FlagMenu ID="FlagMenu1" runat="server" />
    <div id="loginLogo">
        <OrionsBeltUI:Image ID="Image1" Src="logo.png" alt="Orion's Belt" title="Orion's Belt" runat="server" />
    </div>
    
    <div id="registerPanel">
        <div id='registerTopText'>
		    <OrionsBelt:Label Key="RegisterTopText" runat="server" />
	    </div>
	    <div id="registerLayout">
	        <div class="socialLogin">
			    <div style="margin-right:20px;"><OrionsBelt:FacebookConnect ID="FacebookConnect1" runat="server" /></div>
                <div><OrionsBeltUI:TwitterConnect ID="TwitterConnect1" runat="server" /></div>
			</div>
		    <div>
			    <div class="name"><OrionsBelt:Label Key="UserName" runat="server" /></div>
			    <asp:TextBox ID="userName" CssClass="username" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="userNameRequired" ErrorMessage="*" runat="server" ControlToValidate="userName" ToolTip="User Name is required." ValidationGroup="createUser">*</asp:RequiredFieldValidator>
		    </div>
		    <div>
			    <div class="name"><OrionsBelt:Label Key="Password" runat="server" /></div>
			    <asp:TextBox ID="password" CssClass="username" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="passwordRequired" ErrorMessage="*" runat="server" ControlToValidate="password" ValidationGroup="createUser"></asp:RequiredFieldValidator>
		    </div>
		    <div>
			    <div class="name"><OrionsBelt:Label Key="PasswordConfirm" runat="server" /></div>
			    <asp:TextBox ID="confirmPassword" CssClass="username" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="confirmPasswordRequired" runat="server" ControlToValidate="confirmPassword"
						    ErrorMessage="*" ValidationGroup="createUser">*</asp:RequiredFieldValidator>
		    </div>
		    <div>
			    <div class="name"><OrionsBelt:Label Key="Email" runat="server" /></div>
			    <asp:TextBox ID="email" CssClass="username" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="email"
						    ErrorMessage="*" ValidationGroup="createUser">*</asp:RequiredFieldValidator>
		    </div>
		     <div>
			    <asp:CheckBox ID="terms" runat="server"></asp:CheckBox>
		    </div>
		    <div>
		        <asp:RegularExpressionValidator id="emailValidator" Display="Dynamic" ControlToValidate="email" ValidationExpression="^([a-zA-Z0-9_\-\+\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="createUser" runat="server"></asp:RegularExpressionValidator>
			    <asp:CompareValidator  ID="passwordCompare" runat="server" ControlToCompare="password" ControlToValidate="confirmPassword" Display="Dynamic"  ValidationGroup="createUser"></asp:CompareValidator>
		    </div>
		    <div class="red">
			    <asp:Literal ID="errorMessage" runat="server" EnableViewState="False"></asp:Literal>
		    </div>
		    <div class="center" style="margin-top:20px;">
		        <asp:Button id="register" CssClass="button" ValidationGroup="createUser" runat="server" />
		    </div>
		    <div>
			    <asp:Label ID="error" runat="server" />
		    </div>
		    
	    </div>
	</div>
	<img src="http://www.advertiseyourgame.com/publish/pixel.php?id=620" height="0" width="0" />
</asp:Content>