<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<Institutional:PrincipalEditor runat="server" Source="QueryString" ID="PrincipalEditorId1" >
	<h2>Edit Principal &lt;<Institutional:PrincipalName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<Institutional:PrincipalIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<Institutional:PrincipalNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Password</b></td>
			<td>
				<Institutional:PrincipalPasswordEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Email</b></td>
			<td>
				<Institutional:PrincipalEmailEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Ip</b></td>
			<td>
				<Institutional:PrincipalIpEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RegistDate</b></td>
			<td>
				<Institutional:PrincipalRegistDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastLogin</b></td>
			<td>
				<Institutional:PrincipalLastLoginEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Approved</b></td>
			<td>
				<Institutional:PrincipalApprovedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsOnline</b></td>
			<td>
				<Institutional:PrincipalIsOnlineEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locked</b></td>
			<td>
				<Institutional:PrincipalLockedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locale</b></td>
			<td>
				<Institutional:PrincipalLocaleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ConfirmationCode</b></td>
			<td>
				<Institutional:PrincipalConfirmationCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RawRoles</b></td>
			<td>
				<Institutional:PrincipalRawRolesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<Institutional:PrincipalCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<Institutional:PrincipalUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<Institutional:PrincipalLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Principal :: Exceptions 
		[<a href='/admin/exceptioninfoCreate.aspx?ExceptionInfoPrincipalEditorFilter=<Institutional:PrincipalId runat="server" />'>Add</a>]
	</h2>
	<Institutional:PrincipalExceptions runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Message</th>
			<th>Edit</th>
			<th title="Delete from Principal">Delete</th>
		</tr>
		<Institutional:ExceptionInfoItem runat="server">
		<tr>
			<td><Institutional:ExceptionInfoId runat="server" /></td>
			<td><Institutional:ExceptionInfoMessage runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:ExceptionInfoDelete runat="server" /></td>
		</tr>
		</Institutional:ExceptionInfoItem>
	</table>
	</Institutional:PrincipalExceptions>

	<h2>Delete Principal</h2>
	<p><Institutional:PrincipalDelete OnDeleteRedirectTo="/admin/principalManage.aspx" runat="server" /></p>
	
</Institutional:PrincipalEditor>
</asp:Content>