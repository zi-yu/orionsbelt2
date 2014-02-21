<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "privateboard";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PrivateBoardPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PrivateBoardNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PrivateBoardIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardReceiverSort InnerHtml="Receiver" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardMessageSort InnerHtml="Message" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardWasReadSort InnerHtml="WasRead" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PrivateBoardLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PrivateBoardItem runat="server">
		<tr>
			<td><OrionsBelt:PrivateBoardId runat="server" /></td>
			<td><OrionsBelt:PrivateBoardReceiver runat="server" /></td>
			<td><OrionsBelt:PrivateBoardType runat="server" /></td>
			<td><OrionsBelt:PrivateBoardMessage runat="server" /></td>
			<td><OrionsBelt:PrivateBoardWasRead runat="server" /></td>
			<td><OrionsBelt:PrivateBoardCreatedDate runat="server" /></td>
			<td><OrionsBelt:PrivateBoardUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PrivateBoardLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrivateBoardDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrivateBoardItem>
	</table>
	<OrionsBelt:PrivateBoardNumberPagination runat="server" />
	</OrionsBelt:PrivateBoardPagedList>

</asp:Content>