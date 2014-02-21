<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "votereferral";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search VoteReferral</h2>
	<p>Use this page to search for objects of the VoteReferral type.</p>
	<div class="searchTable">
		<OrionsBelt:VoteReferralSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:VoteReferralPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>ShortName</th>
			<th>Url</th>
			<th>ImageUrl</th>
			<th>Reward</th>
			<th>ClickCount</th>
			<th>VoteOrder</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:VoteReferralPagedList>
</asp:Content>