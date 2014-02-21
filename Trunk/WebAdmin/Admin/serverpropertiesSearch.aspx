<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "serverproperties";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ServerProperties</h2>
	<p>Use this page to search for objects of the ServerProperties type.</p>
	<div class="searchTable">
		<OrionsBelt:ServerPropertiesSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ServerPropertiesPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>CurrentTick</th>
			<th>LastTickDate</th>
			<th>Running</th>
			<th>MillisPerTick</th>
			<th>UseWebClock</th>
			<th>MaxPlayers</th>
			<th>VacationTicksPerWeek</th>
			<th>Name</th>
			<th>BaseUrl</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ServerPropertiesItem runat="server">
		<tr>
			<td><OrionsBelt:ServerPropertiesId runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesCurrentTick runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesLastTickDate runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesRunning runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesMillisPerTick runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesUseWebClock runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesMaxPlayers runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesVacationTicksPerWeek runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesName runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesBaseUrl runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesCreatedDate runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesUpdatedDate runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ServerPropertiesDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ServerPropertiesItem>
	</table>
	</OrionsBelt:ServerPropertiesPagedList>
</asp:Content>