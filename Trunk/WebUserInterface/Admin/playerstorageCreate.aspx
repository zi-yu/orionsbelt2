<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstorage";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create PlayerStorage</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PlayerStorageEditor runat="server" Source="New" ID="PlayerStorageEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PlayerStorageIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:PlayerStorageNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastProcessedTick</b></td>
			<td><OrionsBelt:PlayerStorageLastProcessedTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IntrinsicLimits</b></td>
			<td><OrionsBelt:PlayerStorageIntrinsicLimitsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Score</b></td>
			<td><OrionsBelt:PlayerStorageScoreEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>AllianceRank</b></td>
			<td><OrionsBelt:PlayerStorageAllianceRankEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Race</b></td>
			<td><OrionsBelt:PlayerStorageRaceEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>HomePlanetId</b></td>
			<td><OrionsBelt:PlayerStorageHomePlanetIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PirateRanking</b></td>
			<td><OrionsBelt:PlayerStoragePirateRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BountyRanking</b></td>
			<td><OrionsBelt:PlayerStorageBountyRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MerchantRanking</b></td>
			<td><OrionsBelt:PlayerStorageMerchantRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>GladiatorRanking</b></td>
			<td><OrionsBelt:PlayerStorageGladiatorRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ColonizerRanking</b></td>
			<td><OrionsBelt:PlayerStorageColonizerRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IntrinsicQuantities</b></td>
			<td><OrionsBelt:PlayerStorageIntrinsicQuantitiesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PlanetLevel</b></td>
			<td><OrionsBelt:PlayerStoragePlanetLevelEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>QuestContextLevel</b></td>
			<td><OrionsBelt:PlayerStorageQuestContextLevelEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Active</b></td>
			<td><OrionsBelt:PlayerStorageActiveEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Avatar</b></td>
			<td><OrionsBelt:PlayerStorageAvatarEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UltimateWeaponLevel</b></td>
			<td><OrionsBelt:PlayerStorageUltimateWeaponLevelEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Services</b></td>
			<td><OrionsBelt:PlayerStorageServicesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UltimateWeaponCooldown</b></td>
			<td><OrionsBelt:PlayerStorageUltimateWeaponCooldownEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ActivatedInTick</b></td>
			<td><OrionsBelt:PlayerStorageActivatedInTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsGeneralActive</b></td>
			<td><OrionsBelt:PlayerStorageIsGeneralActiveEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>GeneralId</b></td>
			<td><OrionsBelt:PlayerStorageGeneralIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>GeneralName</b></td>
			<td><OrionsBelt:PlayerStorageGeneralNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>GeneralFriendlyName</b></td>
			<td><OrionsBelt:PlayerStorageGeneralFriendlyNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsPrimary</b></td>
			<td><OrionsBelt:PlayerStorageIsPrimaryEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsOnVacations</b></td>
			<td><OrionsBelt:PlayerStorageIsOnVacationsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TotalPosts</b></td>
			<td><OrionsBelt:PlayerStorageTotalPostsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Signature</b></td>
			<td><OrionsBelt:PlayerStorageSignatureEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ForumRole</b></td>
			<td><OrionsBelt:PlayerStorageForumRoleEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Principal</b></td>
			<td><OrionsBelt:PlayerStoragePrincipalEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Alliance</b></td>
			<td><OrionsBelt:PlayerStorageAllianceEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Stats</b></td>
			<td><OrionsBelt:PlayerStorageStatsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PlayerStorageCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PlayerStorageUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PlayerStorageLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStorageEditor>
	</table>
	</asp:Content>