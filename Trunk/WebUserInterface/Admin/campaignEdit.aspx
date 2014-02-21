<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaign";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:CampaignEditor runat="server" Source="QueryString" ID="CampaignEditorId1" >
	<h2>Edit Campaign </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:CampaignIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:CampaignNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:CampaignPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:CampaignCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:CampaignUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:CampaignLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Campaign :: Participants 
		[<a href='/admin/campaignstatusCreate.aspx?CampaignStatusCampaignEditorFilter=<OrionsBelt:CampaignId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:CampaignParticipants runat="server">
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
			<th title="Delete from Campaign">Delete</th>
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
	</OrionsBelt:CampaignParticipants>
	<h2>
		Campaign :: Levels 
		[<a href='/admin/campaignlevelCreate.aspx?CampaignLevelCampaignEditorFilter=<OrionsBelt:CampaignId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:CampaignLevels runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>BotFleet</th>
			<th>PlayerFleet</th>
			<th>Level</th>
			<th>BotName</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Campaign">Delete</th>
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
	</OrionsBelt:CampaignLevels>

	<h2>Delete Campaign</h2>
	<p><OrionsBelt:CampaignDelete OnDeleteRedirectTo="/admin/campaignManage.aspx" runat="server" /></p>
	
</OrionsBelt:CampaignEditor>
</asp:Content>