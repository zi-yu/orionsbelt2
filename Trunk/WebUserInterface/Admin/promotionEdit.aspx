<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "promotion";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PromotionEditor runat="server" Source="QueryString" ID="PromotionEditorId1" >
	<h2>Edit Promotion </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PromotionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:PromotionNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BeginDate</b></td>
			<td>
				<OrionsBelt:PromotionBeginDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EndDate</b></td>
			<td>
				<OrionsBelt:PromotionEndDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RevenueType</b></td>
			<td>
				<OrionsBelt:PromotionRevenueTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Revenue</b></td>
			<td>
				<OrionsBelt:PromotionRevenueEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PromotionType</b></td>
			<td>
				<OrionsBelt:PromotionPromotionTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RangeBegin</b></td>
			<td>
				<OrionsBelt:PromotionRangeBeginEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>RangeEnd</b></td>
			<td>
				<OrionsBelt:PromotionRangeEndEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PromotionCode</b></td>
			<td>
				<OrionsBelt:PromotionPromotionCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BonusType</b></td>
			<td>
				<OrionsBelt:PromotionBonusTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Bonus</b></td>
			<td>
				<OrionsBelt:PromotionBonusEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Status</b></td>
			<td>
				<OrionsBelt:PromotionStatusEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Description</b></td>
			<td>
				<OrionsBelt:PromotionDescriptionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Uses</b></td>
			<td>
				<OrionsBelt:PromotionUsesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:PromotionOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PromotionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PromotionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PromotionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>
	<h2>
		Promotion :: Activations 
		[<a href='/admin/activatedpromotionCreate.aspx?ActivatedPromotionPromotionEditorFilter=<OrionsBelt:PromotionId runat="server" />'>Add</a>]
	</h2>
	<OrionsBelt:PromotionActivations runat="server">
		<table class="editTable">
		<tr>
			<th>Id</th>
			<th>Used</th>
			<th>Code</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th title="Delete from Promotion">Delete</th>
		</tr>
		<OrionsBelt:ActivatedPromotionItem runat="server">
		<tr>
			<td><OrionsBelt:ActivatedPromotionId runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionUsed runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionCode runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionCreatedDate runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ActivatedPromotionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ActivatedPromotionItem>
	</table>
	</OrionsBelt:PromotionActivations>

	<h2>Delete Promotion</h2>
	<p><OrionsBelt:PromotionDelete OnDeleteRedirectTo="/admin/promotionManage.aspx" runat="server" /></p>
	
</OrionsBelt:PromotionEditor>
</asp:Content>