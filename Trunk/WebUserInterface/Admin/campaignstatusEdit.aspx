<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "campaignstatus";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:CampaignStatusEditor runat="server" Source="QueryString" ID="CampaignStatusEditorId1" >
	<h2>Edit CampaignStatus </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:CampaignStatusIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:CampaignStatusLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Moves</b></td>
			<td>
				<OrionsBelt:CampaignStatusMovesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Completed</b></td>
			<td>
				<OrionsBelt:CampaignStatusCompletedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Campaign</b></td>
			<td>
				<OrionsBelt:CampaignStatusCampaignEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:CampaignStatusPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Battle</b></td>
			<td>
				<OrionsBelt:CampaignStatusBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LevelTemplate</b></td>
			<td>
				<OrionsBelt:CampaignStatusLevelTemplateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:CampaignStatusCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:CampaignStatusUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:CampaignStatusLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete CampaignStatus</h2>
	<p><OrionsBelt:CampaignStatusDelete OnDeleteRedirectTo="/admin/campaignstatusManage.aspx" runat="server" /></p>
	
</OrionsBelt:CampaignStatusEditor>
</asp:Content>