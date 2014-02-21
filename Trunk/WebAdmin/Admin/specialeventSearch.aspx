<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "specialevent";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search SpecialEvent</h2>
	<p>Use this page to search for objects of the SpecialEvent type.</p>
	<div class="searchTable">
		<OrionsBelt:SpecialEventSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:SpecialEventPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Cost</th>
			<th>Token</th>
			<th>Resorces</th>
			<th>BeginDate</th>
			<th>EndDate</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:SpecialEventItem runat="server">
		<tr>
			<td><OrionsBelt:SpecialEventId runat="server" /></td>
			<td><OrionsBelt:SpecialEventCost runat="server" /></td>
			<td><OrionsBelt:SpecialEventToken runat="server" /></td>
			<td><OrionsBelt:SpecialEventResorces runat="server" /></td>
			<td><OrionsBelt:SpecialEventBeginDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventEndDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventCreatedDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventUpdatedDate runat="server" /></td>
			<td><OrionsBelt:SpecialEventLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:SpecialEventDelete runat="server" /></td>
		</tr>
		</OrionsBelt:SpecialEventItem>
	</table>
	</OrionsBelt:SpecialEventPagedList>
</asp:Content>