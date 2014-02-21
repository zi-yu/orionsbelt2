<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "specialevent";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:SpecialEventEditor runat="server" Source="QueryString" ID="SpecialEventEditorId1" >
	<h2>Edit SpecialEvent </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:SpecialEventIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Cost</b></td>
			<td>
				<OrionsBelt:SpecialEventCostEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Token</b></td>
			<td>
				<OrionsBelt:SpecialEventTokenEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Resorces</b></td>
			<td>
				<OrionsBelt:SpecialEventResorcesEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BeginDate</b></td>
			<td>
				<OrionsBelt:SpecialEventBeginDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>EndDate</b></td>
			<td>
				<OrionsBelt:SpecialEventEndDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:SpecialEventCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:SpecialEventUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:SpecialEventLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete SpecialEvent</h2>
	<p><OrionsBelt:SpecialEventDelete OnDeleteRedirectTo="/admin/specialeventManage.aspx" runat="server" /></p>
	
</OrionsBelt:SpecialEventEditor>
</asp:Content>