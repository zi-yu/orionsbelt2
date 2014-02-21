<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "activatedpromotion";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ActivatedPromotion</h2>
	<p>Use this page to search for objects of the ActivatedPromotion type.</p>
	<div class="searchTable">
		<OrionsBelt:ActivatedPromotionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ActivatedPromotionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Used</th>
			<th>Code</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:ActivatedPromotionPagedList>
</asp:Content>