<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bothandler";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BotHandlerPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BotHandlerNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BotHandlerIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:BotHandlerNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:BotHandlerCodeSort InnerHtml="Code" runat="server" /></th>
			<th><OrionsBelt:BotHandlerCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:BotHandlerUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:BotHandlerLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BotHandlerItem runat="server">
		<tr>
			<td><OrionsBelt:BotHandlerId runat="server" /></td>
			<td><OrionsBelt:BotHandlerName runat="server" /></td>
			<td><OrionsBelt:BotHandlerCode runat="server" /></td>
			<td><OrionsBelt:BotHandlerCreatedDate runat="server" /></td>
			<td><OrionsBelt:BotHandlerUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BotHandlerLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BotHandlerDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BotHandlerItem>
	</table>
	<OrionsBelt:BotHandlerNumberPagination runat="server" />
	</OrionsBelt:BotHandlerPagedList>

</asp:Content>