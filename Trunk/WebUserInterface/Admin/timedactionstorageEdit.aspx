<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "timedactionstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:TimedActionStorageEditor runat="server" Source="QueryString" ID="TimedActionStorageEditorId1" >
	<h2>Edit TimedActionStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:TimedActionStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StartTick</b></td>
			<td>
				<OrionsBelt:TimedActionStorageStartTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EndTick</b></td>
			<td>
				<OrionsBelt:TimedActionStorageEndTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Data</b></td>
			<td>
				<OrionsBelt:TimedActionStorageDataEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:TimedActionStorageNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Player</b></td>
			<td>
				<OrionsBelt:TimedActionStoragePlayerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Battle</b></td>
			<td>
				<OrionsBelt:TimedActionStorageBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:TimedActionStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:TimedActionStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:TimedActionStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete TimedActionStorage</h2>
	<p><OrionsBelt:TimedActionStorageDelete OnDeleteRedirectTo="/admin/timedactionstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:TimedActionStorageEditor>
</asp:Content>