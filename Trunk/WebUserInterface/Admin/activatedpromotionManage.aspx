<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "activatedpromotion";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ActivatedPromotionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ActivatedPromotionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ActivatedPromotionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ActivatedPromotionUsedSort InnerHtml="Used" runat="server" /></th>
			<th><OrionsBelt:ActivatedPromotionCodeSort InnerHtml="Code" runat="server" /></th>
			<th><OrionsBelt:ActivatedPromotionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ActivatedPromotionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ActivatedPromotionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
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
	<OrionsBelt:ActivatedPromotionNumberPagination runat="server" />
	</OrionsBelt:ActivatedPromotionPagedList>

</asp:Content>