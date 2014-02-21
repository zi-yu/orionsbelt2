<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battleextention";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create BattleExtention</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:BattleExtentionEditor runat="server" Source="New" ID="BattleExtentionEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:BattleExtentionIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BattleFinalStates</b></td>
			<td><OrionsBelt:BattleExtentionBattleFinalStatesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BattleMovements</b></td>
			<td><OrionsBelt:BattleExtentionBattleMovementsEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Battle</b></td>
			<td><OrionsBelt:BattleExtentionBattleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:BattleExtentionCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:BattleExtentionUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:BattleExtentionLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:BattleExtentionEditor>
	</table>
	</asp:Content>