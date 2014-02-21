<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenastorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ArenaStorageEditor runat="server" Source="QueryString" ID="ArenaStorageEditorId1" >
	<h2>Edit ArenaStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ArenaStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:ArenaStorageNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsInBattle</b></td>
			<td>
				<OrionsBelt:ArenaStorageIsInBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ConquestTick</b></td>
			<td>
				<OrionsBelt:ArenaStorageConquestTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleType</b></td>
			<td>
				<OrionsBelt:ArenaStorageBattleTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Coordinate</b></td>
			<td>
				<OrionsBelt:ArenaStorageCoordinateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Payment</b></td>
			<td>
				<OrionsBelt:ArenaStoragePaymentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:ArenaStorageLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Fleet</b></td>
			<td>
				<OrionsBelt:ArenaStorageFleetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:ArenaStorageOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sector</b></td>
			<td>
				<OrionsBelt:ArenaStorageSectorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ArenaStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ArenaStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ArenaStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		ArenaStorage :: Historical 
		[<a href='/admin/arenahistoricalCreate.aspx?ArenaHistoricalArenaEditorFilter=<OrionsBelt:ArenaStorageId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:ArenaStorageHistorical runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>ChampionId</th>
			<th>ChallengerId</th>
			<th>Winner</th>
			<th>WinningSequence</th>
			<th>BattleId</th>
			<th>StartTick</th>
			<th>EndTick</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from ArenaStorage">Delete</th>
		</tr>
		<OrionsBelt:ArenaHistoricalItem runat="server">
		<tr>
			<td><OrionsBelt:ArenaHistoricalId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalChampionId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalChallengerId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalWinner runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalWinningSequence runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalBattleId runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalStartTick runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalEndTick runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalCreatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ArenaHistoricalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ArenaHistoricalItem>
	</table>
	</OrionsBelt:ArenaStorageHistorical>

	<h2>Delete ArenaStorage</h2>
	<p><OrionsBelt:ArenaStorageDelete OnDeleteRedirectTo="/admin/arenastorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:ArenaStorageEditor>
</asp:Content>