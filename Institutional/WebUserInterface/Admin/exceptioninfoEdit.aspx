<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "exceptioninfo";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<Institutional:ExceptionInfoEditor runat="server" Source="QueryString" ID="ExceptionInfoEditorId1" >
	<h2>Edit ExceptionInfo &lt;<Institutional:ExceptionInfoMessage runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<Institutional:ExceptionInfoIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<Institutional:ExceptionInfoNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Message</b></td>
			<td>
				<Institutional:ExceptionInfoMessageEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Date</b></td>
			<td>
				<Institutional:ExceptionInfoDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<Institutional:ExceptionInfoPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Url</b></td>
			<td>
				<Institutional:ExceptionInfoUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>StackTrace</b></td>
			<td>
				<Institutional:ExceptionInfoStackTraceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<Institutional:ExceptionInfoCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<Institutional:ExceptionInfoUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<Institutional:ExceptionInfoLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete ExceptionInfo</h2>
	<p><Institutional:ExceptionInfoDelete OnDeleteRedirectTo="/admin/exceptioninfoManage.aspx" runat="server" /></p>
	
</Institutional:ExceptionInfoEditor>
</asp:Content>