﻿<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" Inherits="OrionsBelt.WebAdmin.Admin.Controls.SmtpSettings"%>

<asp:content runat="server" contentplaceholderid="content">
	<p>
		Use this page to manage SMTP settings, which determine how your Web application sends e-mail. If your e-mail server requires you to log on before you can send an e-mail message, specify the type of authentication that the server requires, and if necessary, the user name and password to use.
	</p>
	<h2>Configure SMTP Settings</h2>
	
	<p>Server Name: <asp:TextBox id="serverName" runat="server" /></p>
	<p>Server Port: <asp:TextBox id="serverPort" runat="server" /></p>
	<p>From: <asp:TextBox id="from" runat="server" /></p>
	<p/>
	<h2>Authentication:</h2>
	<p/>
	<p><asp:RadioButton runat="server" id="NoneRadioButton" GroupName="Authentication" AutoPostBack="true" OnCheckedChanged="Authentication_ValueChanged"/> None</p>
	<p><asp:RadioButton runat="server" id="BasicRadioButton" GroupName="Authentication" AutoPostBack="true" OnCheckedChanged="Authentication_ValueChanged" /> Basic</p>
	<p>Choose this option if your e-mail server requires you to explicitly pass a user name and password when sending an e-mail message.</p>
	<p/>
	<p>Sender's user name: <asp:TextBox id="sendersName" runat="server" /></p>
	<p>Sender's password: 	<asp:TextBox TextMode="Password" runat="server" id="sendersPass"/></p>
	<p/>
	<p><asp:RadioButton runat="server" id="NTLMRadioButton" GroupName="Authentication" AutoPostBack="true" OnCheckedChanged="Authentication_ValueChanged"/> NTLM (Windows authentication)</p>
	<p>Choose this option if your e-mail server is on a local area network and you connect to it using windows credentials.</p>
	<p/>
	<p><asp:Button runat="server" Text="Save" OnClick="SaveButton_Click" /></p>

</asp:content>
