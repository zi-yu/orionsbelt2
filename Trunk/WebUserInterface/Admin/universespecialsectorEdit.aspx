<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "universespecialsector";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:UniverseSpecialSectorEditor runat="server" Source="QueryString" ID="UniverseSpecialSectorEditorId1" >
	<h2>Edit UniverseSpecialSector </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemX</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorSystemXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SystemY</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorSystemYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorX</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorSectorXEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SectorY</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorSectorYEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sector</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorSectorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:UniverseSpecialSectorLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete UniverseSpecialSector</h2>
	<p><OrionsBelt:UniverseSpecialSectorDelete OnDeleteRedirectTo="/admin/universespecialsectorManage.aspx" runat="server" /></p>
	
</OrionsBelt:UniverseSpecialSectorEditor>
</asp:Content>