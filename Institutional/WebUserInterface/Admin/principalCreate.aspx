<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principal";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Principal</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<Institutional:PrincipalEditor runat="server" Source="New" ID="PrincipalEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><Institutional:PrincipalIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><Institutional:PrincipalNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Password</b></td>
			<td><Institutional:PrincipalPasswordEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Email</b></td>
			<td><Institutional:PrincipalEmailEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Ip</b></td>
			<td><Institutional:PrincipalIpEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RegistDate</b></td>
			<td><Institutional:PrincipalRegistDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastLogin</b></td>
			<td><Institutional:PrincipalLastLoginEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Approved</b></td>
			<td><Institutional:PrincipalApprovedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsOnline</b></td>
			<td><Institutional:PrincipalIsOnlineEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Locked</b></td>
			<td><Institutional:PrincipalLockedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Locale</b></td>
			<td><Institutional:PrincipalLocaleEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>ConfirmationCode</b></td>
			<td><Institutional:PrincipalConfirmationCodeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RawRoles</b></td>
			<td><Institutional:PrincipalRawRolesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><Institutional:PrincipalCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><Institutional:PrincipalUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><Institutional:PrincipalLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</Institutional:PrincipalEditor>
	</table>
	</asp:Content>