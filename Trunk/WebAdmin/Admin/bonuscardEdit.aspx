<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bonuscard";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:BonusCardEditor runat="server" Source="QueryString" ID="BonusCardEditorId1" >
	<h2>Edit BonusCard &lt;<OrionsBelt:BonusCardType runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:BonusCardIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:BonusCardTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Code</b></td>
			<td>
				<OrionsBelt:BonusCardCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Orions</b></td>
			<td>
				<OrionsBelt:BonusCardOrionsEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Used</b></td>
			<td>
				<OrionsBelt:BonusCardUsedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UsedBy</b></td>
			<td>
				<OrionsBelt:BonusCardUsedByEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:BonusCardCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:BonusCardUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:BonusCardLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete BonusCard</h2>
	<p><OrionsBelt:BonusCardDelete OnDeleteRedirectTo="/admin/bonuscardManage.aspx" runat="server" /></p>
	
</OrionsBelt:BonusCardEditor>
</asp:Content>