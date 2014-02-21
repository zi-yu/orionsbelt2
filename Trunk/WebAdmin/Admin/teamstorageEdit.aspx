<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "teamstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:TeamStorageEditor runat="server" Source="QueryString" ID="TeamStorageEditorId1" >
	<h2>Edit TeamStorage &lt;<OrionsBelt:TeamStorageName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:TeamStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:TeamStorageNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EloRanking</b></td>
			<td>
				<OrionsBelt:TeamStorageEloRankingEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberPlayedBattles</b></td>
			<td>
				<OrionsBelt:TeamStorageNumberPlayedBattlesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LadderActive</b></td>
			<td>
				<OrionsBelt:TeamStorageLadderActiveEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LadderPosition</b></td>
			<td>
				<OrionsBelt:TeamStorageLadderPositionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsInBattle</b></td>
			<td>
				<OrionsBelt:TeamStorageIsInBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RestUntil</b></td>
			<td>
				<OrionsBelt:TeamStorageRestUntilEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StoppedUntil</b></td>
			<td>
				<OrionsBelt:TeamStorageStoppedUntilEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MyStatsId</b></td>
			<td>
				<OrionsBelt:TeamStorageMyStatsIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsComplete</b></td>
			<td>
				<OrionsBelt:TeamStorageIsCompleteEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:TeamStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:TeamStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:TeamStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		TeamStorage :: Principals 
		[<a href='/admin/principalCreate.aspx?PrincipalTeamEditorFilter=<OrionsBelt:TeamStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TeamStoragePrincipals runat="server">
		<table class="editTable">
		<tr>
			<th>Name</th>
			<th>Email</th>
			<th>Ip</th>
			<th>Edit</th>
			<th title="Delete from TeamStorage">Delete</th>
		</tr>
		<OrionsBelt:PrincipalItem runat="server">
		<tr>
			<td><OrionsBelt:PrincipalName runat="server" /></td>
			<td><OrionsBelt:PrincipalEmail runat="server" /></td>
			<td><OrionsBelt:PrincipalIp runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrincipalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalItem>
	</table>
	</OrionsBelt:TeamStoragePrincipals>
	<h2>
		TeamStorage :: Tournaments 
		[<a href='/admin/principaltournamentCreate.aspx?PrincipalTournamentTeamEditorFilter=<OrionsBelt:TeamStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TeamStorageTournaments runat="server">
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
			<th title="Delete from TeamStorage">Delete</th>
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
	</OrionsBelt:TeamStorageTournaments>

	<h2>Delete TeamStorage</h2>
	<p><OrionsBelt:TeamStorageDelete OnDeleteRedirectTo="/admin/teamstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:TeamStorageEditor>
</asp:Content>