<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playersgroupstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PlayersGroupStorageEditor runat="server" Source="QueryString" ID="PlayersGroupStorageEditorId1" >
	<h2>Edit PlayersGroupStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EliminatoryNumber</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageEliminatoryNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PlayersIds</b></td>
			<td>
				<OrionsBelt:PlayersGroupStoragePlayersIdsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GroupNumber</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageGroupNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Tournament</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageTournamentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PlayersGroupStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		PlayersGroupStorage :: Battles 
		[<a href='/admin/battleCreate.aspx?BattleGroupEditorFilter=<OrionsBelt:PlayersGroupStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayersGroupStorageBattles runat="server">
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
			<th title="Delete from PlayersGroupStorage">Delete</th>
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
	</OrionsBelt:PlayersGroupStorageBattles>

	<h2>Delete PlayersGroupStorage</h2>
	<p><OrionsBelt:PlayersGroupStorageDelete OnDeleteRedirectTo="/admin/playersgroupstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:PlayersGroupStorageEditor>
</asp:Content>