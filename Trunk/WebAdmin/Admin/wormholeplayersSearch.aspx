<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "wormholeplayers";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search WormHolePlayers</h2>
	<p>Use this page to search for objects of the WormHolePlayers type.</p>
	<div class="searchTable">
		<OrionsBelt:WormHolePlayersSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:WormHolePlayersPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>PlayerCount</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:WormHolePlayersPagedList>
</asp:Content>