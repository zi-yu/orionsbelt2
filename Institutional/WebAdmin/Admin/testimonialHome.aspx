<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "testimonial";
		HttpContext.Current.Session["CurrentAction"] = "Home";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Testimonial Information</h2>
	<p>This Entity has <b><Institutional:TestimonialCount runat="server" /></b> elements.</p>
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
			<td><b>locale</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>content</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>author</b></td>
			<td>string</td>
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
	<Institutional:TestimonialDeleteAll runat="server" />
</asp:Content>