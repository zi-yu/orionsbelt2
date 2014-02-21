<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "timedactionstorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:TimedActionStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:TimedActionStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:TimedActionStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageStartTickSort InnerHtml="StartTick" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageEndTickSort InnerHtml="EndTick" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageDataSort InnerHtml="Data" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:TimedActionStorageLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:TimedActionStorageItem runat="server">
		<tr>
			<td><OrionsBelt:TimedActionStorageId runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageStartTick runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageEndTick runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageData runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageName runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageCreatedDate runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageUpdatedDate runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:TimedActionStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:TimedActionStorageItem>
	</table>
	<OrionsBelt:TimedActionStorageNumberPagination runat="server" />
	</OrionsBelt:TimedActionStoragePagedList>

</asp:Content>