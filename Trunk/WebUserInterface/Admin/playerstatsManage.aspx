<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PlayerStatsPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PlayerStatsNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PlayerStatsIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsNumberOfPlayedBattlesSort InnerHtml="NumberOfPlayedBattles" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsNumberPirateQuestSort InnerHtml="NumberPirateQuest" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsNumberBountyQuestsSort InnerHtml="NumberBountyQuests" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsNumberMerchantQuestsSort InnerHtml="NumberMerchantQuests" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsNumberGladiatorQuestsSort InnerHtml="NumberGladiatorQuests" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsNumberColonizerQuestsSort InnerHtml="NumberColonizerQuests" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PlayerStatsLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PlayerStatsItem runat="server">
		<tr>
			<td><OrionsBelt:PlayerStatsId runat="server" /></td>
			<td><OrionsBelt:PlayerStatsNumberOfPlayedBattles runat="server" /></td>
			<td><OrionsBelt:PlayerStatsNumberPirateQuest runat="server" /></td>
			<td><OrionsBelt:PlayerStatsNumberBountyQuests runat="server" /></td>
			<td><OrionsBelt:PlayerStatsNumberMerchantQuests runat="server" /></td>
			<td><OrionsBelt:PlayerStatsNumberGladiatorQuests runat="server" /></td>
			<td><OrionsBelt:PlayerStatsNumberColonizerQuests runat="server" /></td>
			<td><OrionsBelt:PlayerStatsCreatedDate runat="server" /></td>
			<td><OrionsBelt:PlayerStatsUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PlayerStatsLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PlayerStatsDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PlayerStatsItem>
	</table>
	<OrionsBelt:PlayerStatsNumberPagination runat="server" />
	</OrionsBelt:PlayerStatsPagedList>

</asp:Content>