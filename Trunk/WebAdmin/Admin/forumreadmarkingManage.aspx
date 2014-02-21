<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumreadmarking";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ForumReadMarkingPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ForumReadMarkingNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ForumReadMarkingIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ForumReadMarkingLastReadSort InnerHtml="LastRead" runat="server" /></th>
			<th><OrionsBelt:ForumReadMarkingCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumReadMarkingUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumReadMarkingLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ForumReadMarkingItem runat="server">
		<tr>
			<td><OrionsBelt:ForumReadMarkingId runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingLastRead runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumReadMarkingDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumReadMarkingItem>
	</table>
	<OrionsBelt:ForumReadMarkingNumberPagination runat="server" />
	</OrionsBelt:ForumReadMarkingPagedList>

</asp:Content>