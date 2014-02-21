<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "duplicatedetection";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:DuplicateDetectionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:DuplicateDetectionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:DuplicateDetectionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionCheaterSort InnerHtml="Cheater" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionDuplicateSort InnerHtml="Duplicate" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionFindTypeSort InnerHtml="FindType" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionExtraInfoSort InnerHtml="ExtraInfo" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionVerifiedSort InnerHtml="Verified" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:DuplicateDetectionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:DuplicateDetectionItem runat="server">
		<tr>
			<td><OrionsBelt:DuplicateDetectionId runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionCheater runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionDuplicate runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionFindType runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionExtraInfo runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionVerified runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionCreatedDate runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:DuplicateDetectionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:DuplicateDetectionItem>
	</table>
	<OrionsBelt:DuplicateDetectionNumberPagination runat="server" />
	</OrionsBelt:DuplicateDetectionPagedList>

</asp:Content>