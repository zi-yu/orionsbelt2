<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "battleextention";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:BattleExtentionEditor runat="server" Source="QueryString" ID="BattleExtentionEditorId1" >
	<h2>Edit BattleExtention </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:BattleExtentionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleFinalStates</b></td>
			<td>
				<OrionsBelt:BattleExtentionBattleFinalStatesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleMovements</b></td>
			<td>
				<OrionsBelt:BattleExtentionBattleMovementsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Battle</b></td>
			<td>
				<OrionsBelt:BattleExtentionBattleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:BattleExtentionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:BattleExtentionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:BattleExtentionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete BattleExtention</h2>
	<p><OrionsBelt:BattleExtentionDelete OnDeleteRedirectTo="/admin/battleextentionManage.aspx" runat="server" /></p>
	
</OrionsBelt:BattleExtentionEditor>
</asp:Content>