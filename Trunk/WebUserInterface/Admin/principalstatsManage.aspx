<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principalstats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PrincipalStatsPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PrincipalStatsNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PrincipalStatsIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsMaxEloSort InnerHtml="MaxElo" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsMinEloSort InnerHtml="MinElo" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsNumberPlayedBattlesSort InnerHtml="NumberPlayedBattles" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsMaxLadderSort InnerHtml="MaxLadder" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsMinLadderSort InnerHtml="MinLadder" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PrincipalStatsLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PrincipalStatsItem runat="server">
		<tr>
			<td><OrionsBelt:PrincipalStatsId runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsMaxElo runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsMinElo runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsNumberPlayedBattles runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsMaxLadder runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsMinLadder runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsCreatedDate runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrincipalStatsDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalStatsItem>
	</table>
	<OrionsBelt:PrincipalStatsNumberPagination runat="server" />
	</OrionsBelt:PrincipalStatsPagedList>

</asp:Content>