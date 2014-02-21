<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "country";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:CountryPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:CountryNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:CountryIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:CountryNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:CountryAbbreviationSort InnerHtml="Abbreviation" runat="server" /></th>
			<th><OrionsBelt:CountryIsEUSort InnerHtml="IsEU" runat="server" /></th>
			<th><OrionsBelt:CountryCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:CountryUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:CountryLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:CountryItem runat="server">
		<tr>
			<td><OrionsBelt:CountryId runat="server" /></td>
			<td><OrionsBelt:CountryName runat="server" /></td>
			<td><OrionsBelt:CountryAbbreviation runat="server" /></td>
			<td><OrionsBelt:CountryIsEU runat="server" /></td>
			<td><OrionsBelt:CountryCreatedDate runat="server" /></td>
			<td><OrionsBelt:CountryUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CountryLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CountryDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CountryItem>
	</table>
	<OrionsBelt:CountryNumberPagination runat="server" />
	</OrionsBelt:CountryPagedList>

</asp:Content>