<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "promotion";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create Promotion</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PromotionEditor runat="server" Source="New" ID="PromotionEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PromotionIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:PromotionNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BeginDate</b></td>
			<td><OrionsBelt:PromotionBeginDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>EndDate</b></td>
			<td><OrionsBelt:PromotionEndDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RevenueType</b></td>
			<td><OrionsBelt:PromotionRevenueTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Revenue</b></td>
			<td><OrionsBelt:PromotionRevenueEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PromotionType</b></td>
			<td><OrionsBelt:PromotionPromotionTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RangeBegin</b></td>
			<td><OrionsBelt:PromotionRangeBeginEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>RangeEnd</b></td>
			<td><OrionsBelt:PromotionRangeEndEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>PromotionCode</b></td>
			<td><OrionsBelt:PromotionPromotionCodeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BonusType</b></td>
			<td><OrionsBelt:PromotionBonusTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Bonus</b></td>
			<td><OrionsBelt:PromotionBonusEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Status</b></td>
			<td><OrionsBelt:PromotionStatusEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Description</b></td>
			<td><OrionsBelt:PromotionDescriptionEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Uses</b></td>
			<td><OrionsBelt:PromotionUsesEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Owner</b></td>
			<td><OrionsBelt:PromotionOwnerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PromotionCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PromotionUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PromotionLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PromotionEditor>
	</table>
	</asp:Content>