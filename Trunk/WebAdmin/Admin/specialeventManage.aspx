<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "specialevent";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:SpecialEventPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:SpecialEventNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:SpecialEventIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:SpecialEventCostSort InnerHtml="Cost" runat="server" /></th>
			<th><OrionsBelt:SpecialEventTokenSort InnerHtml="Token" runat="server" /></th>
			<th><OrionsBelt:SpecialEventResorcesSort InnerHtml="Resorces" runat="server" /></th>
			<th><OrionsBelt:SpecialEventBeginDateSort InnerHtml="BeginDate" runat="server" /></th>
			<th><OrionsBelt:SpecialEventEndDateSort InnerHtml="EndDate" runat="server" /></th>
			<th><OrionsBelt:SpecialEventCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:SpecialEventUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:SpecialEventLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:SpecialEventItem runat="server">
		<tr>
			<td><OrionsBelt:SpecialEventId runat="server" /></td>
			<td><OrionsBelt:SpecialEventCost runat="server" /></td>
			<td><OrionsBelt:SpecialEventToken runat="server" /></td>
			<td><OrionsBelt:SpecialEventResorces runat="server" /></td>
			<td><OrionsBelt:SpecialEventBeginDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventEndDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventCreatedDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventUpdatedDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:SpecialEventDelete runat="server" /></td>
		</tr>
		</OrionsBelt:SpecialEventItem>
	</table>
	<OrionsBelt:SpecialEventNumberPagination runat="server" />
	</OrionsBelt:SpecialEventPagedList>

</asp:Content>