<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "product";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ProductPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ProductNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ProductIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ProductNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:ProductPriceSort InnerHtml="Price" runat="server" /></th>
			<th><OrionsBelt:ProductTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:ProductQuantitySort InnerHtml="Quantity" runat="server" /></th>
			<th><OrionsBelt:ProductCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ProductUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ProductLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ProductItem runat="server">
		<tr>
			<td><OrionsBelt:ProductId runat="server" /></td>
			<td><OrionsBelt:ProductName runat="server" /></td>
			<td><OrionsBelt:ProductPrice runat="server" /></td>
			<td><OrionsBelt:ProductType runat="server" /></td>
			<td><OrionsBelt:ProductQuantity runat="server" /></td>
			<td><OrionsBelt:ProductCreatedDate runat="server" /></td>
			<td><OrionsBelt:ProductUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ProductLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ProductDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ProductItem>
	</table>
	<OrionsBelt:ProductNumberPagination runat="server" />
	</OrionsBelt:ProductPagedList>

</asp:Content>