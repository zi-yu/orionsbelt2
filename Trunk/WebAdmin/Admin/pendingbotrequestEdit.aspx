<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "pendingbotrequest";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PendingBotRequestEditor runat="server" Source="QueryString" ID="PendingBotRequestEditorId1" >
	<h2>Edit PendingBotRequest </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PendingBotRequestIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotName</b></td>
			<td>
				<OrionsBelt:PendingBotRequestBotNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Xml</b></td>
			<td>
				<OrionsBelt:PendingBotRequestXmlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BattleId</b></td>
			<td>
				<OrionsBelt:PendingBotRequestBattleIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>BotId</b></td>
			<td>
				<OrionsBelt:PendingBotRequestBotIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Code</b></td>
			<td>
				<OrionsBelt:PendingBotRequestCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PendingBotRequestCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PendingBotRequestUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PendingBotRequestLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete PendingBotRequest</h2>
	<p><OrionsBelt:PendingBotRequestDelete OnDeleteRedirectTo="/admin/pendingbotrequestManage.aspx" runat="server" /></p>
	
</OrionsBelt:PendingBotRequestEditor>
</asp:Content>