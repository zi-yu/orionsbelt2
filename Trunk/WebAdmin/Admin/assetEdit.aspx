<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "asset";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:AssetEditor runat="server" Source="QueryString" ID="AssetEditorId1" >
	<h2>Edit Asset &lt;<OrionsBelt:AssetDescription runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:AssetIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:AssetTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Description</b></td>
			<td>
				<OrionsBelt:AssetDescriptionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Coordinate</b></td>
			<td>
				<OrionsBelt:AssetCoordinateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:AssetOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Task</b></td>
			<td>
				<OrionsBelt:AssetTaskEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Alliance</b></td>
			<td>
				<OrionsBelt:AssetAllianceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:AssetCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:AssetUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:AssetLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Asset</h2>
	<p><OrionsBelt:AssetDelete OnDeleteRedirectTo="/admin/assetManage.aspx" runat="server" /></p>
	
</OrionsBelt:AssetEditor>
</asp:Content>