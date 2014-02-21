<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "playerstats";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PlayerStats</h2>
	<p>Use this page to search for objects of the PlayerStats type.</p>
	<div class="searchTable">
		<OrionsBelt:PlayerStatsSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PlayerStatsPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>NumberOfPlayedBattles</th>
			<th>NumberPirateQuest</th>
			<th>NumberBountyQuests</th>
			<th>NumberMerchantQuests</th>
			<th>NumberGladiatorQuests</th>
			<th>NumberColonizerQuests</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:PlayerStatsPagedList>
</asp:Content>