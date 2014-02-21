<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "market";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:MarketPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:MarketNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:MarketIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:MarketNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:MarketLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:MarketCoordinatesSort InnerHtml="Coordinates" runat="server" /></th>
			<th><OrionsBelt:MarketCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:MarketUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:MarketLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:MarketNumberPagination runat="server" />
	</OrionsBelt:MarketPagedList>

</asp:Content>