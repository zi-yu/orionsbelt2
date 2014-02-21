<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principaltournament";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create PrincipalTournament</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PrincipalTournamentEditor runat="server" Source="New" ID="PrincipalTournamentEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PrincipalTournamentIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>HasEliminated</b></td>
			<td><OrionsBelt:PrincipalTournamentHasEliminatedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EliminatedInFase</b></td>
			<td><OrionsBelt:PrincipalTournamentEliminatedInFaseEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EliminatedInBattleId</b></td>
			<td><OrionsBelt:PrincipalTournamentEliminatedInBattleIdEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Principal</b></td>
			<td><OrionsBelt:PrincipalTournamentPrincipalEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Tournament</b></td>
			<td><OrionsBelt:PrincipalTournamentTournamentEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Team</b></td>
			<td><OrionsBelt:PrincipalTournamentTeamEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PrincipalTournamentCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PrincipalTournamentUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PrincipalTournamentLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalTournamentEditor>
	</table>
	</asp:Content>