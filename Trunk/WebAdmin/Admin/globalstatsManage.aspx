<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "globalstats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:GlobalStatsPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:GlobalStatsNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:GlobalStatsIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsTickSort InnerHtml="Tick" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsTextSort InnerHtml="Text" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsNumberSort InnerHtml="Number" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:GlobalStatsLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:GlobalStatsNumberPagination runat="server" />
	</OrionsBelt:GlobalStatsPagedList>

</asp:Content>