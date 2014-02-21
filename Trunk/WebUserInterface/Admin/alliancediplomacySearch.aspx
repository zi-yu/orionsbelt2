<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "alliancediplomacy";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search AllianceDiplomacy</h2>
	<p>Use this page to search for objects of the AllianceDiplomacy type.</p>
	<div class="searchTable">
		<OrionsBelt:AllianceDiplomacySearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:AllianceDiplomacyPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Level</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:AllianceDiplomacyPagedList>
</asp:Content>