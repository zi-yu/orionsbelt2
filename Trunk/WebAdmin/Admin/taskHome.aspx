<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "task";
		HttpContext.Current.Session["CurrentAction"] = "Home";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Task Information</h2>
	<p>This Entity has <b><OrionsBelt:TaskCount runat="server" /></b> elements.</p>
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
			<td><b>status</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>priority</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>title</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>necessity</b></td>
			<td>Necessity</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>assets</b></td>
			<td>Asset</td>
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
	<OrionsBelt:TaskDeleteAll runat="server" />
</asp:Content>