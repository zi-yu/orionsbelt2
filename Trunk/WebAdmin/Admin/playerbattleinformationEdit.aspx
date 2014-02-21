<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerbattleinformation";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PlayerBattleInformationEditor runat="server" Source="QueryString" ID="PlayerBattleInformationEditorId1" >
	<h2>Edit PlayerBattleInformation </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>InitialContainer</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationInitialContainerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasPositioned</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationHasPositionedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TeamNumber</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationTeamNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasLost</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationHasLostEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WinScore</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationWinScoreEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>FleetId</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationFleetIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdateFleet</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationUpdateFleetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasGaveUp</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationHasGaveUpEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LoseScore</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationLoseScoreEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>VictoryPercentage</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationVictoryPercentageEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>DominationPoints</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationDominationPointsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Timeouts</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationTimeoutsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TeamName</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationTeamNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UltimateUnit</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationUltimateUnitEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotId</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationBotIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Battle</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PlayerBattleInformationLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete PlayerBattleInformation</h2>
	<p><OrionsBelt:PlayerBattleInformationDelete OnDeleteRedirectTo="/admin/playerbattleinformationManage.aspx" runat="server" /></p>
	
</OrionsBelt:PlayerBattleInformationEditor>
</asp:Content>