<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fleet";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Fleet</h2>
	<p>Use this page to search for objects of the Fleet type.</p>
	<div class="searchTable">
		<OrionsBelt:FleetSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:FleetPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Units</th>
			<th>IsMovable</th>
			<th>IsInBattle</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:FleetItem runat="server">
		<tr>
			<td><OrionsBelt:FleetId runat="server" /></td>
			<td><OrionsBelt:FleetName runat="server" /></td>
			<td><OrionsBelt:FleetUnits runat="server" /></td>
			<td><OrionsBelt:FleetIsMovable runat="server" /></td>
			<td><OrionsBelt:FleetIsInBattle runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:FleetDelete runat="server" /></td>
		</tr>
		</OrionsBelt:FleetItem>
	</table>
	</OrionsBelt:FleetPagedList>
</asp:Content>