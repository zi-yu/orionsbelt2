<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "privateboard";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:PrivateBoardEditor runat="server" Source="QueryString" ID="PrivateBoardEditorId1" >
	<h2>Edit PrivateBoard </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:PrivateBoardIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Receiver</b></td>
			<td>
				<OrionsBelt:PrivateBoardReceiverEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Type</b></td>
			<td>
				<OrionsBelt:PrivateBoardTypeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Message</b></td>
			<td>
				<OrionsBelt:PrivateBoardMessageEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>WasRead</b></td>
			<td>
				<OrionsBelt:PrivateBoardWasReadEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Sender</b></td>
			<td>
				<OrionsBelt:PrivateBoardSenderEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:PrivateBoardCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:PrivateBoardUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:PrivateBoardLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete PrivateBoard</h2>
	<p><OrionsBelt:PrivateBoardDelete OnDeleteRedirectTo="/admin/privateboardManage.aspx" runat="server" /></p>
	
</OrionsBelt:PrivateBoardEditor>
</asp:Content>