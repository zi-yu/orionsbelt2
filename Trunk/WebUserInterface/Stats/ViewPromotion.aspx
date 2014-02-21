<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="ViewPromotion.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.ViewPromotion" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

	<OrionsBelt:PromotionPagedList OrderBy="CreatedDate" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:PromotionNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <table class='table'>
		<tr>
		    <th><OrionsBelt:PromotionNameSort ID="sortName" runat="server" /></th>
		    <th><OrionsBelt:PromotionDescriptionSort ID="sortDescription" runat="server" /></th>
		    <th><OrionsBelt:PromotionOwnerSort ID="sortOwner" runat="server" /></th>
		    <th><OrionsBelt:PromotionBeginDateSort ID="sortBeginDate" runat="server" /></th>
		    <th><OrionsBelt:PromotionEndDateSort ID="sortEndDate" runat="server" /></th>
		    <th><OrionsBelt:PromotionRevenueTypeSort ID="sortRevenueType" runat="server" /></th>
		    <th><OrionsBelt:PromotionRevenueSort ID="sortRevenue" runat="server" /></th>
		    <th><OrionsBelt:PromotionPromotionTypeSort ID="sortPromotionType" runat="server" /></th>
		    <th><OrionsBelt:PromotionRangeBeginSort ID="sortRangeBegin" runat="server" /></th>
		    <th><OrionsBelt:PromotionRangeEndSort ID="sortRangeEnd" runat="server" /></th>
		    <th><OrionsBelt:PromotionPromotionCodeSort ID="sortPromotionCode" runat="server" /></th>
		    <th><OrionsBelt:PromotionBonusTypeSort ID="sortBonusType" runat="server" /></th>
		    <th><OrionsBelt:PromotionBonusSort ID="sortBonus" runat="server" /></th>
		    <th><OrionsBelt:PromotionStatusSort ID="sortStatus" runat="server" /></th>
		    <th><OrionsBelt:PromotionUsesSort ID="sortUses" runat="server" /></th>
		</tr>
		<OrionsBelt:PromotionItem runat="server">
		<tr>
		    <td><OrionsBeltUI:PromotionNameWithLink runat="server" /></td>
		    <td><OrionsBelt:PromotionDescription runat="server" /></td>
		    <td><OrionsBeltUI:PromotionOwnerControl ID="payer" runat="server" /></td>
		    <td><OrionsBelt:PromotionBeginDate ID="PromotionName2" runat="server" /></td>
		    <td><OrionsBelt:PromotionEndDate ID="PromotionName3" runat="server" /></td>
		    <td><OrionsBelt:PromotionRevenueType ID="PromotionName4" runat="server" /></td>
		    <td><OrionsBelt:PromotionRevenue ID="PromotionName5" runat="server" /></td>
		    <td><OrionsBelt:PromotionPromotionType ID="PromotionName6" runat="server" /></td>
		    <td><OrionsBelt:PromotionRangeBegin ID="PromotionName7" runat="server" /></td>
		    <td><OrionsBelt:PromotionRangeEnd ID="PromotionName8" runat="server" /></td>
		    <td><OrionsBelt:PromotionPromotionCode ID="PromotionName9" runat="server" /></td>
		    <td><OrionsBelt:PromotionBonusType ID="PromotionName10" runat="server" /></td>
		    <td><OrionsBelt:PromotionBonus ID="PromotionName11" runat="server" /></td>
		    <td><OrionsBelt:PromotionStatus ID="PromotionName12" runat="server" /></td>
		    <td><OrionsBelt:PromotionUses ID="PromotionStatus1" runat="server" /></td>
		</tr>
		</OrionsBelt:PromotionItem>
	</table>
    </OrionsBelt:PromotionPagedList>
</asp:Content>