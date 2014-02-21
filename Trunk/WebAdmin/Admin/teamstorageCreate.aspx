<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "teamstorage";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create TeamStorage</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:TeamStorageEditor runat="server" Source="New" ID="TeamStorageEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:TeamStorageIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:TeamStorageNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EloRanking</b></td>
			<td><OrionsBelt:TeamStorageEloRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberPlayedBattles</b></td>
			<td><OrionsBelt:TeamStorageNumberPlayedBattlesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LadderActive</b></td>
			<td><OrionsBelt:TeamStorageLadderActiveEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LadderPosition</b></td>
			<td><OrionsBelt:TeamStorageLadderPositionEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsInBattle</b></td>
			<td><OrionsBelt:TeamStorageIsInBattleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RestUntil</b></td>
			<td><OrionsBelt:TeamStorageRestUntilEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>StoppedUntil</b></td>
			<td><OrionsBelt:TeamStorageStoppedUntilEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MyStatsId</b></td>
			<td><OrionsBelt:TeamStorageMyStatsIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsComplete</b></td>
			<td><OrionsBelt:TeamStorageIsCompleteEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:TeamStorageCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:TeamStorageUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:TeamStorageLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:TeamStorageEditor>
	</table>
	</asp:Content>