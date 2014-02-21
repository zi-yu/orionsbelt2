<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "tournament";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Tournament</h2>
	<p>Use this page to search for objects of the Tournament type.</p>
	<div class="searchTable">
		<OrionsBelt:TournamentSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:TournamentPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>WarningTick</th>
			<th>Prize</th>
			<th>CostCredits</th>
			<th>TournamentType</th>
			<th>FleetId</th>
			<th>IsPublic</th>
			<th>IsSurvival</th>
			<th>TurnTime</th>
			<th>SubscriptionTime</th>
			<th>MaxPlayers</th>
			<th>MinPlayers</th>
			<th>NPlayersToPlayoff</th>
			<th>MaxElo</th>
			<th>MinElo</th>
			<th>StartTime</th>
			<th>EndDate</th>
			<th>Token</th>
			<th>TokenNumber</th>
			<th>IsCustom</th>
			<th>PaymentsRequired</th>
			<th>NumberPassGroup</th>
			<th>DescriptionToken</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:TournamentItem runat="server">
		<tr>
			<td><OrionsBelt:TournamentId runat="server" /></td>
			<td><OrionsBelt:TournamentName runat="server" /></td>
			<td><OrionsBelt:TournamentWarningTick runat="server" /></td>
			<td><OrionsBelt:TournamentPrize runat="server" /></td>
			<td><OrionsBelt:TournamentCostCredits runat="server" /></td>
			<td><OrionsBelt:TournamentTournamentType runat="server" /></td>
			<td><OrionsBelt:TournamentFleetId runat="server" /></td>
			<td><OrionsBelt:TournamentIsPublic runat="server" /></td>
			<td><OrionsBelt:TournamentIsSurvival runat="server" /></td>
			<td><OrionsBelt:TournamentTurnTime runat="server" /></td>
			<td><OrionsBelt:TournamentSubscriptionTime runat="server" /></td>
			<td><OrionsBelt:TournamentMaxPlayers runat="server" /></td>
			<td><OrionsBelt:TournamentMinPlayers runat="server" /></td>
			<td><OrionsBelt:TournamentNPlayersToPlayoff runat="server" /></td>
			<td><OrionsBelt:TournamentMaxElo runat="server" /></td>
			<td><OrionsBelt:TournamentMinElo runat="server" /></td>
			<td><OrionsBelt:TournamentStartTime runat="server" /></td>
			<td><OrionsBelt:TournamentEndDate runat="server" /></td>
			<td><OrionsBelt:TournamentToken runat="server" /></td>
			<td><OrionsBelt:TournamentTokenNumber runat="server" /></td>
			<td><OrionsBelt:TournamentIsCustom runat="server" /></td>
			<td><OrionsBelt:TournamentPaymentsRequired runat="server" /></td>
			<td><OrionsBelt:TournamentNumberPassGroup runat="server" /></td>
			<td><OrionsBelt:TournamentDescriptionToken runat="server" /></td>
			<td><OrionsBelt:TournamentCreatedDate runat="server" /></td>
			<td><OrionsBelt:TournamentUpdatedDate runat="server" /></td>
			<td><OrionsBelt:TournamentLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TournamentDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TournamentItem>
	</table>
	</OrionsBelt:TournamentPagedList>
</asp:Content>