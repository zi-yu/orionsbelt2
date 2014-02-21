<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "market";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Market</h2>
	<p>Use this page to search for objects of the Market type.</p>
	<div class="searchTable">
		<OrionsBelt:MarketSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:MarketPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Level</th>
			<th>Coordinates</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:MarketItem runat="server">
		<tr>
			<td><OrionsBelt:MarketId runat="server" /></td>
			<td><OrionsBelt:MarketName runat="server" /></td>
			<td><OrionsBelt:MarketLevel runat="server" /></td>
			<td><OrionsBelt:MarketCoordinates runat="server" /></td>
			<td><OrionsBelt:MarketCreatedDate runat="server" /></td>
			<td><OrionsBelt:MarketUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MarketLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MarketDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MarketItem>
	</table>
	</OrionsBelt:MarketPagedList>
</asp:Content>