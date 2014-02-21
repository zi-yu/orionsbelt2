<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battle";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Battle</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:BattleEditor runat="server" Source="New" ID="BattleEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:BattleIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CurrentTurn</b></td>
			<td><OrionsBelt:BattleCurrentTurnEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>HasEnded</b></td>
			<td><OrionsBelt:BattleHasEndedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BattleType</b></td>
			<td><OrionsBelt:BattleBattleTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BattleMode</b></td>
			<td><OrionsBelt:BattleBattleModeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UnitsDestroyed</b></td>
			<td><OrionsBelt:BattleUnitsDestroyedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Terrain</b></td>
			<td><OrionsBelt:BattleTerrainEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CurrentPlayer</b></td>
			<td><OrionsBelt:BattleCurrentPlayerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TimeoutsAllowed</b></td>
			<td><OrionsBelt:BattleTimeoutsAllowedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TournamentMode</b></td>
			<td><OrionsBelt:BattleTournamentModeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsDeployTime</b></td>
			<td><OrionsBelt:BattleIsDeployTimeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsTeamBattle</b></td>
			<td><OrionsBelt:BattleIsTeamBattleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SeqNumber</b></td>
			<td><OrionsBelt:BattleSeqNumberEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsToConquer</b></td>
			<td><OrionsBelt:BattleIsToConquerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsInPlanet</b></td>
			<td><OrionsBelt:BattleIsInPlanetEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CurrentBot</b></td>
			<td><OrionsBelt:BattleCurrentBotEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Tournament</b></td>
			<td><OrionsBelt:BattleTournamentEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Group</b></td>
			<td><OrionsBelt:BattleGroupEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:BattleCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:BattleUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:BattleLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:BattleEditor>
	</table>
	</asp:Content>