<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "product";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Product</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:ProductEditor runat="server" Source="New" ID="ProductEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:ProductIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:ProductNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Price</b></td>
			<td><OrionsBelt:ProductPriceEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Type</b></td>
			<td><OrionsBelt:ProductTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Quantity</b></td>
			<td><OrionsBelt:ProductQuantityEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Market</b></td>
			<td><OrionsBelt:ProductMarketEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:ProductCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:ProductUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:ProductLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:ProductEditor>
	</table>
	</asp:Content>