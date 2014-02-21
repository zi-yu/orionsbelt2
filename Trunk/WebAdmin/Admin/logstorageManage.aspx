<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "logstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:LogStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:LogStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:LogStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:LogStorageDateSort InnerHtml="Date" runat="server" /></th>
			<th><OrionsBelt:LogStorageUsername1Sort InnerHtml="Username1" runat="server" /></th>
			<th><OrionsBelt:LogStorageLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:LogStorageUrlSort InnerHtml="Url" runat="server" /></th>
			<th><OrionsBelt:LogStorageContentSort InnerHtml="Content" runat="server" /></th>
			<th><OrionsBelt:LogStorageExceptionInformationSort InnerHtml="ExceptionInformation" runat="server" /></th>
			<th><OrionsBelt:LogStorageIpSort InnerHtml="Ip" runat="server" /></th>
			<th><OrionsBelt:LogStorageTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:LogStorageUsername2Sort InnerHtml="Username2" runat="server" /></th>
			<th><OrionsBelt:LogStorageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:LogStorageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:LogStorageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:LogStorageItem runat="server">
		<tr>
			<td><OrionsBelt:LogStorageId runat="server" /></td>
			<td><OrionsBelt:LogStorageDate runat="server" /></td>
			<td><OrionsBelt:LogStorageUsername1 runat="server" /></td>
			<td><OrionsBelt:LogStorageLevel runat="server" /></td>
			<td><OrionsBelt:LogStorageUrl runat="server" /></td>
			<td><OrionsBelt:LogStorageContent runat="server" /></td>
			<td><OrionsBelt:LogStorageExceptionInformation runat="server" /></td>
			<td><OrionsBelt:LogStorageIp runat="server" /></td>
			<td><OrionsBelt:LogStorageType runat="server" /></td>
			<td><OrionsBelt:LogStorageUsername2 runat="server" /></td>
			<td><OrionsBelt:LogStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:LogStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:LogStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:LogStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:LogStorageItem>
	</table>
	<OrionsBelt:LogStorageNumberPagination runat="server" />
	</OrionsBelt:LogStoragePagedList>

</asp:Content>