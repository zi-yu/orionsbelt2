<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "asset";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Asset</h2>
	<p>Use this page to search for objects of the Asset type.</p>
	<div class="searchTable">
		<OrionsBelt:AssetSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:AssetPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Description</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:AssetItem runat="server">
		<tr>
			<td><OrionsBelt:AssetDescription runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AssetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AssetItem>
	</table>
	</OrionsBelt:AssetPagedList>
</asp:Content>