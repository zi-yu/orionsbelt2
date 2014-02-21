<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" Inherits="OrionsBelt.WebAdmin.Admin.Controls.SqlAnalyser" %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>

<asp:content runat="server" contentplaceholderid="content">
	<p>
		This Page can be use to run updates, deletes or queries directly into the database. The language to be used is SQL.
	</p>
	<b>SQL Query</b><br />
	<asp:TextBox ID="query" Width="90%" Height="250"  TextMode="MultiLine" runat="server" />
	<asp:Button ID="execute" Text="execute" OnClick="ExecuteQuery" runat="server" />
	<p />
	<asp:GridView ID="results" runat="server" />
	<p />
</asp:content>
