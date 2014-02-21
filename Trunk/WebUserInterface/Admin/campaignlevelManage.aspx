<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaignlevel";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:CampaignLevelPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:CampaignLevelNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:CampaignLevelIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelBotFleetSort InnerHtml="BotFleet" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelPlayerFleetSort InnerHtml="PlayerFleet" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelBotNameSort InnerHtml="BotName" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:CampaignLevelLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:CampaignLevelItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignLevelId runat="server" /></td>
			<td><OrionsBelt:CampaignLevelBotFleet runat="server" /></td>
			<td><OrionsBelt:CampaignLevelPlayerFleet runat="server" /></td>
			<td><OrionsBelt:CampaignLevelLevel runat="server" /></td>
			<td><OrionsBelt:CampaignLevelBotName runat="server" /></td>
			<td><OrionsBelt:CampaignLevelCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignLevelUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignLevelLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignLevelDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignLevelItem>
	</table>
	<OrionsBelt:CampaignLevelNumberPagination runat="server" />
	</OrionsBelt:CampaignLevelPagedList>

</asp:Content>