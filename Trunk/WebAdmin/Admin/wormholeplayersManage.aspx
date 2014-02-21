<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "wormholeplayers";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:WormHolePlayersPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:WormHolePlayersNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:WormHolePlayersIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:WormHolePlayersPlayerCountSort InnerHtml="PlayerCount" runat="server" /></th>
			<th><OrionsBelt:WormHolePlayersCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:WormHolePlayersUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:WormHolePlayersLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:WormHolePlayersItem runat="server">
		<tr>
			<td><OrionsBelt:WormHolePlayersId runat="server" /></td>
			<td><OrionsBelt:WormHolePlayersPlayerCount runat="server" /></td>
			<td><OrionsBelt:WormHolePlayersCreatedDate runat="server" /></td>
			<td><OrionsBelt:WormHolePlayersUpdatedDate runat="server" /></td>
			<td><OrionsBelt:WormHolePlayersLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:WormHolePlayersDelete runat="server" /></td>
		</tr>
		</OrionsBelt:WormHolePlayersItem>
	</table>
	<OrionsBelt:WormHolePlayersNumberPagination runat="server" />
	</OrionsBelt:WormHolePlayersPagedList>

</asp:Content>