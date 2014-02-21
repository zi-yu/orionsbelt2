<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "product";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Product</h2>
	<p>Use this page to search for objects of the Product type.</p>
	<div class="searchTable">
		<OrionsBelt:ProductSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ProductPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Price</th>
			<th>Type</th>
			<th>Quantity</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ProductPagedList>
</asp:Content>