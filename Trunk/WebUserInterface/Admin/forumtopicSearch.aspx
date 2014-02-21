<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumtopic";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ForumTopic</h2>
	<p>Use this page to search for objects of the ForumTopic type.</p>
	<div class="searchTable">
		<OrionsBelt:ForumTopicSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ForumTopicPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Title</th>
			<th>LastPost</th>
			<th>TotalPosts</th>
			<th>TotalThreads</th>
			<th>IsPrivate</th>
			<th>ForumRoles</th>
			<th>Description</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ForumTopicPagedList>
</asp:Content>