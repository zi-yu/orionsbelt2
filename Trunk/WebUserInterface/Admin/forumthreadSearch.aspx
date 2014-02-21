<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumthread";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ForumThread</h2>
	<p>Use this page to search for objects of the ForumThread type.</p>
	<div class="searchTable">
		<OrionsBelt:ForumThreadSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ForumThreadPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Title</th>
			<th>TotalViews</th>
			<th>TotalReplies</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ForumThreadPagedList>
</asp:Content>