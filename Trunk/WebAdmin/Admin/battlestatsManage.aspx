<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battlestats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BattleStatsPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BattleStatsNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BattleStatsIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:BattleStatsWinsSort InnerHtml="Wins" runat="server" /></th>
			<th><OrionsBelt:BattleStatsDefeatsSort InnerHtml="Defeats" runat="server" /></th>
			<th><OrionsBelt:BattleStatsTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:BattleStatsDetailSort InnerHtml="Detail" runat="server" /></th>
			<th><OrionsBelt:BattleStatsGiveUpsSort InnerHtml="GiveUps" runat="server" /></th>
			<th><OrionsBelt:BattleStatsCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:BattleStatsUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:BattleStatsLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BattleStatsItem runat="server">
		<tr>
			<td><OrionsBelt:BattleStatsId runat="server" /></td>
			<td><OrionsBelt:BattleStatsWins runat="server" /></td>
			<td><OrionsBelt:BattleStatsDefeats runat="server" /></td>
			<td><OrionsBelt:BattleStatsType runat="server" /></td>
			<td><OrionsBelt:BattleStatsDetail runat="server" /></td>
			<td><OrionsBelt:BattleStatsGiveUps runat="server" /></td>
			<td><OrionsBelt:BattleStatsCreatedDate runat="server" /></td>
			<td><OrionsBelt:BattleStatsUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BattleStatsLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BattleStatsDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BattleStatsItem>
	</table>
	<OrionsBelt:BattleStatsNumberPagination runat="server" />
	</OrionsBelt:BattleStatsPagedList>

</asp:Content>