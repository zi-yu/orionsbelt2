<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "alliancestorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search AllianceStorage</h2>
	<p>Use this page to search for objects of the AllianceStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:AllianceStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:AllianceStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:AllianceStorageItem runat="server">
		<tr>
			<td><OrionsBelt:AllianceStorageId runat="server" /></td>
			<td><OrionsBelt:AllianceStorageName runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AllianceStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AllianceStorageItem>
	</table>
	</OrionsBelt:AllianceStoragePagedList>
</asp:Content>