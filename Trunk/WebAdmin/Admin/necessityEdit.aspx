<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "necessity";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:NecessityEditor runat="server" Source="QueryString" ID="NecessityEditorId1" >
	<h2>Edit Necessity &lt;<OrionsBelt:NecessityDescription runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:NecessityIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:NecessityTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Description</b></td>
			<td>
				<OrionsBelt:NecessityDescriptionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Coordinate</b></td>
			<td>
				<OrionsBelt:NecessityCoordinateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Status</b></td>
			<td>
				<OrionsBelt:NecessityStatusEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Creator</b></td>
			<td>
				<OrionsBelt:NecessityCreatorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Alliance</b></td>
			<td>
				<OrionsBelt:NecessityAllianceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:NecessityCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:NecessityUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:NecessityLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Necessity :: Tasks 
		[<a href='/admin/taskCreate.aspx?TaskNecessityEditorFilter=<OrionsBelt:NecessityId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:NecessityTasks runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Status</th>
			<th>Priority</th>
			<th>Title</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Necessity">Delete</th>
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
	</OrionsBelt:NecessityTasks>

	<h2>Delete Necessity</h2>
	<p><OrionsBelt:NecessityDelete OnDeleteRedirectTo="/admin/necessityManage.aspx" runat="server" /></p>
	
</OrionsBelt:NecessityEditor>
</asp:Content>