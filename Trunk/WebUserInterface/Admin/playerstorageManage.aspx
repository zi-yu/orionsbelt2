<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PlayerStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PlayerStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PlayerStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PlayerStorageNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:PlayerStorageScoreSort InnerHtml="Score" runat="server" /></th>
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
	<OrionsBelt:PlayerStorageNumberPagination runat="server" />
	</OrionsBelt:PlayerStoragePagedList>

</asp:Content>