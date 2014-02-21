<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "paymentdescription";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PaymentDescription</h2>
	<p>Use this page to search for objects of the PaymentDescription type.</p>
	<div class="searchTable">
		<OrionsBelt:PaymentDescriptionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PaymentDescriptionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Type</th>
			<th>Amount</th>
			<th>Bonus</th>
			<th>Cost</th>
			<th>Locale</th>
			<th>Data</th>
			<th>Currency</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:PaymentDescriptionPagedList>
</asp:Content>