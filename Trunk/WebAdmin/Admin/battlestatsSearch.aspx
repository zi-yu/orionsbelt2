<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battlestats";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search BattleStats</h2>
	<p>Use this page to search for objects of the BattleStats type.</p>
	<div class="searchTable">
		<OrionsBelt:BattleStatsSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BattleStatsPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Wins</th>
			<th>Defeats</th>
			<th>Type</th>
			<th>Detail</th>
			<th>GiveUps</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:BattleStatsPagedList>
</asp:Content>