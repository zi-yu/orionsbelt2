<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fleet";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:FleetEditor runat="server" Source="QueryString" ID="FleetEditorId1" >
	<h2>Edit Fleet &lt;<OrionsBelt:FleetName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:FleetIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:FleetNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Units</b></td>
			<td>
				<OrionsBelt:FleetUnitsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TournamentFleet</b></td>
			<td>
				<OrionsBelt:FleetTournamentFleetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsMovable</b></td>
			<td>
				<OrionsBelt:FleetIsMovableEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UltimateUnit</b></td>
			<td>
				<OrionsBelt:FleetUltimateUnitEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsInBattle</b></td>
			<td>
				<OrionsBelt:FleetIsInBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsPlanetDefenseFleet</b></td>
			<td>
				<OrionsBelt:FleetIsPlanetDefenseFleetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemX</b></td>
			<td>
				<OrionsBelt:FleetSystemXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemY</b></td>
			<td>
				<OrionsBelt:FleetSystemYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorX</b></td>
			<td>
				<OrionsBelt:FleetSectorXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorY</b></td>
			<td>
				<OrionsBelt:FleetSectorYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Cargo</b></td>
			<td>
				<OrionsBelt:FleetCargoEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsBot</b></td>
			<td>
				<OrionsBelt:FleetIsBotEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WayPoints</b></td>
			<td>
				<OrionsBelt:FleetWayPointsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ImmunityStartTick</b></td>
			<td>
				<OrionsBelt:FleetImmunityStartTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CurrentPlanet</b></td>
			<td>
				<OrionsBelt:FleetCurrentPlanetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PrincipalOwner</b></td>
			<td>
				<OrionsBelt:FleetPrincipalOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sector</b></td>
			<td>
				<OrionsBelt:FleetSectorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PlayerOwner</b></td>
			<td>
				<OrionsBelt:FleetPlayerOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:FleetCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:FleetUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:FleetLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Fleet :: Arena 
		[<a href='/admin/arenastorageCreate.aspx?ArenaStorageFleetEditorFilter=<OrionsBelt:FleetId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:FleetArena runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>IsInBattle</th>
			<th>ConquestTick</th>
			<th>BattleType</th>
			<th>Coordinate</th>
			<th>Payment</th>
			<th>Level</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Fleet">Delete</th>
		</tr>
		<OrionsBelt:ArenaStorageItem runat="server">
		<tr>
			<td><OrionsBelt:ArenaStorageId runat="server" /></td>
			<td><OrionsBelt:ArenaStorageName runat="server" /></td>
			<td><OrionsBelt:ArenaStorageIsInBattle runat="server" /></td>
			<td><OrionsBelt:ArenaStorageConquestTick runat="server" /></td>
			<td><OrionsBelt:ArenaStorageBattleType runat="server" /></td>
			<td><OrionsBelt:ArenaStorageCoordinate runat="server" /></td>
			<td><OrionsBelt:ArenaStoragePayment runat="server" /></td>
			<td><OrionsBelt:ArenaStorageLevel runat="server" /></td>
			<td><OrionsBelt:ArenaStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ArenaStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ArenaStorageItem>
	</table>
	</OrionsBelt:FleetArena>

	<h2>Delete Fleet</h2>
	<p><OrionsBelt:FleetDelete OnDeleteRedirectTo="/admin/fleetManage.aspx" runat="server" /></p>
	
</OrionsBelt:FleetEditor>
</asp:Content>