<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstats";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create PlayerStats</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PlayerStatsEditor runat="server" Source="New" ID="PlayerStatsEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PlayerStatsIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberOfPlayedBattles</b></td>
			<td><OrionsBelt:PlayerStatsNumberOfPlayedBattlesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberPirateQuest</b></td>
			<td><OrionsBelt:PlayerStatsNumberPirateQuestEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberBountyQuests</b></td>
			<td><OrionsBelt:PlayerStatsNumberBountyQuestsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberMerchantQuests</b></td>
			<td><OrionsBelt:PlayerStatsNumberMerchantQuestsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberGladiatorQuests</b></td>
			<td><OrionsBelt:PlayerStatsNumberGladiatorQuestsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberColonizerQuests</b></td>
			<td><OrionsBelt:PlayerStatsNumberColonizerQuestsEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PlayerStatsCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PlayerStatsUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PlayerStatsLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStatsEditor>
	</table>
	</asp:Content>