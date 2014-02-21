<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "paymentdescription";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PaymentDescriptionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PaymentDescriptionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PaymentDescriptionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionAmountSort InnerHtml="Amount" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionBonusSort InnerHtml="Bonus" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionCostSort InnerHtml="Cost" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionLocaleSort InnerHtml="Locale" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionDataSort InnerHtml="Data" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionCurrencySort InnerHtml="Currency" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PaymentDescriptionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PaymentDescriptionItem runat="server">
		<tr>
			<td><OrionsBelt:PaymentDescriptionId runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionType runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionAmount runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionBonus runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionCost runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionLocale runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionData runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionCurrency runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionCreatedDate runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PaymentDescriptionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PaymentDescriptionItem>
	</table>
	<OrionsBelt:PaymentDescriptionNumberPagination runat="server" />
	</OrionsBelt:PaymentDescriptionPagedList>

</asp:Content>