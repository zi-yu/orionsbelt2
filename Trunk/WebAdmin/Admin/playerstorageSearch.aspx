<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PlayerStorage</h2>
	<p>Use this page to search for objects of the PlayerStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:PlayerStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PlayerStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Score</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PlayerStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlayerStorageId runat="server" /></td>
			<td><OrionsBelt:PlayerStorageName runat="server" /></td>
			<td><OrionsBelt:PlayerStorageScore runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayerStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStorageItem>
	</table>
	</OrionsBelt:PlayerStoragePagedList>
</asp:Content>