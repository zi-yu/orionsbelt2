<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battle";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BattlePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BattleNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BattleIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:BattleCurrentTurnSort InnerHtml="CurrentTurn" runat="server" /></th>
			<th><OrionsBelt:BattleHasEndedSort InnerHtml="HasEnded" runat="server" /></th>
			<th><OrionsBelt:BattleBattleTypeSort InnerHtml="BattleType" runat="server" /></th>
			<th><OrionsBelt:BattleBattleModeSort InnerHtml="BattleMode" runat="server" /></th>
			<th><OrionsBelt:BattleUnitsDestroyedSort InnerHtml="UnitsDestroyed" runat="server" /></th>
			<th><OrionsBelt:BattleTerrainSort InnerHtml="Terrain" runat="server" /></th>
			<th><OrionsBelt:BattleCurrentPlayerSort InnerHtml="CurrentPlayer" runat="server" /></th>
			<th><OrionsBelt:BattleTimeoutsAllowedSort InnerHtml="TimeoutsAllowed" runat="server" /></th>
			<th><OrionsBelt:BattleTournamentModeSort InnerHtml="TournamentMode" runat="server" /></th>
			<th><OrionsBelt:BattleIsDeployTimeSort InnerHtml="IsDeployTime" runat="server" /></th>
			<th><OrionsBelt:BattleIsTeamBattleSort InnerHtml="IsTeamBattle" runat="server" /></th>
			<th><OrionsBelt:BattleSeqNumberSort InnerHtml="SeqNumber" runat="server" /></th>
			<th><OrionsBelt:BattleIsToConquerSort InnerHtml="IsToConquer" runat="server" /></th>
			<th><OrionsBelt:BattleIsInPlanetSort InnerHtml="IsInPlanet" runat="server" /></th>
			<th><OrionsBelt:BattleCurrentBotSort InnerHtml="CurrentBot" runat="server" /></th>
			<th><OrionsBelt:BattleCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:BattleUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:BattleLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:BattleNumberPagination runat="server" />
	</OrionsBelt:BattlePagedList>

</asp:Content>