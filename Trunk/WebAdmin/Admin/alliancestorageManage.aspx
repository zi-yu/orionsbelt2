<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "alliancestorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:AllianceStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:AllianceStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:AllianceStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:AllianceStorageNameSort InnerHtml="Name" runat="server" /></th>
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
	<OrionsBelt:AllianceStorageNumberPagination runat="server" />
	</OrionsBelt:AllianceStoragePagedList>

</asp:Content>