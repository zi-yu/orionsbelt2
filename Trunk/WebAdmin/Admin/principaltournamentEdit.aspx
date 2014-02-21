<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principaltournament";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PrincipalTournamentEditor runat="server" Source="QueryString" ID="PrincipalTournamentEditorId1" >
	<h2>Edit PrincipalTournament </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasEliminated</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentHasEliminatedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EliminatedInFase</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentEliminatedInFaseEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EliminatedInBattleId</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentEliminatedInBattleIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Tournament</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentTournamentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Team</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentTeamEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PrincipalTournamentLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		PrincipalTournament :: Points 
		[<a href='/admin/grouppointsstorageCreate.aspx?GroupPointsStorageRegistEditorFilter=<OrionsBelt:PrincipalTournamentId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalTournamentPoints runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Stage</th>
			<th>Pontuation</th>
			<th>Wins</th>
			<th>Losses</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PrincipalTournament">Delete</th>
		</tr>
		<OrionsBelt:GroupPointsStorageItem runat="server">
		<tr>
			<td><OrionsBelt:GroupPointsStorageId runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageStage runat="server" /></td>
			<td><OrionsBelt:GroupPointsStoragePontuation runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageWins runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageLosses runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:GroupPointsStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:GroupPointsStorageItem>
	</table>
	</OrionsBelt:PrincipalTournamentPoints>

	<h2>Delete PrincipalTournament</h2>
	<p><OrionsBelt:PrincipalTournamentDelete OnDeleteRedirectTo="/admin/principaltournamentManage.aspx" runat="server" /></p>
	
</OrionsBelt:PrincipalTournamentEditor>
</asp:Content>