<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "transaction";
		HttpContext.Current.Session["CurrentAction"] = "Home";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Transaction Information</h2>
	<p>This Entity has <b><OrionsBelt:TransactionCount runat="server" /></b> elements.</p>
	<h2>Field Information</h2>
	<table class="table">
		<tr>
			<th>Field Name</th>
			<th>Field Type</th>
			<th>Regex</th>
		<tr>			
		<tr>
			<td><b>id</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>transactionContext</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>principalIdSpend</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>identityTypeSpend</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>identifierSpend</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>creditsSpend</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>spendCurrentCredits</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>identityTypeGain</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>identifierGain</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>creditsGain</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>gainCurrentCredits</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>tick</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>invoice</b></td>
			<td>Invoice</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>createdDate</b></td>
			<td>DateTime</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>updatedDate</b></td>
			<td>DateTime</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>lastActionUserId</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
	</table>
	<h2>Delete All</h2>
	<OrionsBelt:TransactionDeleteAll runat="server" />
</asp:Content>