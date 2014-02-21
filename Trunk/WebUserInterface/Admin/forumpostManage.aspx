<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumpost";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ForumPostPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ForumPostNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ForumPostIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ForumPostTextSort InnerHtml="Text" runat="server" /></th>
			<th><OrionsBelt:ForumPostCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumPostUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumPostLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:ForumPostNumberPagination runat="server" />
	</OrionsBelt:ForumPostPagedList>

</asp:Content>