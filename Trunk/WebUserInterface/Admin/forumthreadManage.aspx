<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumthread";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ForumThreadPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ForumThreadNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ForumThreadIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ForumThreadTitleSort InnerHtml="Title" runat="server" /></th>
			<th><OrionsBelt:ForumThreadTotalViewsSort InnerHtml="TotalViews" runat="server" /></th>
			<th><OrionsBelt:ForumThreadTotalRepliesSort InnerHtml="TotalReplies" runat="server" /></th>
			<th><OrionsBelt:ForumThreadCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumThreadUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ForumThreadLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
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
	<OrionsBelt:ForumThreadNumberPagination runat="server" />
	</OrionsBelt:ForumThreadPagedList>

</asp:Content>