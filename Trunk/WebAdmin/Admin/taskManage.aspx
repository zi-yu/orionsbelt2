<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "task";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:TaskPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:TaskNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:TaskIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:TaskStatusSort InnerHtml="Status" runat="server" /></th>
			<th><OrionsBelt:TaskPrioritySort InnerHtml="Priority" runat="server" /></th>
			<th><OrionsBelt:TaskTitleSort InnerHtml="Title" runat="server" /></th>
			<th><OrionsBelt:TaskCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:TaskUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:TaskLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:TaskNumberPagination runat="server" />
	</OrionsBelt:TaskPagedList>

</asp:Content>