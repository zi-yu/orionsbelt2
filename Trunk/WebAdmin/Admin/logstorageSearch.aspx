<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "logstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search LogStorage</h2>
	<p>Use this page to search for objects of the LogStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:LogStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:LogStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Date</th>
			<th>Username1</th>
			<th>Level</th>
			<th>Url</th>
			<th>Content</th>
			<th>ExceptionInformation</th>
			<th>Ip</th>
			<th>Type</th>
			<th>Username2</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:LogStoragePagedList>
</asp:Content>