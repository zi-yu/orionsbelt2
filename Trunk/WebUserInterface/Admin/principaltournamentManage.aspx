<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principaltournament";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PrincipalTournamentPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PrincipalTournamentNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PrincipalTournamentIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PrincipalTournamentHasEliminatedSort InnerHtml="HasEliminated" runat="server" /></th>
			<th><OrionsBelt:PrincipalTournamentEliminatedInFaseSort InnerHtml="EliminatedInFase" runat="server" /></th>
			<th><OrionsBelt:PrincipalTournamentEliminatedInBattleIdSort InnerHtml="EliminatedInBattleId" runat="server" /></th>
			<th><OrionsBelt:PrincipalTournamentCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PrincipalTournamentUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PrincipalTournamentLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
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
	<OrionsBelt:PrincipalTournamentNumberPagination runat="server" />
	</OrionsBelt:PrincipalTournamentPagedList>

</asp:Content>