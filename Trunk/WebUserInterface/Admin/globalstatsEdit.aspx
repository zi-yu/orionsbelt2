<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "globalstats";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:GlobalStatsEditor runat="server" Source="QueryString" ID="GlobalStatsEditorId1" >
	<h2>Edit GlobalStats </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:GlobalStatsIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:GlobalStatsTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Tick</b></td>
			<td>
				<OrionsBelt:GlobalStatsTickEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Text</b></td>
			<td>
				<OrionsBelt:GlobalStatsTextEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Number</b></td>
			<td>
				<OrionsBelt:GlobalStatsNumberEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:GlobalStatsCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:GlobalStatsUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:GlobalStatsLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete GlobalStats</h2>
	<p><OrionsBelt:GlobalStatsDelete OnDeleteRedirectTo="/admin/globalstatsManage.aspx" runat="server" /></p>
	
</OrionsBelt:GlobalStatsEditor>
</asp:Content>