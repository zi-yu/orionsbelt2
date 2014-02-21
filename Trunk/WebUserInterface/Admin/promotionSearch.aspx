<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "promotion";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Promotion</h2>
	<p>Use this page to search for objects of the Promotion type.</p>
	<div class="searchTable">
		<OrionsBelt:PromotionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PromotionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>BeginDate</th>
			<th>EndDate</th>
			<th>RevenueType</th>
			<th>Revenue</th>
			<th>PromotionType</th>
			<th>RangeBegin</th>
			<th>RangeEnd</th>
			<th>PromotionCode</th>
			<th>BonusType</th>
			<th>Bonus</th>
			<th>Status</th>
			<th>Description</th>
			<th>Uses</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PromotionItem runat="server">
		<tr>
			<td><OrionsBelt:PromotionId runat="server" /></td>
			<td><OrionsBelt:PromotionName runat="server" /></td>
			<td><OrionsBelt:PromotionBeginDate runat="server" /></td>
			<td><OrionsBelt:PromotionEndDate runat="server" /></td>
			<td><OrionsBelt:PromotionRevenueType runat="server" /></td>
			<td><OrionsBelt:PromotionRevenue runat="server" /></td>
			<td><OrionsBelt:PromotionPromotionType runat="server" /></td>
			<td><OrionsBelt:PromotionRangeBegin runat="server" /></td>
			<td><OrionsBelt:PromotionRangeEnd runat="server" /></td>
			<td><OrionsBelt:PromotionPromotionCode runat="server" /></td>
			<td><OrionsBelt:PromotionBonusType runat="server" /></td>
			<td><OrionsBelt:PromotionBonus runat="server" /></td>
			<td><OrionsBelt:PromotionStatus runat="server" /></td>
			<td><OrionsBelt:PromotionDescription runat="server" /></td>
			<td><OrionsBelt:PromotionUses runat="server" /></td>
			<td><OrionsBelt:PromotionCreatedDate runat="server" /></td>
			<td><OrionsBelt:PromotionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PromotionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PromotionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PromotionItem>
	</table>
	</OrionsBelt:PromotionPagedList>
</asp:Content>