<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "botcredential";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BotCredentialPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BotCredentialNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BotCredentialIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:BotCredentialNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:BotCredentialServerSort InnerHtml="Server" runat="server" /></th>
			<th><OrionsBelt:BotCredentialVerificationCodeSort InnerHtml="VerificationCode" runat="server" /></th>
			<th><OrionsBelt:BotCredentialBotIdSort InnerHtml="BotId" runat="server" /></th>
			<th><OrionsBelt:BotCredentialCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:BotCredentialUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:BotCredentialLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:BotCredentialNumberPagination runat="server" />
	</OrionsBelt:BotCredentialPagedList>

</asp:Content>