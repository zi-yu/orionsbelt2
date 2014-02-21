<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>

<asp:content runat="server" contentplaceholderid="content">
	<p>
		This Page can be use to see the HTTP headers of the request.
	</p>
	<Admin:HttpHeaders runat="server" />
</asp:content>
