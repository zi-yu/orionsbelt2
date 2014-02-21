<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "friendorfoe";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:FriendOrFoeEditor runat="server" Source="QueryString" ID="FriendOrFoeEditorId1" >
	<h2>Edit FriendOrFoe </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:FriendOrFoeIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsFriend</b></td>
			<td>
				<OrionsBelt:FriendOrFoeIsFriendEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Source</b></td>
			<td>
				<OrionsBelt:FriendOrFoeSourceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Target</b></td>
			<td>
				<OrionsBelt:FriendOrFoeTargetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:FriendOrFoeCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:FriendOrFoeUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:FriendOrFoeLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete FriendOrFoe</h2>
	<p><OrionsBelt:FriendOrFoeDelete OnDeleteRedirectTo="/admin/friendorfoeManage.aspx" runat="server" /></p>
	
</OrionsBelt:FriendOrFoeEditor>
</asp:Content>