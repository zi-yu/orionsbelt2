<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenastorage";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create ArenaStorage</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:ArenaStorageEditor runat="server" Source="New" ID="ArenaStorageEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:ArenaStorageIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:ArenaStorageNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsInBattle</b></td>
			<td><OrionsBelt:ArenaStorageIsInBattleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ConquestTick</b></td>
			<td><OrionsBelt:ArenaStorageConquestTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BattleType</b></td>
			<td><OrionsBelt:ArenaStorageBattleTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Coordinate</b></td>
			<td><OrionsBelt:ArenaStorageCoordinateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Payment</b></td>
			<td><OrionsBelt:ArenaStoragePaymentEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Level</b></td>
			<td><OrionsBelt:ArenaStorageLevelEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Fleet</b></td>
			<td><OrionsBelt:ArenaStorageFleetEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Owner</b></td>
			<td><OrionsBelt:ArenaStorageOwnerEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Sector</b></td>
			<td><OrionsBelt:ArenaStorageSectorEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:ArenaStorageCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:ArenaStorageUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:ArenaStorageLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:ArenaStorageEditor>
	</table>
	</asp:Content>