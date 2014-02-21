<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumreadmarking";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ForumReadMarking</h2>
	<p>Use this page to search for objects of the ForumReadMarking type.</p>
	<div class="searchTable">
		<OrionsBelt:ForumReadMarkingSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ForumReadMarkingPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>LastRead</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ForumReadMarkingPagedList>
</asp:Content>