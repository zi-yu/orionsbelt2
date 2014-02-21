<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "medal";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:MedalPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:MedalNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:MedalIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:MedalNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:MedalIsAutoSort InnerHtml="IsAuto" runat="server" /></th>
			<th><OrionsBelt:MedalCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:MedalUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:MedalLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:MedalItem runat="server">
		<tr>
			<td><OrionsBelt:MedalId runat="server" /></td>
			<td><OrionsBelt:MedalName runat="server" /></td>
			<td><OrionsBelt:MedalIsAuto runat="server" /></td>
			<td><OrionsBelt:MedalCreatedDate runat="server" /></td>
			<td><OrionsBelt:MedalUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MedalLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MedalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MedalItem>
	</table>
	<OrionsBelt:MedalNumberPagination runat="server" />
	</OrionsBelt:MedalPagedList>

</asp:Content>