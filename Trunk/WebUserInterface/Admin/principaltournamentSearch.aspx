<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principaltournament";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PrincipalTournament</h2>
	<p>Use this page to search for objects of the PrincipalTournament type.</p>
	<div class="searchTable">
		<OrionsBelt:PrincipalTournamentSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PrincipalTournamentPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>HasEliminated</th>
			<th>EliminatedInFase</th>
			<th>EliminatedInBattleId</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PrincipalTournamentItem runat="server">
		<tr>
			<td><OrionsBelt:PrincipalTournamentId runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentHasEliminated runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentEliminatedInFase runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentEliminatedInBattleId runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentCreatedDate runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalTournamentItem>
	</table>
	</OrionsBelt:PrincipalTournamentPagedList>
</asp:Content>