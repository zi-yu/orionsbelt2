<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" Inherits="Institutional.WebAdmin.Admin.Controls.HqlAnalyser" %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>

<asp:content runat="server" contentplaceholderid="content">
	<p>
		This Page can be use to see the contents of the database using queries. The language to be used is NHQL (NHibernate Query Language).
	</p>
	<b>HQL Query</b><br />
	<asp:TextBox ID="query" Width="90%" Height="250"  TextMode="MultiLine" runat="server" />
	<asp:Button ID="execute" Text="execute" OnClick="ExecuteQuery" runat="server" />
	<p />
	<asp:GridView ID="results" runat="server" />
	<p />
</asp:content>
