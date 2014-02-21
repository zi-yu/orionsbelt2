<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "timedactionstorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search TimedActionStorage</h2>
	<p>Use this page to search for objects of the TimedActionStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:TimedActionStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:TimedActionStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>StartTick</th>
			<th>EndTick</th>
			<th>Data</th>
			<th>Name</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:TimedActionStoragePagedList>
</asp:Content>