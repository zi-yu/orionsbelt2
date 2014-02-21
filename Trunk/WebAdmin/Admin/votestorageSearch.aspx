<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "votestorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search VoteStorage</h2>
	<p>Use this page to search for objects of the VoteStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:VoteStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:VoteStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Data</th>
			<th>OwnerId</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:VoteStoragePagedList>
</asp:Content>