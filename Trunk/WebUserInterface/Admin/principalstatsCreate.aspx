<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "principalstats";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create PrincipalStats</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:PrincipalStatsEditor runat="server" Source="New" ID="PrincipalStatsEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:PrincipalStatsIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MaxElo</b></td>
			<td><OrionsBelt:PrincipalStatsMaxEloEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MinElo</b></td>
			<td><OrionsBelt:PrincipalStatsMinEloEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>NumberPlayedBattles</b></td>
			<td><OrionsBelt:PrincipalStatsNumberPlayedBattlesEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MaxLadder</b></td>
			<td><OrionsBelt:PrincipalStatsMaxLadderEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>MinLadder</b></td>
			<td><OrionsBelt:PrincipalStatsMinLadderEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:PrincipalStatsCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:PrincipalStatsUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:PrincipalStatsLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:PrincipalStatsEditor>
	</table>
	</asp:Content>