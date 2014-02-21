<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "tournament";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:TournamentPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:TournamentNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:TournamentIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:TournamentNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:TournamentWarningTickSort InnerHtml="WarningTick" runat="server" /></th>
			<th><OrionsBelt:TournamentPrizeSort InnerHtml="Prize" runat="server" /></th>
			<th><OrionsBelt:TournamentCostCreditsSort InnerHtml="CostCredits" runat="server" /></th>
			<th><OrionsBelt:TournamentTournamentTypeSort InnerHtml="TournamentType" runat="server" /></th>
			<th><OrionsBelt:TournamentFleetIdSort InnerHtml="FleetId" runat="server" /></th>
			<th><OrionsBelt:TournamentIsPublicSort InnerHtml="IsPublic" runat="server" /></th>
			<th><OrionsBelt:TournamentIsSurvivalSort InnerHtml="IsSurvival" runat="server" /></th>
			<th><OrionsBelt:TournamentTurnTimeSort InnerHtml="TurnTime" runat="server" /></th>
			<th><OrionsBelt:TournamentSubscriptionTimeSort InnerHtml="SubscriptionTime" runat="server" /></th>
			<th><OrionsBelt:TournamentMaxPlayersSort InnerHtml="MaxPlayers" runat="server" /></th>
			<th><OrionsBelt:TournamentMinPlayersSort InnerHtml="MinPlayers" runat="server" /></th>
			<th><OrionsBelt:TournamentNPlayersToPlayoffSort InnerHtml="NPlayersToPlayoff" runat="server" /></th>
			<th><OrionsBelt:TournamentMaxEloSort InnerHtml="MaxElo" runat="server" /></th>
			<th><OrionsBelt:TournamentMinEloSort InnerHtml="MinElo" runat="server" /></th>
			<th><OrionsBelt:TournamentStartTimeSort InnerHtml="StartTime" runat="server" /></th>
			<th><OrionsBelt:TournamentEndDateSort InnerHtml="EndDate" runat="server" /></th>
			<th><OrionsBelt:TournamentTokenSort InnerHtml="Token" runat="server" /></th>
			<th><OrionsBelt:TournamentTokenNumberSort InnerHtml="TokenNumber" runat="server" /></th>
			<th><OrionsBelt:TournamentIsCustomSort InnerHtml="IsCustom" runat="server" /></th>
			<th><OrionsBelt:TournamentPaymentsRequiredSort InnerHtml="PaymentsRequired" runat="server" /></th>
			<th><OrionsBelt:TournamentNumberPassGroupSort InnerHtml="NumberPassGroup" runat="server" /></th>
			<th><OrionsBelt:TournamentDescriptionTokenSort InnerHtml="DescriptionToken" runat="server" /></th>
			<th><OrionsBelt:TournamentCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:TournamentUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:TournamentLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:TournamentNumberPagination runat="server" />
	</OrionsBelt:TournamentPagedList>

</asp:Content>