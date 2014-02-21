<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bothandler";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search BotHandler</h2>
	<p>Use this page to search for objects of the BotHandler type.</p>
	<div class="searchTable">
		<OrionsBelt:BotHandlerSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BotHandlerPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Code</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:BotHandlerPagedList>
</asp:Content>