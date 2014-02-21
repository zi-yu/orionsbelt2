<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Principal</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PrincipalEditor runat="server" Source="New" ID="PrincipalEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PrincipalIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsBot</b></td>
			<td><OrionsBelt:PrincipalIsBotEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MyStatsId</b></td>
			<td><OrionsBelt:PrincipalMyStatsIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EloRanking</b></td>
			<td><OrionsBelt:PrincipalEloRankingEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ReceiveMail</b></td>
			<td><OrionsBelt:PrincipalReceiveMailEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Credits</b></td>
			<td><OrionsBelt:PrincipalCreditsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LadderActive</b></td>
			<td><OrionsBelt:PrincipalLadderActiveEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LadderPosition</b></td>
			<td><OrionsBelt:PrincipalLadderPositionEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsInBattle</b></td>
			<td><OrionsBelt:PrincipalIsInBattleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RestUntil</b></td>
			<td><OrionsBelt:PrincipalRestUntilEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>StoppedUntil</b></td>
			<td><OrionsBelt:PrincipalStoppedUntilEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>AvailableVacationTicks</b></td>
			<td><OrionsBelt:PrincipalAvailableVacationTicksEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>VacationStartTick</b></td>
			<td><OrionsBelt:PrincipalVacationStartTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>VacationEndtick</b></td>
			<td><OrionsBelt:PrincipalVacationEndtickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>AutoStartVacations</b></td>
			<td><OrionsBelt:PrincipalAutoStartVacationsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ReferrerId</b></td>
			<td><OrionsBelt:PrincipalReferrerIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CanChangeName</b></td>
			<td><OrionsBelt:PrincipalCanChangeNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Avatar</b></td>
			<td><OrionsBelt:PrincipalAvatarEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>WebSite</b></td>
			<td><OrionsBelt:PrincipalWebSiteEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>TutorialState</b></td>
			<td><OrionsBelt:PrincipalTutorialStateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>DuplicatedIds</b></td>
			<td><OrionsBelt:PrincipalDuplicatedIdsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberOfWarnings</b></td>
			<td><OrionsBelt:PrincipalNumberOfWarningsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>AcceptedTerms</b></td>
			<td><OrionsBelt:PrincipalAcceptedTermsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>WarningPoints</b></td>
			<td><OrionsBelt:PrincipalWarningPointsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastWarningDate</b></td>
			<td><OrionsBelt:PrincipalLastWarningDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BotUrl</b></td>
			<td><OrionsBelt:PrincipalBotUrlEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ReferrerPriceCount</b></td>
			<td><OrionsBelt:PrincipalReferrerPriceCountEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsOnVacations</b></td>
			<td><OrionsBelt:PrincipalIsOnVacationsEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Team</b></td>
			<td><OrionsBelt:PrincipalTeamEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:PrincipalNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Password</b></td>
			<td><OrionsBelt:PrincipalPasswordEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Email</b></td>
			<td><OrionsBelt:PrincipalEmailEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Ip</b></td>
			<td><OrionsBelt:PrincipalIpEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RegistDate</b></td>
			<td><OrionsBelt:PrincipalRegistDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastLogin</b></td>
			<td><OrionsBelt:PrincipalLastLoginEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Approved</b></td>
			<td><OrionsBelt:PrincipalApprovedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsOnline</b></td>
			<td><OrionsBelt:PrincipalIsOnlineEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Locked</b></td>
			<td><OrionsBelt:PrincipalLockedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Locale</b></td>
			<td><OrionsBelt:PrincipalLocaleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ConfirmationCode</b></td>
			<td><OrionsBelt:PrincipalConfirmationCodeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RawRoles</b></td>
			<td><OrionsBelt:PrincipalRawRolesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PrincipalCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PrincipalUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PrincipalLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalEditor>
	</table>
	</asp:Content>