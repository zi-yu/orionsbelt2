<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "duplicatedetection";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search DuplicateDetection</h2>
	<p>Use this page to search for objects of the DuplicateDetection type.</p>
	<div class="searchTable">
		<OrionsBelt:DuplicateDetectionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:DuplicateDetectionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Cheater</th>
			<th>Duplicate</th>
			<th>FindType</th>
			<th>ExtraInfo</th>
			<th>Verified</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:DuplicateDetectionPagedList>
</asp:Content>