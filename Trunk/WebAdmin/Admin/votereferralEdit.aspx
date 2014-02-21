<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "votereferral";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:VoteReferralEditor runat="server" Source="QueryString" ID="VoteReferralEditorId1" >
	<h2>Edit VoteReferral </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:VoteReferralIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:VoteReferralNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ShortName</b></td>
			<td>
				<OrionsBelt:VoteReferralShortNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Url</b></td>
			<td>
				<OrionsBelt:VoteReferralUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ImageUrl</b></td>
			<td>
				<OrionsBelt:VoteReferralImageUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Reward</b></td>
			<td>
				<OrionsBelt:VoteReferralRewardEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ClickCount</b></td>
			<td>
				<OrionsBelt:VoteReferralClickCountEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>VoteOrder</b></td>
			<td>
				<OrionsBelt:VoteReferralVoteOrderEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:VoteReferralCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:VoteReferralUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:VoteReferralLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete VoteReferral</h2>
	<p><OrionsBelt:VoteReferralDelete OnDeleteRedirectTo="/admin/votereferralManage.aspx" runat="server" /></p>
	
</OrionsBelt:VoteReferralEditor>
</asp:Content>