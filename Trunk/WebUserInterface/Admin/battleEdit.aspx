<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battle";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:BattleEditor runat="server" Source="QueryString" ID="BattleEditorId1" >
	<h2>Edit Battle </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:BattleIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CurrentTurn</b></td>
			<td>
				<OrionsBelt:BattleCurrentTurnEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasEnded</b></td>
			<td>
				<OrionsBelt:BattleHasEndedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleType</b></td>
			<td>
				<OrionsBelt:BattleBattleTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleMode</b></td>
			<td>
				<OrionsBelt:BattleBattleModeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UnitsDestroyed</b></td>
			<td>
				<OrionsBelt:BattleUnitsDestroyedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Terrain</b></td>
			<td>
				<OrionsBelt:BattleTerrainEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CurrentPlayer</b></td>
			<td>
				<OrionsBelt:BattleCurrentPlayerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TimeoutsAllowed</b></td>
			<td>
				<OrionsBelt:BattleTimeoutsAllowedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TournamentMode</b></td>
			<td>
				<OrionsBelt:BattleTournamentModeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsDeployTime</b></td>
			<td>
				<OrionsBelt:BattleIsDeployTimeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsTeamBattle</b></td>
			<td>
				<OrionsBelt:BattleIsTeamBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SeqNumber</b></td>
			<td>
				<OrionsBelt:BattleSeqNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsToConquer</b></td>
			<td>
				<OrionsBelt:BattleIsToConquerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsInPlanet</b></td>
			<td>
				<OrionsBelt:BattleIsInPlanetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CurrentBot</b></td>
			<td>
				<OrionsBelt:BattleCurrentBotEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Tournament</b></td>
			<td>
				<OrionsBelt:BattleTournamentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Group</b></td>
			<td>
				<OrionsBelt:BattleGroupEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:BattleCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:BattleUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:BattleLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Battle :: PlayerInformation 
		[<a href='/admin/playerbattleinformationCreate.aspx?PlayerBattleInformationBattleEditorFilter=<OrionsBelt:BattleId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:BattlePlayerInformation runat="server">
		<table class="editTable">
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
			<th title="Delete from Battle">Delete</th>
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
	</OrionsBelt:BattlePlayerInformation>
	<h2>
		Battle :: BattleExtension 
		[<a href='/admin/battleextentionCreate.aspx?BattleExtentionBattleEditorFilter=<OrionsBelt:BattleId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:BattleBattleExtension runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>BattleFinalStates</th>
			<th>BattleMovements</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Battle">Delete</th>
		</tr>
		<OrionsBelt:BattleExtentionItem runat="server">
		<tr>
			<td><OrionsBelt:BattleExtentionId runat="server" /></td>
			<td><OrionsBelt:BattleExtentionBattleFinalStates runat="server" /></td>
			<td><OrionsBelt:BattleExtentionBattleMovements runat="server" /></td>
			<td><OrionsBelt:BattleExtentionCreatedDate runat="server" /></td>
			<td><OrionsBelt:BattleExtentionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BattleExtentionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BattleExtentionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BattleExtentionItem>
	</table>
	</OrionsBelt:BattleBattleExtension>
	<h2>
		Battle :: TimedAction 
		[<a href='/admin/timedactionstorageCreate.aspx?TimedActionStorageBattleEditorFilter=<OrionsBelt:BattleId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:BattleTimedAction runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>StartTick</th>
			<th>EndTick</th>
			<th>Data</th>
			<th>Name</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Battle">Delete</th>
		</tr>
		<OrionsBelt:TimedActionStorageItem runat="server">
		<tr>
			<td><OrionsBelt:TimedActionStorageId runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageStartTick runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageEndTick runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageData runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageName runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TimedActionStorageItem>
	</table>
	</OrionsBelt:BattleTimedAction>
	<h2>
		Battle :: Campaigns 
		[<a href='/admin/campaignstatusCreate.aspx?CampaignStatusBattleEditorFilter=<OrionsBelt:BattleId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:BattleCampaigns runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Level</th>
			<th>Moves</th>
			<th>Completed</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Battle">Delete</th>
		</tr>
		<OrionsBelt:CampaignStatusItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignStatusId runat="server" /></td>
			<td><OrionsBelt:CampaignStatusLevel runat="server" /></td>
			<td><OrionsBelt:CampaignStatusMoves runat="server" /></td>
			<td><OrionsBelt:CampaignStatusCompleted runat="server" /></td>
			<td><OrionsBelt:CampaignStatusCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignStatusUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignStatusLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignStatusDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignStatusItem>
	</table>
	</OrionsBelt:BattleCampaigns>

	<h2>Delete Battle</h2>
	<p><OrionsBelt:BattleDelete OnDeleteRedirectTo="/admin/battleManage.aspx" runat="server" /></p>
	
</OrionsBelt:BattleEditor>
</asp:Content>