<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "botcredential";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search BotCredential</h2>
	<p>Use this page to search for objects of the BotCredential type.</p>
	<div class="searchTable">
		<OrionsBelt:BotCredentialSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BotCredentialPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Server</th>
			<th>VerificationCode</th>
			<th>BotId</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BotCredentialItem runat="server">
		<tr>
			<td><OrionsBelt:BotCredentialId runat="server" /></td>
			<td><OrionsBelt:BotCredentialName runat="server" /></td>
			<td><OrionsBelt:BotCredentialServer runat="server" /></td>
			<td><OrionsBelt:BotCredentialVerificationCode runat="server" /></td>
			<td><OrionsBelt:BotCredentialBotId runat="server" /></td>
			<td><OrionsBelt:BotCredentialCreatedDate runat="server" /></td>
			<td><OrionsBelt:BotCredentialUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BotCredentialLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BotCredentialDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BotCredentialItem>
	</table>
	</OrionsBelt:BotCredentialPagedList>
</asp:Content>