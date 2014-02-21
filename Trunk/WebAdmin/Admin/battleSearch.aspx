<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battle";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Battle</h2>
	<p>Use this page to search for objects of the Battle type.</p>
	<div class="searchTable">
		<OrionsBelt:BattleSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BattlePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>CurrentTurn</th>
			<th>HasEnded</th>
			<th>BattleType</th>
			<th>BattleMode</th>
			<th>UnitsDestroyed</th>
			<th>Terrain</th>
			<th>CurrentPlayer</th>
			<th>TimeoutsAllowed</th>
			<th>TournamentMode</th>
			<th>IsDeployTime</th>
			<th>IsTeamBattle</th>
			<th>SeqNumber</th>
			<th>IsToConquer</th>
			<th>IsInPlanet</th>
			<th>CurrentBot</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BattleItem runat="server">
		<tr>
			<td><OrionsBelt:BattleId runat="server" /></td>
			<td><OrionsBelt:BattleCurrentTurn runat="server" /></td>
			<td><OrionsBelt:BattleHasEnded runat="server" /></td>
			<td><OrionsBelt:BattleBattleType runat="server" /></td>
			<td><OrionsBelt:BattleBattleMode runat="server" /></td>
			<td><OrionsBelt:BattleUnitsDestroyed runat="server" /></td>
			<td><OrionsBelt:BattleTerrain runat="server" /></td>
			<td><OrionsBelt:BattleCurrentPlayer runat="server" /></td>
			<td><OrionsBelt:BattleTimeoutsAllowed runat="server" /></td>
			<td><OrionsBelt:BattleTournamentMode runat="server" /></td>
			<td><OrionsBelt:BattleIsDeployTime runat="server" /></td>
			<td><OrionsBelt:BattleIsTeamBattle runat="server" /></td>
			<td><OrionsBelt:BattleSeqNumber runat="server" /></td>
			<td><OrionsBelt:BattleIsToConquer runat="server" /></td>
			<td><OrionsBelt:BattleIsInPlanet runat="server" /></td>
			<td><OrionsBelt:BattleCurrentBot runat="server" /></td>
			<td><OrionsBelt:BattleCreatedDate runat="server" /></td>
			<td><OrionsBelt:BattleUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BattleLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BattleDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BattleItem>
	</table>
	</OrionsBelt:BattlePagedList>
</asp:Content>