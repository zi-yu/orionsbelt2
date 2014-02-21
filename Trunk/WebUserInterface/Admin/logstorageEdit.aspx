<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "logstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:LogStorageEditor runat="server" Source="QueryString" ID="LogStorageEditorId1" >
	<h2>Edit LogStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:LogStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Date</b></td>
			<td>
				<OrionsBelt:LogStorageDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Username1</b></td>
			<td>
				<OrionsBelt:LogStorageUsername1Editor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:LogStorageLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Url</b></td>
			<td>
				<OrionsBelt:LogStorageUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Content</b></td>
			<td>
				<OrionsBelt:LogStorageContentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ExceptionInformation</b></td>
			<td>
				<OrionsBelt:LogStorageExceptionInformationEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Ip</b></td>
			<td>
				<OrionsBelt:LogStorageIpEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:LogStorageTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Username2</b></td>
			<td>
				<OrionsBelt:LogStorageUsername2Editor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:LogStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:LogStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:LogStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete LogStorage</h2>
	<p><OrionsBelt:LogStorageDelete OnDeleteRedirectTo="/admin/logstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:LogStorageEditor>
</asp:Content>