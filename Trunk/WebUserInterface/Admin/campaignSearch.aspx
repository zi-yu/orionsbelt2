<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaign";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Campaign</h2>
	<p>Use this page to search for objects of the Campaign type.</p>
	<div class="searchTable">
		<OrionsBelt:CampaignSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:CampaignPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:CampaignPagedList>
</asp:Content>