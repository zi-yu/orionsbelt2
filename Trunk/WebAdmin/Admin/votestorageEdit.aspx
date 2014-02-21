<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "votestorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:VoteStorageEditor runat="server" Source="QueryString" ID="VoteStorageEditorId1" >
	<h2>Edit VoteStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:VoteStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Data</b></td>
			<td>
				<OrionsBelt:VoteStorageDataEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>OwnerId</b></td>
			<td>
				<OrionsBelt:VoteStorageOwnerIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:VoteStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:VoteStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:VoteStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete VoteStorage</h2>
	<p><OrionsBelt:VoteStorageDelete OnDeleteRedirectTo="/admin/votestorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:VoteStorageEditor>
</asp:Content>