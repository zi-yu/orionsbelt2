<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Orionsbelt.WebUserInterface.Confirmation" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
	<asp:PlaceHolder ID="notApprovedHolder" runat="server" Visible="false">
		<div id="mainTitle">
			<h1><OrionsBelt:Label ID="Label1" Key="Confirmation" runat="server" /></h1>
		</div>
		<OrionsBelt:Label Key="notApproved" runat="server" />
		<div><asp:TextBox ID="confirmationEmail" runat="server"></asp:TextBox></div>
		<asp:Button ID="send" ValidationGroup="ConfirmationEmail" runat="server" />
		<asp:RegularExpressionValidator 
		ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" 
		ID="emailValidation" ControlToValidate="confirmationEmail" ValidationGroup="ConfirmationEmail" 
		runat="server" Display="Dynamic" ></asp:RegularExpressionValidator>
	</asp:PlaceHolder>
	<asp:PlaceHolder ID="confirmationHolder" runat="server" Visible="false">
		
	</asp:PlaceHolder>
</asp:Content>