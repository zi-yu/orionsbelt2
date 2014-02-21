<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerbattleinformation";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PlayerBattleInformationPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PlayerBattleInformationNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PlayerBattleInformationIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationInitialContainerSort InnerHtml="InitialContainer" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationHasPositionedSort InnerHtml="HasPositioned" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationTeamNumberSort InnerHtml="TeamNumber" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationHasLostSort InnerHtml="HasLost" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationWinScoreSort InnerHtml="WinScore" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationFleetIdSort InnerHtml="FleetId" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationUpdateFleetSort InnerHtml="UpdateFleet" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationHasGaveUpSort InnerHtml="HasGaveUp" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationLoseScoreSort InnerHtml="LoseScore" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationVictoryPercentageSort InnerHtml="VictoryPercentage" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationDominationPointsSort InnerHtml="DominationPoints" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationTimeoutsSort InnerHtml="Timeouts" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationOwnerSort InnerHtml="Owner" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationTeamNameSort InnerHtml="TeamName" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationUltimateUnitSort InnerHtml="UltimateUnit" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationBotIdSort InnerHtml="BotId" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PlayerBattleInformationLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:PlayerBattleInformationNumberPagination runat="server" />
	</OrionsBelt:PlayerBattleInformationPagedList>

</asp:Content>