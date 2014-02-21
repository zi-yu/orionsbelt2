<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "arenahistorical";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ArenaHistoricalEditor runat="server" Source="QueryString" ID="ArenaHistoricalEditorId1" >
	<h2>Edit ArenaHistorical </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ChampionId</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalChampionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ChallengerId</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalChallengerIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Winner</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalWinnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WinningSequence</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalWinningSequenceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleId</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalBattleIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StartTick</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalStartTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EndTick</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalEndTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Arena</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalArenaEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ArenaHistoricalLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete ArenaHistorical</h2>
	<p><OrionsBelt:ArenaHistoricalDelete OnDeleteRedirectTo="/admin/arenahistoricalManage.aspx" runat="server" /></p>
	
</OrionsBelt:ArenaHistoricalEditor>
</asp:Content>