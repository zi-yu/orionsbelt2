<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerbattleinformation";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PlayerBattleInformation</h2>
	<p>Use this page to search for objects of the PlayerBattleInformation type.</p>
	<div class="searchTable">
		<OrionsBelt:PlayerBattleInformationSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PlayerBattleInformationPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>InitialContainer</th>
			<th>HasPositioned</th>
			<th>TeamNumber</th>
			<th>HasLost</th>
			<th>WinScore</th>
			<th>FleetId</th>
			<th>UpdateFleet</th>
			<th>HasGaveUp</th>
			<th>LoseScore</th>
			<th>VictoryPercentage</th>
			<th>DominationPoints</th>
			<th>Timeouts</th>
			<th>Owner</th>
			<th>Name</th>
			<th>TeamName</th>
			<th>UltimateUnit</th>
			<th>BotId</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PlayerBattleInformationItem runat="server">
		<tr>
			<td><OrionsBelt:PlayerBattleInformationId runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationInitialContainer runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationHasPositioned runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationTeamNumber runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationHasLost runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationWinScore runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationFleetId runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationUpdateFleet runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationHasGaveUp runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationLoseScore runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationVictoryPercentage runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationDominationPoints runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationTimeouts runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationOwner runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationName runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationTeamName runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationUltimateUnit runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationBotId runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationCreatedDate runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayerBattleInformationDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerBattleInformationItem>
	</table>
	</OrionsBelt:PlayerBattleInformationPagedList>
</asp:Content>