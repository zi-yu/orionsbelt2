<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "message";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Message</h2>
	<p>Use this page to search for objects of the Message type.</p>
	<div class="searchTable">
		<OrionsBelt:MessageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:MessagePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Parameters</th>
			<th>Category</th>
			<th>SubCategory</th>
			<th>OwnerId</th>
			<th>Date</th>
			<th>Extended</th>
			<th>TickDeadline</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:MessageItem runat="server">
		<tr>
			<td><OrionsBelt:MessageId runat="server" /></td>
			<td><OrionsBelt:MessageParameters runat="server" /></td>
			<td><OrionsBelt:MessageCategory runat="server" /></td>
			<td><OrionsBelt:MessageSubCategory runat="server" /></td>
			<td><OrionsBelt:MessageOwnerId runat="server" /></td>
			<td><OrionsBelt:MessageDate runat="server" /></td>
			<td><OrionsBelt:MessageExtended runat="server" /></td>
			<td><OrionsBelt:MessageTickDeadline runat="server" /></td>
			<td><OrionsBelt:MessageCreatedDate runat="server" /></td>
			<td><OrionsBelt:MessageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MessageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MessageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MessageItem>
	</table>
	</OrionsBelt:MessagePagedList>
</asp:Content>