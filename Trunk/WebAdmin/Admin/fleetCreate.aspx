<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fleet";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Fleet</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:FleetEditor runat="server" Source="New" ID="FleetEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:FleetIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:FleetNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Units</b></td>
			<td><OrionsBelt:FleetUnitsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TournamentFleet</b></td>
			<td><OrionsBelt:FleetTournamentFleetEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsMovable</b></td>
			<td><OrionsBelt:FleetIsMovableEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UltimateUnit</b></td>
			<td><OrionsBelt:FleetUltimateUnitEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsInBattle</b></td>
			<td><OrionsBelt:FleetIsInBattleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsPlanetDefenseFleet</b></td>
			<td><OrionsBelt:FleetIsPlanetDefenseFleetEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SystemX</b></td>
			<td><OrionsBelt:FleetSystemXEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SystemY</b></td>
			<td><OrionsBelt:FleetSystemYEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SectorX</b></td>
			<td><OrionsBelt:FleetSectorXEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SectorY</b></td>
			<td><OrionsBelt:FleetSectorYEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Cargo</b></td>
			<td><OrionsBelt:FleetCargoEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsBot</b></td>
			<td><OrionsBelt:FleetIsBotEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>WayPoints</b></td>
			<td><OrionsBelt:FleetWayPointsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ImmunityStartTick</b></td>
			<td><OrionsBelt:FleetImmunityStartTickEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>CurrentPlanet</b></td>
			<td><OrionsBelt:FleetCurrentPlanetEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>PrincipalOwner</b></td>
			<td><OrionsBelt:FleetPrincipalOwnerEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Sector</b></td>
			<td><OrionsBelt:FleetSectorEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>PlayerOwner</b></td>
			<td><OrionsBelt:FleetPlayerOwnerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:FleetCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:FleetUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:FleetLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:FleetEditor>
	</table>
	</asp:Content>