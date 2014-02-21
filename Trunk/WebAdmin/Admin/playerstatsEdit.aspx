<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PlayerStatsEditor runat="server" Source="QueryString" ID="PlayerStatsEditorId1" >
	<h2>Edit PlayerStats </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PlayerStatsIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberOfPlayedBattles</b></td>
			<td>
				<OrionsBelt:PlayerStatsNumberOfPlayedBattlesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberPirateQuest</b></td>
			<td>
				<OrionsBelt:PlayerStatsNumberPirateQuestEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberBountyQuests</b></td>
			<td>
				<OrionsBelt:PlayerStatsNumberBountyQuestsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberMerchantQuests</b></td>
			<td>
				<OrionsBelt:PlayerStatsNumberMerchantQuestsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberGladiatorQuests</b></td>
			<td>
				<OrionsBelt:PlayerStatsNumberGladiatorQuestsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>NumberColonizerQuests</b></td>
			<td>
				<OrionsBelt:PlayerStatsNumberColonizerQuestsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PlayerStatsCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PlayerStatsUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PlayerStatsLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		PlayerStats :: Player 
		[<a href='/admin/playerstorageCreate.aspx?PlayerStorageStatsEditorFilter=<OrionsBelt:PlayerStatsId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStatsPlayer runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Score</th>
			<th>Edit</th>
			<th title="Delete from PlayerStats">Delete</th>
		</tr>
		<OrionsBelt:PlayerStorageItem runat="server">
		<tr>
			<td><OrionsBelt:PlayerStorageId runat="server" /></td>
			<td><OrionsBelt:PlayerStorageName runat="server" /></td>
			<td><OrionsBelt:PlayerStorageScore runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayerStorageDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStorageItem>
	</table>
	</OrionsBelt:PlayerStatsPlayer>
	<h2>
		PlayerStats :: BattleStats 
		[<a href='/admin/battlestatsCreate.aspx?BattleStatsPlayerStatsEditorFilter=<OrionsBelt:PlayerStatsId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PlayerStatsBattleStats runat="server">
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
			<th title="Delete from PlayerStats">Delete</th>
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
	</OrionsBelt:PlayerStatsBattleStats>

	<h2>Delete PlayerStats</h2>
	<p><OrionsBelt:PlayerStatsDelete OnDeleteRedirectTo="/admin/playerstatsManage.aspx" runat="server" /></p>
	
</OrionsBelt:PlayerStatsEditor>
</asp:Content>