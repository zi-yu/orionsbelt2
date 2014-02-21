<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "friendorfoe";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create FriendOrFoe</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:FriendOrFoeEditor runat="server" Source="New" ID="FriendOrFoeEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:FriendOrFoeIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsFriend</b></td>
			<td><OrionsBelt:FriendOrFoeIsFriendEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Source</b></td>
			<td><OrionsBelt:FriendOrFoeSourceEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Target</b></td>
			<td><OrionsBelt:FriendOrFoeTargetEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:FriendOrFoeCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:FriendOrFoeUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:FriendOrFoeLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:FriendOrFoeEditor>
	</table>
	</asp:Content>