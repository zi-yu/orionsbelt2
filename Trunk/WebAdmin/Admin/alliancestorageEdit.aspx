<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "alliancestorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:AllianceStorageEditor runat="server" Source="QueryString" ID="AllianceStorageEditorId1" >
	<h2>Edit AllianceStorage &lt;<OrionsBelt:AllianceStorageName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:AllianceStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Score</b></td>
			<td>
				<OrionsBelt:AllianceStorageScoreEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Karma</b></td>
			<td>
				<OrionsBelt:AllianceStorageKarmaEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalMembers</b></td>
			<td>
				<OrionsBelt:AllianceStorageTotalMembersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:AllianceStorageNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Tag</b></td>
			<td>
				<OrionsBelt:AllianceStorageTagEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Description</b></td>
			<td>
				<OrionsBelt:AllianceStorageDescriptionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Language</b></td>
			<td>
				<OrionsBelt:AllianceStorageLanguageEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Orions</b></td>
			<td>
				<OrionsBelt:AllianceStorageOrionsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>OpenToNewMembers</b></td>
			<td>
				<OrionsBelt:AllianceStorageOpenToNewMembersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalRelics</b></td>
			<td>
				<OrionsBelt:AllianceStorageTotalRelicsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalRelicsIncome</b></td>
			<td>
				<OrionsBelt:AllianceStorageTotalRelicsIncomeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:AllianceStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:AllianceStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:AllianceStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		AllianceStorage :: Players 
		[<a href='/admin/playerstorageCreate.aspx?PlayerStorageAllianceEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStoragePlayers runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Score</th>
			<th>Edit</th>
			<th title="Delete from AllianceStorage">Delete</th>
		</tr>
		<OrionsBelt:PlayerStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlayerStorageId runat="server" /></td>
			<td><OrionsBelt:PlayerStorageName runat="server" /></td>
			<td><OrionsBelt:PlayerStorageScore runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayerStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStorageItem>
	</table>
	</OrionsBelt:AllianceStoragePlayers>
	<h2>
		AllianceStorage :: DiplomacyA 
		[<a href='/admin/alliancediplomacyCreate.aspx?AllianceDiplomacyAllianceAEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStorageDiplomacyA runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Level</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from AllianceStorage">Delete</th>
		</tr>
		<OrionsBelt:AllianceDiplomacyItem runat="server">
		<tr>
			<td><OrionsBelt:AllianceDiplomacyId runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyLevel runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyCreatedDate runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyUpdatedDate runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AllianceDiplomacyItem>
	</table>
	</OrionsBelt:AllianceStorageDiplomacyA>
	<h2>
		AllianceStorage :: DiplomacyB 
		[<a href='/admin/alliancediplomacyCreate.aspx?AllianceDiplomacyAllianceBEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStorageDiplomacyB runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Level</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from AllianceStorage">Delete</th>
		</tr>
		<OrionsBelt:AllianceDiplomacyItem runat="server">
		<tr>
			<td><OrionsBelt:AllianceDiplomacyId runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyLevel runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyCreatedDate runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyUpdatedDate runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AllianceDiplomacyItem>
	</table>
	</OrionsBelt:AllianceStorageDiplomacyB>
	<h2>
		AllianceStorage :: Sector 
		[<a href='/admin/sectorstorageCreate.aspx?SectorStorageAllianceEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStorageSector runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Type</th>
			<th>SystemX</th>
			<th>SystemY</th>
			<th>SectorX</th>
			<th>SectorY</th>
			<th>Edit</th>
			<th title="Delete from AllianceStorage">Delete</th>
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
	</OrionsBelt:AllianceStorageSector>
	<h2>
		AllianceStorage :: Assets 
		[<a href='/admin/assetCreate.aspx?AssetAllianceEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStorageAssets runat="server">
		<table class="editTable">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th title="Delete from AllianceStorage">Delete</th>
		</tr>
		<OrionsBelt:AssetItem runat="server">
		<tr>
			<td><OrionsBelt:AssetDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AssetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AssetItem>
	</table>
	</OrionsBelt:AllianceStorageAssets>
	<h2>
		AllianceStorage :: Necessities 
		[<a href='/admin/necessityCreate.aspx?NecessityAllianceEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStorageNecessities runat="server">
		<table class="editTable">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th title="Delete from AllianceStorage">Delete</th>
		</tr>
		<OrionsBelt:NecessityItem runat="server">
		<tr>
			<td><OrionsBelt:NecessityDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:NecessityDelete runat="server" /></td>
		</tr>
		</OrionsBelt:NecessityItem>
	</table>
	</OrionsBelt:AllianceStorageNecessities>
	<h2>
		AllianceStorage :: Offerings 
		[<a href='/admin/offeringCreate.aspx?OfferingAllianceEditorFilter=<OrionsBelt:AllianceStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:AllianceStorageOfferings runat="server">
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
			<th title="Delete from AllianceStorage">Delete</th>
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
	</OrionsBelt:AllianceStorageOfferings>

	<h2>Delete AllianceStorage</h2>
	<p><OrionsBelt:AllianceStorageDelete OnDeleteRedirectTo="/admin/alliancestorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:AllianceStorageEditor>
</asp:Content>