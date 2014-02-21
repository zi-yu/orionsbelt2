<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "grouppointsstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:GroupPointsStorageEditor runat="server" Source="QueryString" ID="GroupPointsStorageEditorId1" >
	<h2>Edit GroupPointsStorage </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Stage</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageStageEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Pontuation</b></td>
			<td>
				<OrionsBelt:GroupPointsStoragePontuationEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Wins</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageWinsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Losses</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageLossesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Regist</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageRegistEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:GroupPointsStorageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete GroupPointsStorage</h2>
	<p><OrionsBelt:GroupPointsStorageDelete OnDeleteRedirectTo="/admin/grouppointsstorageManage.aspx" runat="server" /></p>
	
</OrionsBelt:GroupPointsStorageEditor>
</asp:Content>