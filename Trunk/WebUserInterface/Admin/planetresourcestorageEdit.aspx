<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "planetresourcestorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PlanetResourceStorageEditor runat="server" Source="QueryString" ID="PlanetResourceStorageEditorId1" >
	<h2>Edit PlanetResourceStorage &lt;<OrionsBelt:PlanetResourceStorageType runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Quantity</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageQuantityEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>State</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageStateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>QueueOrder</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageQueueOrderEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Slot</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageSlotEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EndTick</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageEndTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Planet</b></td>
			<td>
				<OrionsBelt:PlanetResourceStoragePlanetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Player</b></td>
			<td>
				<OrionsBelt:PlanetResourceStoragePlayerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PlanetResourceStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete PlanetResourceStorage</h2>
	<p><OrionsBelt:PlanetResourceStorageDelete OnDeleteRedirectTo="/admin/planetresourcestorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:PlanetResourceStorageEditor>
</asp:Content>