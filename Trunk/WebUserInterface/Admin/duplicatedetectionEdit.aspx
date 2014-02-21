<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "duplicatedetection";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:DuplicateDetectionEditor runat="server" Source="QueryString" ID="DuplicateDetectionEditorId1" >
	<h2>Edit DuplicateDetection </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Cheater</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionCheaterEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Duplicate</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionDuplicateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>FindType</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionFindTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ExtraInfo</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionExtraInfoEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Verified</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionVerifiedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:DuplicateDetectionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete DuplicateDetection</h2>
	<p><OrionsBelt:DuplicateDetectionDelete OnDeleteRedirectTo="/admin/duplicatedetectionManage.aspx" runat="server" /></p>
	
</OrionsBelt:DuplicateDetectionEditor>
</asp:Content>