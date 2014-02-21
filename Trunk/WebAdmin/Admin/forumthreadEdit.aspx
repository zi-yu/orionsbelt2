<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumthread";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ForumThreadEditor runat="server" Source="QueryString" ID="ForumThreadEditorId1" >
	<h2>Edit ForumThread </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ForumThreadIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Title</b></td>
			<td>
				<OrionsBelt:ForumThreadTitleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalViews</b></td>
			<td>
				<OrionsBelt:ForumThreadTotalViewsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TotalReplies</b></td>
			<td>
				<OrionsBelt:ForumThreadTotalRepliesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Topic</b></td>
			<td>
				<OrionsBelt:ForumThreadTopicEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:ForumThreadOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ForumThreadCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ForumThreadUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ForumThreadLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		ForumThread :: Posts 
		[<a href='/admin/forumpostCreate.aspx?ForumPostThreadEditorFilter=<OrionsBelt:ForumThreadId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:ForumThreadPosts runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Text</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from ForumThread">Delete</th>
		</tr>
		<OrionsBelt:ForumPostItem runat="server">
		<tr>
			<td><OrionsBelt:ForumPostId runat="server" /></td>
			<td><OrionsBelt:ForumPostText runat="server" /></td>
			<td><OrionsBelt:ForumPostCreatedDate runat="server" /></td>
			<td><OrionsBelt:ForumPostUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ForumPostLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ForumPostDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ForumPostItem>
	</table>
	</OrionsBelt:ForumThreadPosts>
	<h2>
		ForumThread :: ReadMarkings 
		[<a href='/admin/forumreadmarkingCreate.aspx?ForumReadMarkingThreadEditorFilter=<OrionsBelt:ForumThreadId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:ForumThreadReadMarkings runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>LastRead</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from ForumThread">Delete</th>
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
	</OrionsBelt:ForumThreadReadMarkings>

	<h2>Delete ForumThread</h2>
	<p><OrionsBelt:ForumThreadDelete OnDeleteRedirectTo="/admin/forumthreadManage.aspx" runat="server" /></p>
	
</OrionsBelt:ForumThreadEditor>
</asp:Content>