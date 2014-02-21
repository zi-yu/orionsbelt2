<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "serverproperties";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:ServerPropertiesPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:ServerPropertiesNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:ServerPropertiesIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesCurrentTickSort InnerHtml="CurrentTick" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesLastTickDateSort InnerHtml="LastTickDate" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesRunningSort InnerHtml="Running" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesMillisPerTickSort InnerHtml="MillisPerTick" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesUseWebClockSort InnerHtml="UseWebClock" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesMaxPlayersSort InnerHtml="MaxPlayers" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesVacationTicksPerWeekSort InnerHtml="VacationTicksPerWeek" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesNameSort InnerHtml="Name" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesBaseUrlSort InnerHtml="BaseUrl" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:ServerPropertiesLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<OrionsBelt:ServerPropertiesNumberPagination runat="server" />
	</OrionsBelt:ServerPropertiesPagedList>

</asp:Content>