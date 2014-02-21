<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "planetstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PlanetStorageEditor runat="server" Source="QueryString" ID="PlanetStorageEditorId1" >
	<h2>Edit PlanetStorage &lt;<OrionsBelt:PlanetStorageName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PlanetStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:PlanetStorageNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ProductionFactor</b></td>
			<td>
				<OrionsBelt:PlanetStorageProductionFactorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Modifiers</b></td>
			<td>
				<OrionsBelt:PlanetStorageModifiersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Richness</b></td>
			<td>
				<OrionsBelt:PlanetStorageRichnessEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Info</b></td>
			<td>
				<OrionsBelt:PlanetStorageInfoEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Terrain</b></td>
			<td>
				<OrionsBelt:PlanetStorageTerrainEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsPrivate</b></td>
			<td>
				<OrionsBelt:PlanetStorageIsPrivateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemX</b></td>
			<td>
				<OrionsBelt:PlanetStorageSystemXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemY</b></td>
			<td>
				<OrionsBelt:PlanetStorageSystemYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorX</b></td>
			<td>
				<OrionsBelt:PlanetStorageSectorXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorY</b></td>
			<td>
				<OrionsBelt:PlanetStorageSectorYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Score</b></td>
			<td>
				<OrionsBelt:PlanetStorageScoreEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:PlanetStorageLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastPillageTick</b></td>
			<td>
				<OrionsBelt:PlanetStorageLastPillageTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastConquerTick</b></td>
			<td>
				<OrionsBelt:PlanetStorageLastConquerTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>FacilityLevel</b></td>
			<td>
				<OrionsBelt:PlanetStorageFacilityLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Player</b></td>
			<td>
				<OrionsBelt:PlanetStoragePlayerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sector</b></td>
			<td>
				<OrionsBelt:PlanetStorageSectorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PlanetStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PlanetStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PlanetStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		PlanetStorage :: Fleets 
		[<a href='/admin/fleetCreate.aspx?FleetCurrentPlanetEditorFilter=<OrionsBelt:PlanetStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlanetStorageFleets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Units</th>
			<th>IsMovable</th>
			<th>IsInBattle</th>
			<th>Edit</th>
			<th title="Delete from PlanetStorage">Delete</th>
		</tr>
		<OrionsBelt:FleetItem runat="server">
		<tr>
			<td><OrionsBelt:FleetId runat="server" /></td>
			<td><OrionsBelt:FleetName runat="server" /></td>
			<td><OrionsBelt:FleetUnits runat="server" /></td>
			<td><OrionsBelt:FleetIsMovable runat="server" /></td>
			<td><OrionsBelt:FleetIsInBattle runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FleetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FleetItem>
	</table>
	</OrionsBelt:PlanetStorageFleets>
	<h2>
		PlanetStorage :: Resources 
		[<a href='/admin/planetresourcestorageCreate.aspx?PlanetResourceStoragePlanetEditorFilter=<OrionsBelt:PlanetStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlanetStorageResources runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Quantity</th>
			<th>Level</th>
			<th>Type</th>
			<th>Edit</th>
			<th title="Delete from PlanetStorage">Delete</th>
		</tr>
		<OrionsBelt:PlanetResourceStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlanetResourceStorageId runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageQuantity runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageLevel runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageType runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlanetResourceStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlanetResourceStorageItem>
	</table>
	</OrionsBelt:PlanetStorageResources>

	<h2>Delete PlanetStorage</h2>
	<p><OrionsBelt:PlanetStorageDelete OnDeleteRedirectTo="/admin/planetstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:PlanetStorageEditor>
</asp:Content>