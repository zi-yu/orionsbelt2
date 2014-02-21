<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "alliancediplomacy";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:AllianceDiplomacyEditor runat="server" Source="QueryString" ID="AllianceDiplomacyEditorId1" >
	<h2>Edit AllianceDiplomacy </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Level</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyLevelEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AllianceA</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyAllianceAEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>AllianceB</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyAllianceBEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:AllianceDiplomacyLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete AllianceDiplomacy</h2>
	<p><OrionsBelt:AllianceDiplomacyDelete OnDeleteRedirectTo="/admin/alliancediplomacyManage.aspx" runat="server" /></p>
	
</OrionsBelt:AllianceDiplomacyEditor>
</asp:Content>