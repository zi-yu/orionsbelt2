<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "tournament";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:TournamentEditor runat="server" Source="QueryString" ID="TournamentEditorId1" >
	<h2>Edit Tournament </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:TournamentIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:TournamentNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WarningTick</b></td>
			<td>
				<OrionsBelt:TournamentWarningTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Prize</b></td>
			<td>
				<OrionsBelt:TournamentPrizeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CostCredits</b></td>
			<td>
				<OrionsBelt:TournamentCostCreditsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TournamentType</b></td>
			<td>
				<OrionsBelt:TournamentTournamentTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>FleetId</b></td>
			<td>
				<OrionsBelt:TournamentFleetIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsPublic</b></td>
			<td>
				<OrionsBelt:TournamentIsPublicEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsSurvival</b></td>
			<td>
				<OrionsBelt:TournamentIsSurvivalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TurnTime</b></td>
			<td>
				<OrionsBelt:TournamentTurnTimeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SubscriptionTime</b></td>
			<td>
				<OrionsBelt:TournamentSubscriptionTimeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MaxPlayers</b></td>
			<td>
				<OrionsBelt:TournamentMaxPlayersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MinPlayers</b></td>
			<td>
				<OrionsBelt:TournamentMinPlayersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NPlayersToPlayoff</b></td>
			<td>
				<OrionsBelt:TournamentNPlayersToPlayoffEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MaxElo</b></td>
			<td>
				<OrionsBelt:TournamentMaxEloEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MinElo</b></td>
			<td>
				<OrionsBelt:TournamentMinEloEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StartTime</b></td>
			<td>
				<OrionsBelt:TournamentStartTimeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EndDate</b></td>
			<td>
				<OrionsBelt:TournamentEndDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Token</b></td>
			<td>
				<OrionsBelt:TournamentTokenEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TokenNumber</b></td>
			<td>
				<OrionsBelt:TournamentTokenNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsCustom</b></td>
			<td>
				<OrionsBelt:TournamentIsCustomEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PaymentsRequired</b></td>
			<td>
				<OrionsBelt:TournamentPaymentsRequiredEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberPassGroup</b></td>
			<td>
				<OrionsBelt:TournamentNumberPassGroupEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>DescriptionToken</b></td>
			<td>
				<OrionsBelt:TournamentDescriptionTokenEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:TournamentCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:TournamentUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:TournamentLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Tournament :: Groups 
		[<a href='/admin/playersgroupstorageCreate.aspx?PlayersGroupStorageTournamentEditorFilter=<OrionsBelt:TournamentId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TournamentGroups runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>EliminatoryNumber</th>
			<th>PlayersIds</th>
			<th>GroupNumber</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Tournament">Delete</th>
		</tr>
		<OrionsBelt:PlayersGroupStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlayersGroupStorageId runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageEliminatoryNumber runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStoragePlayersIds runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageGroupNumber runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayersGroupStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayersGroupStorageItem>
	</table>
	</OrionsBelt:TournamentGroups>
	<h2>
		Tournament :: Battles 
		[<a href='/admin/battleCreate.aspx?BattleTournamentEditorFilter=<OrionsBelt:TournamentId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TournamentBattles runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>CurrentTurn</th>
			<th>HasEnded</th>
			<th>BattleType</th>
			<th>BattleMode</th>
			<th>UnitsDestroyed</th>
			<th>Terrain</th>
			<th>CurrentPlayer</th>
			<th>TimeoutsAllowed</th>
			<th>TournamentMode</th>
			<th>IsDeployTime</th>
			<th>IsTeamBattle</th>
			<th>SeqNumber</th>
			<th>IsToConquer</th>
			<th>IsInPlanet</th>
			<th>CurrentBot</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Tournament">Delete</th>
		</tr>
		<OrionsBelt:BattleItem runat="server">
		<tr>
			<td><OrionsBelt:BattleId runat="server" /></td>
			<td><OrionsBelt:BattleCurrentTurn runat="server" /></td>
			<td><OrionsBelt:BattleHasEnded runat="server" /></td>
			<td><OrionsBelt:BattleBattleType runat="server" /></td>
			<td><OrionsBelt:BattleBattleMode runat="server" /></td>
			<td><OrionsBelt:BattleUnitsDestroyed runat="server" /></td>
			<td><OrionsBelt:BattleTerrain runat="server" /></td>
			<td><OrionsBelt:BattleCurrentPlayer runat="server" /></td>
			<td><OrionsBelt:BattleTimeoutsAllowed runat="server" /></td>
			<td><OrionsBelt:BattleTournamentMode runat="server" /></td>
			<td><OrionsBelt:BattleIsDeployTime runat="server" /></td>
			<td><OrionsBelt:BattleIsTeamBattle runat="server" /></td>
			<td><OrionsBelt:BattleSeqNumber runat="server" /></td>
			<td><OrionsBelt:BattleIsToConquer runat="server" /></td>
			<td><OrionsBelt:BattleIsInPlanet runat="server" /></td>
			<td><OrionsBelt:BattleCurrentBot runat="server" /></td>
			<td><OrionsBelt:BattleCreatedDate runat="server" /></td>
			<td><OrionsBelt:BattleUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BattleLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BattleDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BattleItem>
	</table>
	</OrionsBelt:TournamentBattles>
	<h2>
		Tournament :: Regists 
		[<a href='/admin/principaltournamentCreate.aspx?PrincipalTournamentTournamentEditorFilter=<OrionsBelt:TournamentId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TournamentRegists runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>HasEliminated</th>
			<th>EliminatedInFase</th>
			<th>EliminatedInBattleId</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Tournament">Delete</th>
		</tr>
		<OrionsBelt:PrincipalTournamentItem runat="server">
		<tr>
			<td><OrionsBelt:PrincipalTournamentId runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentHasEliminated runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentEliminatedInFase runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentEliminatedInBattleId runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentCreatedDate runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrincipalTournamentDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalTournamentItem>
	</table>
	</OrionsBelt:TournamentRegists>

	<h2>Delete Tournament</h2>
	<p><OrionsBelt:TournamentDelete OnDeleteRedirectTo="/admin/tournamentManage.aspx" runat="server" /></p>
	
</OrionsBelt:TournamentEditor>
</asp:Content>