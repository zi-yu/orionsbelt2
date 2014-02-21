<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battleextention";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search BattleExtention</h2>
	<p>Use this page to search for objects of the BattleExtention type.</p>
	<div class="searchTable">
		<OrionsBelt:BattleExtentionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BattleExtentionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>BattleFinalStates</th>
			<th>BattleMovements</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:BattleExtentionPagedList>
</asp:Content>