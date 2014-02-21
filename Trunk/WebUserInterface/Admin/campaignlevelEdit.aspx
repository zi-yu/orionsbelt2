<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaignlevel";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:CampaignLevelEditor runat="server" Source="QueryString" ID="CampaignLevelEditorId1" >
	<h2>Edit CampaignLevel </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:CampaignLevelIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotFleet</b></td>
			<td>
				<OrionsBelt:CampaignLevelBotFleetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PlayerFleet</b></td>
			<td>
				<OrionsBelt:CampaignLevelPlayerFleetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:CampaignLevelLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotName</b></td>
			<td>
				<OrionsBelt:CampaignLevelBotNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Campaign</b></td>
			<td>
				<OrionsBelt:CampaignLevelCampaignEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:CampaignLevelCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:CampaignLevelUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:CampaignLevelLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		CampaignLevel :: CampaignStatus 
		[<a href='/admin/campaignstatusCreate.aspx?CampaignStatusLevelTemplateEditorFilter=<OrionsBelt:CampaignLevelId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:CampaignLevelCampaignStatus runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Level</th>
			<th>Moves</th>
			<th>Completed</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from CampaignLevel">Delete</th>
		</tr>
		<OrionsBelt:CampaignStatusItem runat="server">
		<tr>
			<td><OrionsBelt:CampaignStatusId runat="server" /></td>
			<td><OrionsBelt:CampaignStatusLevel runat="server" /></td>
			<td><OrionsBelt:CampaignStatusMoves runat="server" /></td>
			<td><OrionsBelt:CampaignStatusCompleted runat="server" /></td>
			<td><OrionsBelt:CampaignStatusCreatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignStatusUpdatedDate runat="server" /></td>
			<td><OrionsBelt:CampaignStatusLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:CampaignStatusDelete runat="server" /></td>
		</tr>
		</OrionsBelt:CampaignStatusItem>
	</table>
	</OrionsBelt:CampaignLevelCampaignStatus>

	<h2>Delete CampaignLevel</h2>
	<p><OrionsBelt:CampaignLevelDelete OnDeleteRedirectTo="/admin/campaignlevelManage.aspx" runat="server" /></p>
	
</OrionsBelt:CampaignLevelEditor>
</asp:Content>