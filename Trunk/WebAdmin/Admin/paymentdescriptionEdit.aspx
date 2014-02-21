<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "paymentdescription";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PaymentDescriptionEditor runat="server" Source="QueryString" ID="PaymentDescriptionEditorId1" >
	<h2>Edit PaymentDescription </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Amount</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionAmountEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Bonus</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionBonusEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Cost</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionCostEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locale</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionLocaleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Data</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionDataEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Currency</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionCurrencyEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PaymentDescriptionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete PaymentDescription</h2>
	<p><OrionsBelt:PaymentDescriptionDelete OnDeleteRedirectTo="/admin/paymentdescriptionManage.aspx" runat="server" /></p>
	
</OrionsBelt:PaymentDescriptionEditor>
</asp:Content>