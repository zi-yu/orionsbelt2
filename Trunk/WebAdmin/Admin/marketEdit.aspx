<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "market";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:MarketEditor runat="server" Source="QueryString" ID="MarketEditorId1" >
	<h2>Edit Market </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:MarketIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:MarketNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:MarketLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Coordinates</b></td>
			<td>
				<OrionsBelt:MarketCoordinatesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sector</b></td>
			<td>
				<OrionsBelt:MarketSectorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:MarketCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:MarketUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:MarketLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Market :: Products 
		[<a href='/admin/productCreate.aspx?ProductMarketEditorFilter=<OrionsBelt:MarketId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:MarketProducts runat="server">
		<table class="editTable">
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
			<th title="Delete from Market">Delete</th>
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
	</OrionsBelt:MarketProducts>

	<h2>Delete Market</h2>
	<p><OrionsBelt:MarketDelete OnDeleteRedirectTo="/admin/marketManage.aspx" runat="server" /></p>
	
</OrionsBelt:MarketEditor>
</asp:Content>