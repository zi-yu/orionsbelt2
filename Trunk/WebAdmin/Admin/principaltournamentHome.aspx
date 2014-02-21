<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principaltournament";
		HttpContext.Current.Session["CurrentAction"] = "Home";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>PrincipalTournament Information</h2>
	<p>This Entity has <b><OrionsBelt:PrincipalTournamentCount runat="server" /></b> elements.</p>
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
			<td><b>hasEliminated</b></td>
			<td>bool</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>eliminatedInFase</b></td>
			<td>string</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>eliminatedInBattleId</b></td>
			<td>int</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>principal</b></td>
			<td>Principal</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>tournament</b></td>
			<td>Tournament</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>points</b></td>
			<td>GroupPointsStorage</td>
			<td>
				This field has no Regular expressions
			</td>
		<tr>	
		<tr>
			<td><b>team</b></td>
			<td>TeamStorage</td>
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
	<OrionsBelt:PrincipalTournamentDeleteAll runat="server" />
</asp:Content>