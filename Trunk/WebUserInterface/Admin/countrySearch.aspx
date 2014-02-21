<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "country";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Country</h2>
	<p>Use this page to search for objects of the Country type.</p>
	<div class="searchTable">
		<OrionsBelt:CountrySearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:CountryPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Abbreviation</th>
			<th>IsEU</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:CountryPagedList>
</asp:Content>