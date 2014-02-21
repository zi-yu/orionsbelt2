<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battlestats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:BattleStatsEditor runat="server" Source="QueryString" ID="BattleStatsEditorId1" >
	<h2>Edit BattleStats </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:BattleStatsIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Wins</b></td>
			<td>
				<OrionsBelt:BattleStatsWinsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Defeats</b></td>
			<td>
				<OrionsBelt:BattleStatsDefeatsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:BattleStatsTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Detail</b></td>
			<td>
				<OrionsBelt:BattleStatsDetailEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>GiveUps</b></td>
			<td>
				<OrionsBelt:BattleStatsGiveUpsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Stats</b></td>
			<td>
				<OrionsBelt:BattleStatsStatsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PlayerStats</b></td>
			<td>
				<OrionsBelt:BattleStatsPlayerStatsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:BattleStatsCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:BattleStatsUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:BattleStatsLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete BattleStats</h2>
	<p><OrionsBelt:BattleStatsDelete OnDeleteRedirectTo="/admin/battlestatsManage.aspx" runat="server" /></p>
	
</OrionsBelt:BattleStatsEditor>
</asp:Content>