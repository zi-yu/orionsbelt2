<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "teamstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:TeamStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:TeamStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:TeamStorageNameSort InnerHtml="Name" runat="server" /></th>
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
	<OrionsBelt:TeamStorageNumberPagination runat="server" />
	</OrionsBelt:TeamStoragePagedList>

</asp:Content>