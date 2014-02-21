<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "pendingbotrequest";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PendingBotRequestPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PendingBotRequestNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PendingBotRequestIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestBotNameSort InnerHtml="BotName" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestXmlSort InnerHtml="Xml" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestBattleIdSort InnerHtml="BattleId" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestBotIdSort InnerHtml="BotId" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestCodeSort InnerHtml="Code" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PendingBotRequestLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PendingBotRequestItem runat="server">
		<tr>
			<td><OrionsBelt:PendingBotRequestId runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestBotName runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestXml runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestBattleId runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestBotId runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestCode runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestCreatedDate runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PendingBotRequestDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PendingBotRequestItem>
	</table>
	<OrionsBelt:PendingBotRequestNumberPagination runat="server" />
	</OrionsBelt:PendingBotRequestPagedList>

</asp:Content>