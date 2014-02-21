<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "task";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Task</h2>
	<p>Use this page to search for objects of the Task type.</p>
	<div class="searchTable">
		<OrionsBelt:TaskSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:TaskPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Status</th>
			<th>Priority</th>
			<th>Title</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:TaskItem runat="server">
		<tr>
			<td><OrionsBelt:TaskId runat="server" /></td>
			<td><OrionsBelt:TaskStatus runat="server" /></td>
			<td><OrionsBelt:TaskPriority runat="server" /></td>
			<td><OrionsBelt:TaskTitle runat="server" /></td>
			<td><OrionsBelt:TaskCreatedDate runat="server" /></td>
			<td><OrionsBelt:TaskUpdatedDate runat="server" /></td>
			<td><OrionsBelt:TaskLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TaskDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TaskItem>
	</table>
	</OrionsBelt:TaskPagedList>
</asp:Content>