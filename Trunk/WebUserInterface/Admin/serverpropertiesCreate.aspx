<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "serverproperties";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create ServerProperties</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:ServerPropertiesEditor runat="server" Source="New" ID="ServerPropertiesEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:ServerPropertiesIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CurrentTick</b></td>
			<td><OrionsBelt:ServerPropertiesCurrentTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastTickDate</b></td>
			<td><OrionsBelt:ServerPropertiesLastTickDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Running</b></td>
			<td><OrionsBelt:ServerPropertiesRunningEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MillisPerTick</b></td>
			<td><OrionsBelt:ServerPropertiesMillisPerTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UseWebClock</b></td>
			<td><OrionsBelt:ServerPropertiesUseWebClockEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MaxPlayers</b></td>
			<td><OrionsBelt:ServerPropertiesMaxPlayersEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>VacationTicksPerWeek</b></td>
			<td><OrionsBelt:ServerPropertiesVacationTicksPerWeekEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:ServerPropertiesNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>BaseUrl</b></td>
			<td><OrionsBelt:ServerPropertiesBaseUrlEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:ServerPropertiesCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:ServerPropertiesUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:ServerPropertiesLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:ServerPropertiesEditor>
	</table>
	</asp:Content>