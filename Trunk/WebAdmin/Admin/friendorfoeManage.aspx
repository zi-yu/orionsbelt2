<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "friendorfoe";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:FriendOrFoePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:FriendOrFoeNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:FriendOrFoeIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:FriendOrFoeIsFriendSort InnerHtml="IsFriend" runat="server" /></th>
			<th><OrionsBelt:FriendOrFoeCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:FriendOrFoeUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:FriendOrFoeLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:FriendOrFoeItem runat="server">
		<tr>
			<td><OrionsBelt:FriendOrFoeId runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeIsFriend runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeCreatedDate runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeUpdatedDate runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FriendOrFoeDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FriendOrFoeItem>
	</table>
	<OrionsBelt:FriendOrFoeNumberPagination runat="server" />
	</OrionsBelt:FriendOrFoePagedList>

</asp:Content>