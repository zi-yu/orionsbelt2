<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "tournament";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Tournament</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:TournamentEditor runat="server" Source="New" ID="TournamentEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:TournamentIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:TournamentNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>WarningTick</b></td>
			<td><OrionsBelt:TournamentWarningTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Prize</b></td>
			<td><OrionsBelt:TournamentPrizeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CostCredits</b></td>
			<td><OrionsBelt:TournamentCostCreditsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TournamentType</b></td>
			<td><OrionsBelt:TournamentTournamentTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>FleetId</b></td>
			<td><OrionsBelt:TournamentFleetIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsPublic</b></td>
			<td><OrionsBelt:TournamentIsPublicEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsSurvival</b></td>
			<td><OrionsBelt:TournamentIsSurvivalEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TurnTime</b></td>
			<td><OrionsBelt:TournamentTurnTimeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>SubscriptionTime</b></td>
			<td><OrionsBelt:TournamentSubscriptionTimeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MaxPlayers</b></td>
			<td><OrionsBelt:TournamentMaxPlayersEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MinPlayers</b></td>
			<td><OrionsBelt:TournamentMinPlayersEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NPlayersToPlayoff</b></td>
			<td><OrionsBelt:TournamentNPlayersToPlayoffEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MaxElo</b></td>
			<td><OrionsBelt:TournamentMaxEloEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MinElo</b></td>
			<td><OrionsBelt:TournamentMinEloEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>StartTime</b></td>
			<td><OrionsBelt:TournamentStartTimeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EndDate</b></td>
			<td><OrionsBelt:TournamentEndDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Token</b></td>
			<td><OrionsBelt:TournamentTokenEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TokenNumber</b></td>
			<td><OrionsBelt:TournamentTokenNumberEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsCustom</b></td>
			<td><OrionsBelt:TournamentIsCustomEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PaymentsRequired</b></td>
			<td><OrionsBelt:TournamentPaymentsRequiredEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberPassGroup</b></td>
			<td><OrionsBelt:TournamentNumberPassGroupEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>DescriptionToken</b></td>
			<td><OrionsBelt:TournamentDescriptionTokenEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:TournamentCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:TournamentUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:TournamentLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:TournamentEditor>
	</table>
	</asp:Content>