<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaign";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:CampaignPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:CampaignNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:CampaignIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:CampaignNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:CampaignCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:CampaignUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:CampaignLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:CampaignItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignId runat="server" /></td>
			<td><OrionsBelt:CampaignName runat="server" /></td>
			<td><OrionsBelt:CampaignCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignItem>
	</table>
	<OrionsBelt:CampaignNumberPagination runat="server" />
	</OrionsBelt:CampaignPagedList>

</asp:Content>