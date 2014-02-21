<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenahistorical";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ArenaHistorical</h2>
	<p>Use this page to search for objects of the ArenaHistorical type.</p>
	<div class="searchTable">
		<OrionsBelt:ArenaHistoricalSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ArenaHistoricalPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>ChampionId</th>
			<th>ChallengerId</th>
			<th>Winner</th>
			<th>WinningSequence</th>
			<th>BattleId</th>
			<th>StartTick</th>
			<th>EndTick</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ArenaHistoricalPagedList>
</asp:Content>