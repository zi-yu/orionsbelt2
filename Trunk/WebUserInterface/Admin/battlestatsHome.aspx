<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battlestats";
		HttpContext.Current.Session["CurrentAction"] = "Home";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>BattleStats Information</h2>
	<p>This Entity has <b><OrionsBelt:BattleStatsCount runat="server" /></b> elements.</p>
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
			<td><b>wins</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>defeats</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>type</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>detail</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>giveUps</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>stats</b></td>
			<td>PrincipalStats</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>playerStats</b></td>
			<td>PlayerStats</td>
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
	<OrionsBelt:BattleStatsDeleteAll runat="server" />
</asp:Content>