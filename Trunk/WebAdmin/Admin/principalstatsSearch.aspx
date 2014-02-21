<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principalstats";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PrincipalStats</h2>
	<p>Use this page to search for objects of the PrincipalStats type.</p>
	<div class="searchTable">
		<OrionsBelt:PrincipalStatsSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PrincipalStatsPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>MaxElo</th>
			<th>MinElo</th>
			<th>NumberPlayedBattles</th>
			<th>MaxLadder</th>
			<th>MinLadder</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:PrincipalStatsPagedList>
</asp:Content>