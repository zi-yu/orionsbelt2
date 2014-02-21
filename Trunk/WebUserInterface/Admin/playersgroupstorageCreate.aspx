<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playersgroupstorage";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create PlayersGroupStorage</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PlayersGroupStorageEditor runat="server" Source="New" ID="PlayersGroupStorageEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PlayersGroupStorageIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EliminatoryNumber</b></td>
			<td><OrionsBelt:PlayersGroupStorageEliminatoryNumberEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PlayersIds</b></td>
			<td><OrionsBelt:PlayersGroupStoragePlayersIdsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>GroupNumber</b></td>
			<td><OrionsBelt:PlayersGroupStorageGroupNumberEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Tournament</b></td>
			<td><OrionsBelt:PlayersGroupStorageTournamentEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PlayersGroupStorageCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PlayersGroupStorageUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PlayersGroupStorageLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PlayersGroupStorageEditor>
	</table>
	</asp:Content>