<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "task";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:TaskEditor runat="server" Source="QueryString" ID="TaskEditorId1" >
	<h2>Edit Task </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:TaskIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Status</b></td>
			<td>
				<OrionsBelt:TaskStatusEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Priority</b></td>
			<td>
				<OrionsBelt:TaskPriorityEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Title</b></td>
			<td>
				<OrionsBelt:TaskTitleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Necessity</b></td>
			<td>
				<OrionsBelt:TaskNecessityEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:TaskCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:TaskUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:TaskLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Task :: Assets 
		[<a href='/admin/assetCreate.aspx?AssetTaskEditorFilter=<OrionsBelt:TaskId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:TaskAssets runat="server">
		<table class="editTable">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th title="Delete from Task">Delete</th>
		</tr>
		<OrionsBelt:AssetItem runat="server">
		<tr>
			<td><OrionsBelt:AssetDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AssetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AssetItem>
	</table>
	</OrionsBelt:TaskAssets>

	<h2>Delete Task</h2>
	<p><OrionsBelt:TaskDelete OnDeleteRedirectTo="/admin/taskManage.aspx" runat="server" /></p>
	
</OrionsBelt:TaskEditor>
</asp:Content>