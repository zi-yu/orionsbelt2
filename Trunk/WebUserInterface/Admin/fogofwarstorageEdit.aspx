<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fogofwarstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:FogOfWarStorageEditor runat="server" Source="QueryString" ID="FogOfWarStorageEditorId1" >
	<h2>Edit FogOfWarStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemX</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageSystemXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemY</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageSystemYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sectors</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageSectorsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasDiscoveredAll</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageHasDiscoveredAllEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>HasDiscoveredHalf</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageHasDiscoveredHalfEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:FogOfWarStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete FogOfWarStorage</h2>
	<p><OrionsBelt:FogOfWarStorageDelete OnDeleteRedirectTo="/admin/fogofwarstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:FogOfWarStorageEditor>
</asp:Content>