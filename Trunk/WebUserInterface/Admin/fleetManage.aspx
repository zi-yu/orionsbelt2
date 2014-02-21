<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "fleet";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:FleetPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:FleetNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:FleetIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:FleetNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:FleetUnitsSort InnerHtml="Units" runat="server" /></th>
			<th><OrionsBelt:FleetIsMovableSort InnerHtml="IsMovable" runat="server" /></th>
			<th><OrionsBelt:FleetIsInBattleSort InnerHtml="IsInBattle" runat="server" /></th>
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
	<OrionsBelt:FleetNumberPagination runat="server" />
	</OrionsBelt:FleetPagedList>

</asp:Content>