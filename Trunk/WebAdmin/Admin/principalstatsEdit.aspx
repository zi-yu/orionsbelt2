<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principalstats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PrincipalStatsEditor runat="server" Source="QueryString" ID="PrincipalStatsEditorId1" >
	<h2>Edit PrincipalStats </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PrincipalStatsIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MaxElo</b></td>
			<td>
				<OrionsBelt:PrincipalStatsMaxEloEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MinElo</b></td>
			<td>
				<OrionsBelt:PrincipalStatsMinEloEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberPlayedBattles</b></td>
			<td>
				<OrionsBelt:PrincipalStatsNumberPlayedBattlesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MaxLadder</b></td>
			<td>
				<OrionsBelt:PrincipalStatsMaxLadderEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MinLadder</b></td>
			<td>
				<OrionsBelt:PrincipalStatsMinLadderEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PrincipalStatsCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PrincipalStatsUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PrincipalStatsLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		PrincipalStats :: BattleStats 
		[<a href='/admin/battlestatsCreate.aspx?BattleStatsStatsEditorFilter=<OrionsBelt:PrincipalStatsId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PrincipalStatsBattleStats runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Wins</th>
			<th>Defeats</th>
			<th>Type</th>
			<th>Detail</th>
			<th>GiveUps</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from PrincipalStats">Delete</th>
		</tr>
		<OrionsBelt:BattleStatsItem runat="server">
		<tr>
			<td><OrionsBelt:BattleStatsId runat="server" /></td>
			<td><OrionsBelt:BattleStatsWins runat="server" /></td>
			<td><OrionsBelt:BattleStatsDefeats runat="server" /></td>
			<td><OrionsBelt:BattleStatsType runat="server" /></td>
			<td><OrionsBelt:BattleStatsDetail runat="server" /></td>
			<td><OrionsBelt:BattleStatsGiveUps runat="server" /></td>
			<td><OrionsBelt:BattleStatsCreatedDate runat="server" /></td>
			<td><OrionsBelt:BattleStatsUpdatedDate runat="server" /></td>
			<td><OrionsBelt:BattleStatsLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BattleStatsDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BattleStatsItem>
	</table>
	</OrionsBelt:PrincipalStatsBattleStats>

	<h2>Delete PrincipalStats</h2>
	<p><OrionsBelt:PrincipalStatsDelete OnDeleteRedirectTo="/admin/principalstatsManage.aspx" runat="server" /></p>
	
</OrionsBelt:PrincipalStatsEditor>
</asp:Content>