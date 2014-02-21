<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PrincipalEditor runat="server" Source="QueryString" ID="PrincipalEditorId1" >
	<h2>Edit Principal &lt;<OrionsBelt:PrincipalName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PrincipalIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsBot</b></td>
			<td>
				<OrionsBelt:PrincipalIsBotEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MyStatsId</b></td>
			<td>
				<OrionsBelt:PrincipalMyStatsIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EloRanking</b></td>
			<td>
				<OrionsBelt:PrincipalEloRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ReceiveMail</b></td>
			<td>
				<OrionsBelt:PrincipalReceiveMailEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Credits</b></td>
			<td>
				<OrionsBelt:PrincipalCreditsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LadderActive</b></td>
			<td>
				<OrionsBelt:PrincipalLadderActiveEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LadderPosition</b></td>
			<td>
				<OrionsBelt:PrincipalLadderPositionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsInBattle</b></td>
			<td>
				<OrionsBelt:PrincipalIsInBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RestUntil</b></td>
			<td>
				<OrionsBelt:PrincipalRestUntilEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StoppedUntil</b></td>
			<td>
				<OrionsBelt:PrincipalStoppedUntilEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AvailableVacationTicks</b></td>
			<td>
				<OrionsBelt:PrincipalAvailableVacationTicksEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>VacationStartTick</b></td>
			<td>
				<OrionsBelt:PrincipalVacationStartTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>VacationEndtick</b></td>
			<td>
				<OrionsBelt:PrincipalVacationEndtickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AutoStartVacations</b></td>
			<td>
				<OrionsBelt:PrincipalAutoStartVacationsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ReferrerId</b></td>
			<td>
				<OrionsBelt:PrincipalReferrerIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CanChangeName</b></td>
			<td>
				<OrionsBelt:PrincipalCanChangeNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Avatar</b></td>
			<td>
				<OrionsBelt:PrincipalAvatarEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WebSite</b></td>
			<td>
				<OrionsBelt:PrincipalWebSiteEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TutorialState</b></td>
			<td>
				<OrionsBelt:PrincipalTutorialStateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>DuplicatedIds</b></td>
			<td>
				<OrionsBelt:PrincipalDuplicatedIdsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberOfWarnings</b></td>
			<td>
				<OrionsBelt:PrincipalNumberOfWarningsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AcceptedTerms</b></td>
			<td>
				<OrionsBelt:PrincipalAcceptedTermsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WarningPoints</b></td>
			<td>
				<OrionsBelt:PrincipalWarningPointsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastWarningDate</b></td>
			<td>
				<OrionsBelt:PrincipalLastWarningDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotUrl</b></td>
			<td>
				<OrionsBelt:PrincipalBotUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ReferrerPriceCount</b></td>
			<td>
				<OrionsBelt:PrincipalReferrerPriceCountEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsOnVacations</b></td>
			<td>
				<OrionsBelt:PrincipalIsOnVacationsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Team</b></td>
			<td>
				<OrionsBelt:PrincipalTeamEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:PrincipalNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Password</b></td>
			<td>
				<OrionsBelt:PrincipalPasswordEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Email</b></td>
			<td>
				<OrionsBelt:PrincipalEmailEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Ip</b></td>
			<td>
				<OrionsBelt:PrincipalIpEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RegistDate</b></td>
			<td>
				<OrionsBelt:PrincipalRegistDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastLogin</b></td>
			<td>
				<OrionsBelt:PrincipalLastLoginEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Approved</b></td>
			<td>
				<OrionsBelt:PrincipalApprovedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsOnline</b></td>
			<td>
				<OrionsBelt:PrincipalIsOnlineEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locked</b></td>
			<td>
				<OrionsBelt:PrincipalLockedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locale</b></td>
			<td>
				<OrionsBelt:PrincipalLocaleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ConfirmationCode</b></td>
			<td>
				<OrionsBelt:PrincipalConfirmationCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RawRoles</b></td>
			<td>
				<OrionsBelt:PrincipalRawRolesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PrincipalCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PrincipalUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PrincipalLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Principal :: Tournaments 
		[<a href='/admin/principaltournamentCreate.aspx?PrincipalTournamentPrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalTournaments runat="server">
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
			<th title="Delete from Principal">Delete</th>
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
	</OrionsBelt:PrincipalTournaments>
	<h2>
		Principal :: Fleets 
		[<a href='/admin/fleetCreate.aspx?FleetPrincipalOwnerEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalFleets runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Units</th>
			<th>IsMovable</th>
			<th>IsInBattle</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:FleetItem runat="server">
		<tr>
			<td><OrionsBelt:FleetId runat="server" /></td>
			<td><OrionsBelt:FleetName runat="server" /></td>
			<td><OrionsBelt:FleetUnits runat="server" /></td>
			<td><OrionsBelt:FleetIsMovable runat="server" /></td>
			<td><OrionsBelt:FleetIsInBattle runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FleetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FleetItem>
	</table>
	</OrionsBelt:PrincipalFleets>
	<h2>
		Principal :: Player 
		[<a href='/admin/playerstorageCreate.aspx?PlayerStoragePrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalPlayer runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Score</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:PlayerStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlayerStorageId runat="server" /></td>
			<td><OrionsBelt:PlayerStorageName runat="server" /></td>
			<td><OrionsBelt:PlayerStorageScore runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayerStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStorageItem>
	</table>
	</OrionsBelt:PrincipalPlayer>
	<h2>
		Principal :: Medals 
		[<a href='/admin/medalCreate.aspx?MedalPrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalMedals runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>IsAuto</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:MedalItem runat="server">
		<tr>
			<td><OrionsBelt:MedalId runat="server" /></td>
			<td><OrionsBelt:MedalName runat="server" /></td>
			<td><OrionsBelt:MedalIsAuto runat="server" /></td>
			<td><OrionsBelt:MedalCreatedDate runat="server" /></td>
			<td><OrionsBelt:MedalUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MedalLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MedalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MedalItem>
	</table>
	</OrionsBelt:PrincipalMedals>
	<h2>
		Principal :: CreatedCampaigns 
		[<a href='/admin/campaignCreate.aspx?CampaignPrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalCreatedCampaigns runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:CampaignItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignId runat="server" /></td>
			<td><OrionsBelt:CampaignName runat="server" /></td>
			<td><OrionsBelt:CampaignCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignItem>
	</table>
	</OrionsBelt:PrincipalCreatedCampaigns>
	<h2>
		Principal :: Campaigns 
		[<a href='/admin/campaignstatusCreate.aspx?CampaignStatusPrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalCampaigns runat="server">
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
			<th title="Delete from Principal">Delete</th>
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
	</OrionsBelt:PrincipalCampaigns>
	<h2>
		Principal :: UsedCards 
		[<a href='/admin/bonuscardCreate.aspx?BonusCardUsedByEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalUsedCards runat="server">
		<table class="editTable">
		<tr>
			<th>Type</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:BonusCardItem runat="server">
		<tr>
			<td><OrionsBelt:BonusCardType runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BonusCardDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BonusCardItem>
	</table>
	</OrionsBelt:PrincipalUsedCards>
	<h2>
		Principal :: Promotions 
		[<a href='/admin/promotionCreate.aspx?PromotionOwnerEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalPromotions runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>BeginDate</th>
			<th>EndDate</th>
			<th>RevenueType</th>
			<th>Revenue</th>
			<th>PromotionType</th>
			<th>RangeBegin</th>
			<th>RangeEnd</th>
			<th>PromotionCode</th>
			<th>BonusType</th>
			<th>Bonus</th>
			<th>Status</th>
			<th>Description</th>
			<th>Uses</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:PromotionItem runat="server">
		<tr>
			<td><OrionsBelt:PromotionId runat="server" /></td>
			<td><OrionsBelt:PromotionName runat="server" /></td>
			<td><OrionsBelt:PromotionBeginDate runat="server" /></td>
			<td><OrionsBelt:PromotionEndDate runat="server" /></td>
			<td><OrionsBelt:PromotionRevenueType runat="server" /></td>
			<td><OrionsBelt:PromotionRevenue runat="server" /></td>
			<td><OrionsBelt:PromotionPromotionType runat="server" /></td>
			<td><OrionsBelt:PromotionRangeBegin runat="server" /></td>
			<td><OrionsBelt:PromotionRangeEnd runat="server" /></td>
			<td><OrionsBelt:PromotionPromotionCode runat="server" /></td>
			<td><OrionsBelt:PromotionBonusType runat="server" /></td>
			<td><OrionsBelt:PromotionBonus runat="server" /></td>
			<td><OrionsBelt:PromotionStatus runat="server" /></td>
			<td><OrionsBelt:PromotionDescription runat="server" /></td>
			<td><OrionsBelt:PromotionUses runat="server" /></td>
			<td><OrionsBelt:PromotionCreatedDate runat="server" /></td>
			<td><OrionsBelt:PromotionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PromotionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PromotionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PromotionItem>
	</table>
	</OrionsBelt:PrincipalPromotions>
	<h2>
		Principal :: ActivePromotions 
		[<a href='/admin/activatedpromotionCreate.aspx?ActivatedPromotionPrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalActivePromotions runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Used</th>
			<th>Code</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:ActivatedPromotionItem runat="server">
		<tr>
			<td><OrionsBelt:ActivatedPromotionId runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionUsed runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionCode runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionCreatedDate runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ActivatedPromotionItem>
	</table>
	</OrionsBelt:PrincipalActivePromotions>
	<h2>
		Principal :: Exceptions 
		[<a href='/admin/exceptioninfoCreate.aspx?ExceptionInfoPrincipalEditorFilter=<OrionsBelt:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalExceptions runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Message</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<OrionsBelt:ExceptionInfoItem runat="server">
		<tr>
			<td><OrionsBelt:ExceptionInfoId runat="server" /></td>
			<td><OrionsBelt:ExceptionInfoMessage runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ExceptionInfoDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ExceptionInfoItem>
	</table>
	</OrionsBelt:PrincipalExceptions>

	<h2>Delete Principal</h2>
	<p><OrionsBelt:PrincipalDelete OnDeleteRedirectTo="/admin/principalManage.aspx" runat="server" /></p>
	
</OrionsBelt:PrincipalEditor>
</asp:Content>