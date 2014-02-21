<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "product";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ProductEditor runat="server" Source="QueryString" ID="ProductEditorId1" >
	<h2>Edit Product </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ProductIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:ProductNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Price</b></td>
			<td>
				<OrionsBelt:ProductPriceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:ProductTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Quantity</b></td>
			<td>
				<OrionsBelt:ProductQuantityEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Market</b></td>
			<td>
				<OrionsBelt:ProductMarketEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ProductCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ProductUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ProductLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Product</h2>
	<p><OrionsBelt:ProductDelete OnDeleteRedirectTo="/admin/productManage.aspx" runat="server" /></p>
	
</OrionsBelt:ProductEditor>
</asp:Content>