<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "message";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:MessagePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:MessageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:MessageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:MessageParametersSort InnerHtml="Parameters" runat="server" /></th>
			<th><OrionsBelt:MessageCategorySort InnerHtml="Category" runat="server" /></th>
			<th><OrionsBelt:MessageSubCategorySort InnerHtml="SubCategory" runat="server" /></th>
			<th><OrionsBelt:MessageOwnerIdSort InnerHtml="OwnerId" runat="server" /></th>
			<th><OrionsBelt:MessageDateSort InnerHtml="Date" runat="server" /></th>
			<th><OrionsBelt:MessageExtendedSort InnerHtml="Extended" runat="server" /></th>
			<th><OrionsBelt:MessageTickDeadlineSort InnerHtml="TickDeadline" runat="server" /></th>
			<th><OrionsBelt:MessageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:MessageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:MessageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:MessageItem runat="server">
		<tr>
			<td><OrionsBelt:MessageId runat="server" /></td>
			<td><OrionsBelt:MessageParameters runat="server" /></td>
			<td><OrionsBelt:MessageCategory runat="server" /></td>
			<td><OrionsBelt:MessageSubCategory runat="server" /></td>
			<td><OrionsBelt:MessageOwnerId runat="server" /></td>
			<td><OrionsBelt:MessageDate runat="server" /></td>
			<td><OrionsBelt:MessageExtended runat="server" /></td>
			<td><OrionsBelt:MessageTickDeadline runat="server" /></td>
			<td><OrionsBelt:MessageCreatedDate runat="server" /></td>
			<td><OrionsBelt:MessageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MessageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MessageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MessageItem>
	</table>
	<OrionsBelt:MessageNumberPagination runat="server" />
	</OrionsBelt:MessagePagedList>

</asp:Content>