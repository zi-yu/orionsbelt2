<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenahistorical";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ArenaHistoricalPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ArenaHistoricalNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ArenaHistoricalIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalChampionIdSort InnerHtml="ChampionId" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalChallengerIdSort InnerHtml="ChallengerId" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalWinnerSort InnerHtml="Winner" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalWinningSequenceSort InnerHtml="WinningSequence" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalBattleIdSort InnerHtml="BattleId" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalStartTickSort InnerHtml="StartTick" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalEndTickSort InnerHtml="EndTick" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ArenaHistoricalLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ArenaHistoricalItem runat="server">
		<tr>
			<td><OrionsBelt:ArenaHistoricalId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalChampionId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalChallengerId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalWinner runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalWinningSequence runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalBattleId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalStartTick runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalEndTick runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalCreatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ArenaHistoricalItem>
	</table>
	<OrionsBelt:ArenaHistoricalNumberPagination runat="server" />
	</OrionsBelt:ArenaHistoricalPagedList>

</asp:Content>