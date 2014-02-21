<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "globalstats";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search GlobalStats</h2>
	<p>Use this page to search for objects of the GlobalStats type.</p>
	<div class="searchTable">
		<OrionsBelt:GlobalStatsSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:GlobalStatsPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Type</th>
			<th>Tick</th>
			<th>Text</th>
			<th>Number</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:GlobalStatsItem runat="server">
		<tr>
			<td><OrionsBelt:GlobalStatsId runat="server" /></td>
			<td><OrionsBelt:GlobalStatsType runat="server" /></td>
			<td><OrionsBelt:GlobalStatsTick runat="server" /></td>
			<td><OrionsBelt:GlobalStatsText runat="server" /></td>
			<td><OrionsBelt:GlobalStatsNumber runat="server" /></td>
			<td><OrionsBelt:GlobalStatsCreatedDate runat="server" /></td>
			<td><OrionsBelt:GlobalStatsUpdatedDate runat="server" /></td>
			<td><OrionsBelt:GlobalStatsLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:GlobalStatsDelete runat="server" /></td>
		</tr>
		</OrionsBelt:GlobalStatsItem>
	</table>
	</OrionsBelt:GlobalStatsPagedList>
</asp:Content>