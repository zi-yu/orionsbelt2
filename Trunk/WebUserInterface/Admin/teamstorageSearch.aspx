<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "teamstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search TeamStorage</h2>
	<p>Use this page to search for objects of the TeamStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:TeamStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:TeamStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Name</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:TeamStorageItem runat="server">
		<tr>
			<td><OrionsBelt:TeamStorageName runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TeamStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TeamStorageItem>
	</table>
	</OrionsBelt:TeamStoragePagedList>
</asp:Content>