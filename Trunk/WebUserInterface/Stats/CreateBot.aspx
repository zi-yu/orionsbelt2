<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateBot.aspx.cs" Inherits="OrionsBelt.WebUserInterface.CreateBot" MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div id="botPanel">
    <div id="botLayout">
        <div>
		    <div class="name"><OrionsBelt:Label ID="Label1" Key="BotName" runat="server" /></div>
		    <asp:TextBox ID="botName" CssClass="username" runat="server"></asp:TextBox>
		    <asp:RequiredFieldValidator ID="botNameRequired" ErrorMessage="*" runat="server" ControlToValidate="botName" ValidationGroup="createBot">*</asp:RequiredFieldValidator>
	    </div>
	    <div>
		    <div class="name"><OrionsBelt:Label ID="Label2" Key="BotUrl" runat="server" /></div>
		    <asp:TextBox ID="botUrl" CssClass="username" runat="server" ></asp:TextBox>
		    <asp:RequiredFieldValidator ID="boturlRequired" ErrorMessage="*" runat="server" ControlToValidate="botUrl" ValidationGroup="createBot"></asp:RequiredFieldValidator>
	    </div>
	     <div class="red">
		    <asp:Literal ID="errorMessage" runat="server" EnableViewState="False"></asp:Literal>
	    </div>

	    <div class="center">
	        <asp:Button id="register" CssClass="button" ValidationGroup="createBot" runat="server" />
	    </div>
    </div>
    </div>

</asp:Content>

