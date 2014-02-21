<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "activatedpromotion";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ActivatedPromotionEditor runat="server" Source="QueryString" ID="ActivatedPromotionEditorId1" >
	<h2>Edit ActivatedPromotion </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Used</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionUsedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Code</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Promotion</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionPromotionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ActivatedPromotionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete ActivatedPromotion</h2>
	<p><OrionsBelt:ActivatedPromotionDelete OnDeleteRedirectTo="/admin/activatedpromotionManage.aspx" runat="server" /></p>
	
</OrionsBelt:ActivatedPromotionEditor>
</asp:Content>