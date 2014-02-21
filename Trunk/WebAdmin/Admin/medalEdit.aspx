<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "medal";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:MedalEditor runat="server" Source="QueryString" ID="MedalEditorId1" >
	<h2>Edit Medal </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:MedalIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<OrionsBelt:MedalNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>IsAuto</b></td>
			<td>
				<OrionsBelt:MedalIsAutoEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Player</b></td>
			<td>
				<OrionsBelt:MedalPlayerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Principal</b></td>
			<td>
				<OrionsBelt:MedalPrincipalEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:MedalCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:MedalUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:MedalLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Medal</h2>
	<p><OrionsBelt:MedalDelete OnDeleteRedirectTo="/admin/medalManage.aspx" runat="server" /></p>
	
</OrionsBelt:MedalEditor>
</asp:Content>