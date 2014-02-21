<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "offering";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:OfferingPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:OfferingNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:OfferingIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:OfferingInitialValueSort InnerHtml="InitialValue" runat="server" /></th>
			<th><OrionsBelt:OfferingCurrentValueSort InnerHtml="CurrentValue" runat="server" /></th>
			<th><OrionsBelt:OfferingProductSort InnerHtml="Product" runat="server" /></th>
			<th><OrionsBelt:OfferingCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:OfferingUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:OfferingLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:OfferingItem runat="server">
		<tr>
			<td><OrionsBelt:OfferingId runat="server" /></td>
			<td><OrionsBelt:OfferingInitialValue runat="server" /></td>
			<td><OrionsBelt:OfferingCurrentValue runat="server" /></td>
			<td><OrionsBelt:OfferingProduct runat="server" /></td>
			<td><OrionsBelt:OfferingCreatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingUpdatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:OfferingDelete runat="server" /></td>
		</tr>
		</OrionsBelt:OfferingItem>
	</table>
	<OrionsBelt:OfferingNumberPagination runat="server" />
	</OrionsBelt:OfferingPagedList>

</asp:Content>