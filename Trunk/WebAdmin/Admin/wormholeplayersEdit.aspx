<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "wormholeplayers";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:WormHolePlayersEditor runat="server" Source="QueryString" ID="WormHolePlayersEditorId1" >
	<h2>Edit WormHolePlayers </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:WormHolePlayersIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>PlayerCount</b></td>
			<td>
				<OrionsBelt:WormHolePlayersPlayerCountEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:WormHolePlayersCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:WormHolePlayersUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:WormHolePlayersLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete WormHolePlayers</h2>
	<p><OrionsBelt:WormHolePlayersDelete OnDeleteRedirectTo="/admin/wormholeplayersManage.aspx" runat="server" /></p>
	
</OrionsBelt:WormHolePlayersEditor>
</asp:Content>