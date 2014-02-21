<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "task";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Task</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:TaskEditor runat="server" Source="New" ID="TaskEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:TaskIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Status</b></td>
			<td><OrionsBelt:TaskStatusEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Priority</b></td>
			<td><OrionsBelt:TaskPriorityEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Title</b></td>
			<td><OrionsBelt:TaskTitleEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Necessity</b></td>
			<td><OrionsBelt:TaskNecessityEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:TaskCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:TaskUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:TaskLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:TaskEditor>
	</table>
	</asp:Content>