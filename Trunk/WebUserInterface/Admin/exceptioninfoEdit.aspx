﻿<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "exceptioninfo";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ExceptionInfoEditor runat="server" Source="QueryString" ID="ExceptionInfoEditorId1" >
	<h2>Edit ExceptionInfo &lt;<OrionsBelt:ExceptionInfoMessage runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ExceptionInfoIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:ExceptionInfoNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Message</b></td>
			<td>
				<OrionsBelt:ExceptionInfoMessageEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Date</b></td>
			<td>
				<OrionsBelt:ExceptionInfoDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:ExceptionInfoPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Url</b></td>
			<td>
				<OrionsBelt:ExceptionInfoUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StackTrace</b></td>
			<td>
				<OrionsBelt:ExceptionInfoStackTraceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ExceptionInfoCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ExceptionInfoUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ExceptionInfoLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete ExceptionInfo</h2>
	<p><OrionsBelt:ExceptionInfoDelete OnDeleteRedirectTo="/admin/exceptioninfoManage.aspx" runat="server" /></p>
	
</OrionsBelt:ExceptionInfoEditor>
</asp:Content>