<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumtopic";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ForumTopicPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ForumTopicNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ForumTopicIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ForumTopicTitleSort InnerHtml="Title" runat="server" /></th>
			<th><OrionsBelt:ForumTopicLastPostSort InnerHtml="LastPost" runat="server" /></th>
			<th><OrionsBelt:ForumTopicTotalPostsSort InnerHtml="TotalPosts" runat="server" /></th>
			<th><OrionsBelt:ForumTopicTotalThreadsSort InnerHtml="TotalThreads" runat="server" /></th>
			<th><OrionsBelt:ForumTopicIsPrivateSort InnerHtml="IsPrivate" runat="server" /></th>
			<th><OrionsBelt:ForumTopicForumRolesSort InnerHtml="ForumRoles" runat="server" /></th>
			<th><OrionsBelt:ForumTopicDescriptionSort InnerHtml="Description" runat="server" /></th>
			<th><OrionsBelt:ForumTopicCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumTopicUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumTopicLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ForumTopicItem runat="server">
		<tr>
			<td><OrionsBelt:ForumTopicId runat="server" /></td>
			<td><OrionsBelt:ForumTopicTitle runat="server" /></td>
			<td><OrionsBelt:ForumTopicLastPost runat="server" /></td>
			<td><OrionsBelt:ForumTopicTotalPosts runat="server" /></td>
			<td><OrionsBelt:ForumTopicTotalThreads runat="server" /></td>
			<td><OrionsBelt:ForumTopicIsPrivate runat="server" /></td>
			<td><OrionsBelt:ForumTopicForumRoles runat="server" /></td>
			<td><OrionsBelt:ForumTopicDescription runat="server" /></td>
			<td><OrionsBelt:ForumTopicCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumTopicUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumTopicLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumTopicDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumTopicItem>
	</table>
	<OrionsBelt:ForumTopicNumberPagination runat="server" />
	</OrionsBelt:ForumTopicPagedList>

</asp:Content>