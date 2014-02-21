<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "votestorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:VoteStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:VoteStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:VoteStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:VoteStorageDataSort InnerHtml="Data" runat="server" /></th>
			<th><OrionsBelt:VoteStorageOwnerIdSort InnerHtml="OwnerId" runat="server" /></th>
			<th><OrionsBelt:VoteStorageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:VoteStorageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:VoteStorageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:VoteStorageItem runat="server">
		<tr>
			<td><OrionsBelt:VoteStorageId runat="server" /></td>
			<td><OrionsBelt:VoteStorageData runat="server" /></td>
			<td><OrionsBelt:VoteStorageOwnerId runat="server" /></td>
			<td><OrionsBelt:VoteStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:VoteStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:VoteStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:VoteStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:VoteStorageItem>
	</table>
	<OrionsBelt:VoteStorageNumberPagination runat="server" />
	</OrionsBelt:VoteStoragePagedList>

</asp:Content>