<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "botcredential";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:BotCredentialEditor runat="server" Source="QueryString" ID="BotCredentialEditorId1" >
	<h2>Edit BotCredential </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:BotCredentialIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:BotCredentialNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Server</b></td>
			<td>
				<OrionsBelt:BotCredentialServerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>VerificationCode</b></td>
			<td>
				<OrionsBelt:BotCredentialVerificationCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotId</b></td>
			<td>
				<OrionsBelt:BotCredentialBotIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:BotCredentialCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:BotCredentialUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:BotCredentialLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete BotCredential</h2>
	<p><OrionsBelt:BotCredentialDelete OnDeleteRedirectTo="/admin/botcredentialManage.aspx" runat="server" /></p>
	
</OrionsBelt:BotCredentialEditor>
</asp:Content>