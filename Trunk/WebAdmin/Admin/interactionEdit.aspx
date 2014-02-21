<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "interaction";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:InteractionEditor runat="server" Source="QueryString" ID="InteractionEditorId1" >
	<h2>Edit Interaction </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:InteractionIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Source</b></td>
			<td>
				<OrionsBelt:InteractionSourceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Target</b></td>
			<td>
				<OrionsBelt:InteractionTargetEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:InteractionTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Response</b></td>
			<td>
				<OrionsBelt:InteractionResponseEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>ResponseExtension</b></td>
			<td>
				<OrionsBelt:InteractionResponseExtensionEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>InteractionContext</b></td>
			<td>
				<OrionsBelt:InteractionInteractionContextEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Resolved</b></td>
			<td>
				<OrionsBelt:InteractionResolvedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SourceAditionalData</b></td>
			<td>
				<OrionsBelt:InteractionSourceAditionalDataEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TargetAditionalData</b></td>
			<td>
				<OrionsBelt:InteractionTargetAditionalDataEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SourceType</b></td>
			<td>
				<OrionsBelt:InteractionSourceTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TargetType</b></td>
			<td>
				<OrionsBelt:InteractionTargetTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:InteractionCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:InteractionUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:InteractionLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Interaction</h2>
	<p><OrionsBelt:InteractionDelete OnDeleteRedirectTo="/admin/interactionManage.aspx" runat="server" /></p>
	
</OrionsBelt:InteractionEditor>
</asp:Content>