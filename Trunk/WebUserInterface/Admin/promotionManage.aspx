<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "promotion";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:PromotionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:PromotionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:PromotionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:PromotionNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:PromotionBeginDateSort InnerHtml="BeginDate" runat="server" /></th>
			<th><OrionsBelt:PromotionEndDateSort InnerHtml="EndDate" runat="server" /></th>
			<th><OrionsBelt:PromotionRevenueTypeSort InnerHtml="RevenueType" runat="server" /></th>
			<th><OrionsBelt:PromotionRevenueSort InnerHtml="Revenue" runat="server" /></th>
			<th><OrionsBelt:PromotionPromotionTypeSort InnerHtml="PromotionType" runat="server" /></th>
			<th><OrionsBelt:PromotionRangeBeginSort InnerHtml="RangeBegin" runat="server" /></th>
			<th><OrionsBelt:PromotionRangeEndSort InnerHtml="RangeEnd" runat="server" /></th>
			<th><OrionsBelt:PromotionPromotionCodeSort InnerHtml="PromotionCode" runat="server" /></th>
			<th><OrionsBelt:PromotionBonusTypeSort InnerHtml="BonusType" runat="server" /></th>
			<th><OrionsBelt:PromotionBonusSort InnerHtml="Bonus" runat="server" /></th>
			<th><OrionsBelt:PromotionStatusSort InnerHtml="Status" runat="server" /></th>
			<th><OrionsBelt:PromotionDescriptionSort InnerHtml="Description" runat="server" /></th>
			<th><OrionsBelt:PromotionUsesSort InnerHtml="Uses" runat="server" /></th>
			<th><OrionsBelt:PromotionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:PromotionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:PromotionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:PromotionNumberPagination runat="server" />
	</OrionsBelt:PromotionPagedList>

</asp:Content>