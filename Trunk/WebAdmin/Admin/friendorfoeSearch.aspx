<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "friendorfoe";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search FriendOrFoe</h2>
	<p>Use this page to search for objects of the FriendOrFoe type.</p>
	<div class="searchTable">
		<OrionsBelt:FriendOrFoeSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:FriendOrFoePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>IsFriend</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:FriendOrFoePagedList>
</asp:Content>