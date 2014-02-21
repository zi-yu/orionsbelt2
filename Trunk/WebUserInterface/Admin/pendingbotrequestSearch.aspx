<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "pendingbotrequest";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PendingBotRequest</h2>
	<p>Use this page to search for objects of the PendingBotRequest type.</p>
	<div class="searchTable">
		<OrionsBelt:PendingBotRequestSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PendingBotRequestPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>BotName</th>
			<th>Xml</th>
			<th>BattleId</th>
			<th>BotId</th>
			<th>Code</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:PendingBotRequestPagedList>
</asp:Content>