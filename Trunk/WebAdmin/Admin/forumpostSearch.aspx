<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumpost";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ForumPost</h2>
	<p>Use this page to search for objects of the ForumPost type.</p>
	<div class="searchTable">
		<OrionsBelt:ForumPostSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ForumPostPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Text</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
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
	</OrionsBelt:ForumPostPagedList>
</asp:Content>