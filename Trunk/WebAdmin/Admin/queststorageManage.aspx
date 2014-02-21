<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "queststorage";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:QuestStoragePagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:QuestStorageNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:QuestStorageIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:QuestStoragePercentageSort InnerHtml="Percentage" runat="server" /></th>
			<th><OrionsBelt:QuestStorageNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:QuestStorageTypeSort InnerHtml="Type" runat="server" /></th>
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
	<OrionsBelt:QuestStorageNumberPagination runat="server" />
	</OrionsBelt:QuestStoragePagedList>

</asp:Content>