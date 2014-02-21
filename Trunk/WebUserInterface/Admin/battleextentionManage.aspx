<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battleextention";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BattleExtentionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BattleExtentionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BattleExtentionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:BattleExtentionBattleFinalStatesSort InnerHtml="BattleFinalStates" runat="server" /></th>
			<th><OrionsBelt:BattleExtentionBattleMovementsSort InnerHtml="BattleMovements" runat="server" /></th>
			<th><OrionsBelt:BattleExtentionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:BattleExtentionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:BattleExtentionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BattleExtentionItem runat="server">
		<tr>
			<td><OrionsBelt:BattleExtentionId runat="server" /></td>
			<td><OrionsBelt:BattleExtentionBattleFinalStates runat="server" /></td>
			<td><OrionsBelt:BattleExtentionBattleMovements runat="server" /></td>
			<td><OrionsBelt:BattleExtentionCreatedDate runat="server" /></td>
			<td><OrionsBelt:BattleExtentionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BattleExtentionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BattleExtentionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BattleExtentionItem>
	</table>
	<OrionsBelt:BattleExtentionNumberPagination runat="server" />
	</OrionsBelt:BattleExtentionPagedList>

</asp:Content>