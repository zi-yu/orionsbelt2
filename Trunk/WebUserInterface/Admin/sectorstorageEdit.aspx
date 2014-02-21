<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "sectorstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:SectorStorageEditor runat="server" Source="QueryString" ID="SectorStorageEditorId1" >
	<h2>Edit SectorStorage &lt;<OrionsBelt:SectorStorageType runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:SectorStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsStatic</b></td>
			<td>
				<OrionsBelt:SectorStorageIsStaticEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:SectorStorageTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SubType</b></td>
			<td>
				<OrionsBelt:SectorStorageSubTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemX</b></td>
			<td>
				<OrionsBelt:SectorStorageSystemXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemY</b></td>
			<td>
				<OrionsBelt:SectorStorageSystemYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorX</b></td>
			<td>
				<OrionsBelt:SectorStorageSectorXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorY</b></td>
			<td>
				<OrionsBelt:SectorStorageSectorYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AdditionalInformation</b></td>
			<td>
				<OrionsBelt:SectorStorageAdditionalInformationEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsInBattle</b></td>
			<td>
				<OrionsBelt:SectorStorageIsInBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsConstructing</b></td>
			<td>
				<OrionsBelt:SectorStorageIsConstructingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:SectorStorageLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsMoving</b></td>
			<td>
				<OrionsBelt:SectorStorageIsMovingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:SectorStorageOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Alliance</b></td>
			<td>
				<OrionsBelt:SectorStorageAllianceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:SectorStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:SectorStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:SectorStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		SectorStorage :: Fleets 
		[<a href='/admin/fleetCreate.aspx?FleetSectorEditorFilter=<OrionsBelt:SectorStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:SectorStorageFleets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Units</th>
			<th>IsMovable</th>
			<th>IsInBattle</th>
			<th>Edit</th>
			<th title="Delete from SectorStorage">Delete</th>
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
	</OrionsBelt:SectorStorageFleets>
	<h2>
		SectorStorage :: Planets 
		[<a href='/admin/planetstorageCreate.aspx?PlanetStorageSectorEditorFilter=<OrionsBelt:SectorStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:SectorStoragePlanets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>ProductionFactor</th>
			<th>Info</th>
			<th>Edit</th>
			<th title="Delete from SectorStorage">Delete</th>
		</tr>
		<OrionsBelt:PlanetStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlanetStorageId runat="server" /></td>
			<td><OrionsBelt:PlanetStorageName runat="server" /></td>
			<td><OrionsBelt:PlanetStorageProductionFactor runat="server" /></td>
			<td><OrionsBelt:PlanetStorageInfo runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlanetStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlanetStorageItem>
	</table>
	</OrionsBelt:SectorStoragePlanets>
	<h2>
		SectorStorage :: SpecialSectores 
		[<a href='/admin/universespecialsectorCreate.aspx?UniverseSpecialSectorSectorEditorFilter=<OrionsBelt:SectorStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:SectorStorageSpecialSectores runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>SectorX</th>
			<th>SectorY</th>
			<th>Edit</th>
			<th title="Delete from SectorStorage">Delete</th>
		</tr>
		<OrionsBelt:UniverseSpecialSectorItem runat="server">
		<tr>
			<td><OrionsBelt:UniverseSpecialSectorId runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSystemX runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSystemY runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSectorX runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorSectorY runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:UniverseSpecialSectorDelete runat="server" /></td>
		</tr>
		</OrionsBelt:UniverseSpecialSectorItem>
	</table>
	</OrionsBelt:SectorStorageSpecialSectores>
	<h2>
		SectorStorage :: Arenas 
		[<a href='/admin/arenastorageCreate.aspx?ArenaStorageSectorEditorFilter=<OrionsBelt:SectorStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:SectorStorageArenas runat="server">
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
			<th title="Delete from SectorStorage">Delete</th>
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
	</OrionsBelt:SectorStorageArenas>
	<h2>
		SectorStorage :: Markets 
		[<a href='/admin/marketCreate.aspx?MarketSectorEditorFilter=<OrionsBelt:SectorStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:SectorStorageMarkets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Level</th>
			<th>Coordinates</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from SectorStorage">Delete</th>
		</tr>
		<OrionsBelt:MarketItem runat="server">
		<tr>
			<td><OrionsBelt:MarketId runat="server" /></td>
			<td><OrionsBelt:MarketName runat="server" /></td>
			<td><OrionsBelt:MarketLevel runat="server" /></td>
			<td><OrionsBelt:MarketCoordinates runat="server" /></td>
			<td><OrionsBelt:MarketCreatedDate runat="server" /></td>
			<td><OrionsBelt:MarketUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MarketLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MarketDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MarketItem>
	</table>
	</OrionsBelt:SectorStorageMarkets>

	<h2>Delete SectorStorage</h2>
	<p><OrionsBelt:SectorStorageDelete OnDeleteRedirectTo="/admin/sectorstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:SectorStorageEditor>
</asp:Content>