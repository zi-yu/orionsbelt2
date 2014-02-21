<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PlayerStorageEditor runat="server" Source="QueryString" ID="PlayerStorageEditorId1" >
	<h2>Edit PlayerStorage &lt;<OrionsBelt:PlayerStorageName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PlayerStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:PlayerStorageNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastProcessedTick</b></td>
			<td>
				<OrionsBelt:PlayerStorageLastProcessedTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IntrinsicLimits</b></td>
			<td>
				<OrionsBelt:PlayerStorageIntrinsicLimitsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Score</b></td>
			<td>
				<OrionsBelt:PlayerStorageScoreEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AllianceRank</b></td>
			<td>
				<OrionsBelt:PlayerStorageAllianceRankEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Race</b></td>
			<td>
				<OrionsBelt:PlayerStorageRaceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HomePlanetId</b></td>
			<td>
				<OrionsBelt:PlayerStorageHomePlanetIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PirateRanking</b></td>
			<td>
				<OrionsBelt:PlayerStoragePirateRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BountyRanking</b></td>
			<td>
				<OrionsBelt:PlayerStorageBountyRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MerchantRanking</b></td>
			<td>
				<OrionsBelt:PlayerStorageMerchantRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GladiatorRanking</b></td>
			<td>
				<OrionsBelt:PlayerStorageGladiatorRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ColonizerRanking</b></td>
			<td>
				<OrionsBelt:PlayerStorageColonizerRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IntrinsicQuantities</b></td>
			<td>
				<OrionsBelt:PlayerStorageIntrinsicQuantitiesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PlanetLevel</b></td>
			<td>
				<OrionsBelt:PlayerStoragePlanetLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>QuestContextLevel</b></td>
			<td>
				<OrionsBelt:PlayerStorageQuestContextLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Active</b></td>
			<td>
				<OrionsBelt:PlayerStorageActiveEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Avatar</b></td>
			<td>
				<OrionsBelt:PlayerStorageAvatarEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UltimateWeaponLevel</b></td>
			<td>
				<OrionsBelt:PlayerStorageUltimateWeaponLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Services</b></td>
			<td>
				<OrionsBelt:PlayerStorageServicesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UltimateWeaponCooldown</b></td>
			<td>
				<OrionsBelt:PlayerStorageUltimateWeaponCooldownEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ActivatedInTick</b></td>
			<td>
				<OrionsBelt:PlayerStorageActivatedInTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsGeneralActive</b></td>
			<td>
				<OrionsBelt:PlayerStorageIsGeneralActiveEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GeneralId</b></td>
			<td>
				<OrionsBelt:PlayerStorageGeneralIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GeneralName</b></td>
			<td>
				<OrionsBelt:PlayerStorageGeneralNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GeneralFriendlyName</b></td>
			<td>
				<OrionsBelt:PlayerStorageGeneralFriendlyNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsPrimary</b></td>
			<td>
				<OrionsBelt:PlayerStorageIsPrimaryEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsOnVacations</b></td>
			<td>
				<OrionsBelt:PlayerStorageIsOnVacationsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalPosts</b></td>
			<td>
				<OrionsBelt:PlayerStorageTotalPostsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Signature</b></td>
			<td>
				<OrionsBelt:PlayerStorageSignatureEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ForumRole</b></td>
			<td>
				<OrionsBelt:PlayerStorageForumRoleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:PlayerStoragePrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Alliance</b></td>
			<td>
				<OrionsBelt:PlayerStorageAllianceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Stats</b></td>
			<td>
				<OrionsBelt:PlayerStorageStatsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PlayerStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PlayerStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PlayerStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		PlayerStorage :: Actions 
		[<a href='/admin/timedactionstorageCreate.aspx?TimedActionStoragePlayerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageActions runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>StartTick</th>
			<th>EndTick</th>
			<th>Data</th>
			<th>Name</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:TimedActionStorageItem runat="server">
		<tr>
			<td><OrionsBelt:TimedActionStorageId runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageStartTick runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageEndTick runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageData runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageName runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TimedActionStorageItem>
	</table>
	</OrionsBelt:PlayerStorageActions>
	<h2>
		PlayerStorage :: Planets 
		[<a href='/admin/planetstorageCreate.aspx?PlanetStoragePlayerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStoragePlanets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>ProductionFactor</th>
			<th>Info</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
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
	</OrionsBelt:PlayerStoragePlanets>
	<h2>
		PlayerStorage :: Resources 
		[<a href='/admin/planetresourcestorageCreate.aspx?PlanetResourceStoragePlayerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageResources runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Quantity</th>
			<th>Level</th>
			<th>Type</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
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
	</OrionsBelt:PlayerStorageResources>
	<h2>
		PlayerStorage :: Sector 
		[<a href='/admin/sectorstorageCreate.aspx?SectorStorageOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageSector runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Type</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>SectorX</th>
			<th>SectorY</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:SectorStorageItem runat="server">
		<tr>
			<td><OrionsBelt:SectorStorageId runat="server" /></td>
			<td><OrionsBelt:SectorStorageType runat="server" /></td>
			<td><OrionsBelt:SectorStorageSystemX runat="server" /></td>
			<td><OrionsBelt:SectorStorageSystemY runat="server" /></td>
			<td><OrionsBelt:SectorStorageSectorX runat="server" /></td>
			<td><OrionsBelt:SectorStorageSectorY runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:SectorStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:SectorStorageItem>
	</table>
	</OrionsBelt:PlayerStorageSector>
	<h2>
		PlayerStorage :: DiscoveredUniverse 
		[<a href='/admin/fogofwarstorageCreate.aspx?FogOfWarStorageOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageDiscoveredUniverse runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>HasDiscoveredAll</th>
			<th>HasDiscoveredHalf</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:FogOfWarStorageItem runat="server">
		<tr>
			<td><OrionsBelt:FogOfWarStorageId runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageSystemX runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageSystemY runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageHasDiscoveredAll runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageHasDiscoveredHalf runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FogOfWarStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FogOfWarStorageItem>
	</table>
	</OrionsBelt:PlayerStorageDiscoveredUniverse>
	<h2>
		PlayerStorage :: Fleets 
		[<a href='/admin/fleetCreate.aspx?FleetPlayerOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageFleets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Units</th>
			<th>IsMovable</th>
			<th>IsInBattle</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
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
	</OrionsBelt:PlayerStorageFleets>
	<h2>
		PlayerStorage :: SpecialSectores 
		[<a href='/admin/universespecialsectorCreate.aspx?UniverseSpecialSectorOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageSpecialSectores runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>SectorX</th>
			<th>SectorY</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
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
	</OrionsBelt:PlayerStorageSpecialSectores>
	<h2>
		PlayerStorage :: Quests 
		[<a href='/admin/queststorageCreate.aspx?QuestStoragePlayerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageQuests runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Percentage</th>
			<th>Name</th>
			<th>Type</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:QuestStorageItem runat="server">
		<tr>
			<td><OrionsBelt:QuestStorageId runat="server" /></td>
			<td><OrionsBelt:QuestStoragePercentage runat="server" /></td>
			<td><OrionsBelt:QuestStorageName runat="server" /></td>
			<td><OrionsBelt:QuestStorageType runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:QuestStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:QuestStorageItem>
	</table>
	</OrionsBelt:PlayerStorageQuests>
	<h2>
		PlayerStorage :: Bids 
		[<a href='/admin/bidhistoricalCreate.aspx?BidHistoricalMadeByEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageBids runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Value</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:BidHistoricalItem runat="server">
		<tr>
			<td><OrionsBelt:BidHistoricalId runat="server" /></td>
			<td><OrionsBelt:BidHistoricalValue runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BidHistoricalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BidHistoricalItem>
	</table>
	</OrionsBelt:PlayerStorageBids>
	<h2>
		PlayerStorage :: Auction 
		[<a href='/admin/auctionhouseCreate.aspx?AuctionHouseOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageAuction runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>CurrentBid</th>
			<th>Details</th>
			<th>BuyedInTick</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:AuctionHouseItem runat="server">
		<tr>
			<td><OrionsBelt:AuctionHouseId runat="server" /></td>
			<td><OrionsBelt:AuctionHouseCurrentBid runat="server" /></td>
			<td><OrionsBelt:AuctionHouseDetails runat="server" /></td>
			<td><OrionsBelt:AuctionHouseBuyedInTick runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AuctionHouseDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AuctionHouseItem>
	</table>
	</OrionsBelt:PlayerStorageAuction>
	<h2>
		PlayerStorage :: Arena 
		[<a href='/admin/arenastorageCreate.aspx?ArenaStorageOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageArena runat="server">
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
			<th title="Delete from PlayerStorage">Delete</th>
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
	</OrionsBelt:PlayerStorageArena>
	<h2>
		PlayerStorage :: MyFriends 
		[<a href='/admin/friendorfoeCreate.aspx?FriendOrFoeSourceEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageMyFriends runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>IsFriend</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:FriendOrFoeItem runat="server">
		<tr>
			<td><OrionsBelt:FriendOrFoeId runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeIsFriend runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeCreatedDate runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeUpdatedDate runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FriendOrFoeItem>
	</table>
	</OrionsBelt:PlayerStorageMyFriends>
	<h2>
		PlayerStorage :: OtherFriends 
		[<a href='/admin/friendorfoeCreate.aspx?FriendOrFoeTargetEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageOtherFriends runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>IsFriend</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:FriendOrFoeItem runat="server">
		<tr>
			<td><OrionsBelt:FriendOrFoeId runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeIsFriend runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeCreatedDate runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeUpdatedDate runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FriendOrFoeItem>
	</table>
	</OrionsBelt:PlayerStorageOtherFriends>
	<h2>
		PlayerStorage :: Medals 
		[<a href='/admin/medalCreate.aspx?MedalPlayerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageMedals runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>IsAuto</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:MedalItem runat="server">
		<tr>
			<td><OrionsBelt:MedalId runat="server" /></td>
			<td><OrionsBelt:MedalName runat="server" /></td>
			<td><OrionsBelt:MedalIsAuto runat="server" /></td>
			<td><OrionsBelt:MedalCreatedDate runat="server" /></td>
			<td><OrionsBelt:MedalUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MedalLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MedalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MedalItem>
	</table>
	</OrionsBelt:PlayerStorageMedals>
	<h2>
		PlayerStorage :: Messages 
		[<a href='/admin/privateboardCreate.aspx?PrivateBoardSenderEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageMessages runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Receiver</th>
			<th>Type</th>
			<th>Message</th>
			<th>WasRead</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:PrivateBoardItem runat="server">
		<tr>
			<td><OrionsBelt:PrivateBoardId runat="server" /></td>
			<td><OrionsBelt:PrivateBoardReceiver runat="server" /></td>
			<td><OrionsBelt:PrivateBoardType runat="server" /></td>
			<td><OrionsBelt:PrivateBoardMessage runat="server" /></td>
			<td><OrionsBelt:PrivateBoardWasRead runat="server" /></td>
			<td><OrionsBelt:PrivateBoardCreatedDate runat="server" /></td>
			<td><OrionsBelt:PrivateBoardUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PrivateBoardLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrivateBoardDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrivateBoardItem>
	</table>
	</OrionsBelt:PlayerStorageMessages>
	<h2>
		PlayerStorage :: Assets 
		[<a href='/admin/assetCreate.aspx?AssetOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageAssets runat="server">
		<table class="editTable">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:AssetItem runat="server">
		<tr>
			<td><OrionsBelt:AssetDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AssetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AssetItem>
	</table>
	</OrionsBelt:PlayerStorageAssets>
	<h2>
		PlayerStorage :: Necessities 
		[<a href='/admin/necessityCreate.aspx?NecessityCreatorEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageNecessities runat="server">
		<table class="editTable">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:NecessityItem runat="server">
		<tr>
			<td><OrionsBelt:NecessityDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:NecessityDelete runat="server" /></td>
		</tr>
		</OrionsBelt:NecessityItem>
	</table>
	</OrionsBelt:PlayerStorageNecessities>
	<h2>
		PlayerStorage :: Offerings 
		[<a href='/admin/offeringCreate.aspx?OfferingDonorEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageOfferings runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>InitialValue</th>
			<th>CurrentValue</th>
			<th>Product</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:OfferingItem runat="server">
		<tr>
			<td><OrionsBelt:OfferingId runat="server" /></td>
			<td><OrionsBelt:OfferingInitialValue runat="server" /></td>
			<td><OrionsBelt:OfferingCurrentValue runat="server" /></td>
			<td><OrionsBelt:OfferingProduct runat="server" /></td>
			<td><OrionsBelt:OfferingCreatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingUpdatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:OfferingDelete runat="server" /></td>
		</tr>
		</OrionsBelt:OfferingItem>
	</table>
	</OrionsBelt:PlayerStorageOfferings>
	<h2>
		PlayerStorage :: Forfeit 
		[<a href='/admin/offeringCreate.aspx?OfferingReceiverEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageForfeit runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>InitialValue</th>
			<th>CurrentValue</th>
			<th>Product</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:OfferingItem runat="server">
		<tr>
			<td><OrionsBelt:OfferingId runat="server" /></td>
			<td><OrionsBelt:OfferingInitialValue runat="server" /></td>
			<td><OrionsBelt:OfferingCurrentValue runat="server" /></td>
			<td><OrionsBelt:OfferingProduct runat="server" /></td>
			<td><OrionsBelt:OfferingCreatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingUpdatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:OfferingDelete runat="server" /></td>
		</tr>
		</OrionsBelt:OfferingItem>
	</table>
	</OrionsBelt:PlayerStorageForfeit>
	<h2>
		PlayerStorage :: Threads 
		[<a href='/admin/forumthreadCreate.aspx?ForumThreadOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageThreads runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Title</th>
			<th>TotalViews</th>
			<th>TotalReplies</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:ForumThreadItem runat="server">
		<tr>
			<td><OrionsBelt:ForumThreadId runat="server" /></td>
			<td><OrionsBelt:ForumThreadTitle runat="server" /></td>
			<td><OrionsBelt:ForumThreadTotalViews runat="server" /></td>
			<td><OrionsBelt:ForumThreadTotalReplies runat="server" /></td>
			<td><OrionsBelt:ForumThreadCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumThreadUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumThreadLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumThreadDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumThreadItem>
	</table>
	</OrionsBelt:PlayerStorageThreads>
	<h2>
		PlayerStorage :: Posts 
		[<a href='/admin/forumpostCreate.aspx?ForumPostOwnerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStoragePosts runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Text</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:ForumPostItem runat="server">
		<tr>
			<td><OrionsBelt:ForumPostId runat="server" /></td>
			<td><OrionsBelt:ForumPostText runat="server" /></td>
			<td><OrionsBelt:ForumPostCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumPostUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumPostLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumPostDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumPostItem>
	</table>
	</OrionsBelt:PlayerStoragePosts>
	<h2>
		PlayerStorage :: ReadMarkings 
		[<a href='/admin/forumreadmarkingCreate.aspx?ForumReadMarkingPlayerEditorFilter=<OrionsBelt:PlayerStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStorageReadMarkings runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>LastRead</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PlayerStorage">Delete</th>
		</tr>
		<OrionsBelt:ForumReadMarkingItem runat="server">
		<tr>
			<td><OrionsBelt:ForumReadMarkingId runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingLastRead runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumReadMarkingItem>
	</table>
	</OrionsBelt:PlayerStorageReadMarkings>

	<h2>Delete PlayerStorage</h2>
	<p><OrionsBelt:PlayerStorageDelete OnDeleteRedirectTo="/admin/playerstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:PlayerStorageEditor>
</asp:Content>