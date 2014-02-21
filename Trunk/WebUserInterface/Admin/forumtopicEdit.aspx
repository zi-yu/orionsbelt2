<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumtopic";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ForumTopicEditor runat="server" Source="QueryString" ID="ForumTopicEditorId1" >
	<h2>Edit ForumTopic </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ForumTopicIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Title</b></td>
			<td>
				<OrionsBelt:ForumTopicTitleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastPost</b></td>
			<td>
				<OrionsBelt:ForumTopicLastPostEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalPosts</b></td>
			<td>
				<OrionsBelt:ForumTopicTotalPostsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalThreads</b></td>
			<td>
				<OrionsBelt:ForumTopicTotalThreadsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsPrivate</b></td>
			<td>
				<OrionsBelt:ForumTopicIsPrivateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ForumRoles</b></td>
			<td>
				<OrionsBelt:ForumTopicForumRolesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Description</b></td>
			<td>
				<OrionsBelt:ForumTopicDescriptionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ForumTopicCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ForumTopicUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ForumTopicLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		ForumTopic :: Threads 
		[<a href='/admin/forumthreadCreate.aspx?ForumThreadTopicEditorFilter=<OrionsBelt:ForumTopicId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:ForumTopicThreads runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Title</th>
			<th>TotalViews</th>
			<th>TotalReplies</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from ForumTopic">Delete</th>
		</tr>
		<OrionsBelt:ForumThreadItem runat="server">
		<tr>
			<td><OrionsBelt:ForumThreadId runat="server" /></td>
			<td><OrionsBelt:ForumThreadTitle runat="server" /></td>
			<td><OrionsBelt:ForumThreadTotalViews runat="server" /></td>
			<td><OrionsBelt:ForumThreadTotalReplies runat="server" /></td>
			<td><OrionsBelt:ForumThreadCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumThreadUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumThreadLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumThreadDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumThreadItem>
	</table>
	</OrionsBelt:ForumTopicThreads>

	<h2>Delete ForumTopic</h2>
	<p><OrionsBelt:ForumTopicDelete OnDeleteRedirectTo="/admin/forumtopicManage.aspx" runat="server" /></p>
	
</OrionsBelt:ForumTopicEditor>
</asp:Content>