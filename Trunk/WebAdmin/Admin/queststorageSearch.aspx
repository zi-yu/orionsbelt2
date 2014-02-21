<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "queststorage";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search QuestStorage</h2>
	<p>Use this page to search for objects of the QuestStorage type.</p>
	<div class="searchTable">
		<OrionsBelt:QuestStorageSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:QuestStoragePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Percentage</th>
			<th>Name</th>
			<th>Type</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:QuestStorageItem runat="server">
		<tr>
			<td><OrionsBelt:QuestStorageId runat="server" /></td>
			<td><OrionsBelt:QuestStoragePercentage runat="server" /></td>
			<td><OrionsBelt:QuestStorageName runat="server" /></td>
			<td><OrionsBelt:QuestStorageType runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:QuestStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:QuestStorageItem>
	</table>
	</OrionsBelt:QuestStoragePagedList>
</asp:Content>