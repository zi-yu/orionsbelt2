<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "alliancediplomacy";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:AllianceDiplomacyPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:AllianceDiplomacyNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:AllianceDiplomacyIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:AllianceDiplomacyLevelSort InnerHtml="Level" runat="server" /></th>
			<th><OrionsBelt:AllianceDiplomacyCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:AllianceDiplomacyUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:AllianceDiplomacyLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:AllianceDiplomacyItem runat="server">
		<tr>
			<td><OrionsBelt:AllianceDiplomacyId runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyLevel runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyCreatedDate runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyUpdatedDate runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:AllianceDiplomacyDelete runat="server" /></td>
		</tr>
		</OrionsBelt:AllianceDiplomacyItem>
	</table>
	<OrionsBelt:AllianceDiplomacyNumberPagination runat="server" />
	</OrionsBelt:AllianceDiplomacyPagedList>

</asp:Content>