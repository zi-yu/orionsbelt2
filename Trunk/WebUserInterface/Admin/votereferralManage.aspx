<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "votereferral";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:VoteReferralPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:VoteReferralNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:VoteReferralIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:VoteReferralNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:VoteReferralShortNameSort InnerHtml="ShortName" runat="server" /></th>
			<th><OrionsBelt:VoteReferralUrlSort InnerHtml="Url" runat="server" /></th>
			<th><OrionsBelt:VoteReferralImageUrlSort InnerHtml="ImageUrl" runat="server" /></th>
			<th><OrionsBelt:VoteReferralRewardSort InnerHtml="Reward" runat="server" /></th>
			<th><OrionsBelt:VoteReferralClickCountSort InnerHtml="ClickCount" runat="server" /></th>
			<th><OrionsBelt:VoteReferralVoteOrderSort InnerHtml="VoteOrder" runat="server" /></th>
			<th><OrionsBelt:VoteReferralCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:VoteReferralUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:VoteReferralLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:VoteReferralItem runat="server">
		<tr>
			<td><OrionsBelt:VoteReferralId runat="server" /></td>
			<td><OrionsBelt:VoteReferralName runat="server" /></td>
			<td><OrionsBelt:VoteReferralShortName runat="server" /></td>
			<td><OrionsBelt:VoteReferralUrl runat="server" /></td>
			<td><OrionsBelt:VoteReferralImageUrl runat="server" /></td>
			<td><OrionsBelt:VoteReferralReward runat="server" /></td>
			<td><OrionsBelt:VoteReferralClickCount runat="server" /></td>
			<td><OrionsBelt:VoteReferralVoteOrder runat="server" /></td>
			<td><OrionsBelt:VoteReferralCreatedDate runat="server" /></td>
			<td><OrionsBelt:VoteReferralUpdatedDate runat="server" /></td>
			<td><OrionsBelt:VoteReferralLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:VoteReferralDelete runat="server" /></td>
		</tr>
		</OrionsBelt:VoteReferralItem>
	</table>
	<OrionsBelt:VoteReferralNumberPagination runat="server" />
	</OrionsBelt:VoteReferralPagedList>

</asp:Content>