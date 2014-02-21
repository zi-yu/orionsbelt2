<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "message";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:MessageEditor runat="server" Source="QueryString" ID="MessageEditorId1" >
	<h2>Edit Message </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:MessageIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Parameters</b></td>
			<td>
				<OrionsBelt:MessageParametersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Category</b></td>
			<td>
				<OrionsBelt:MessageCategoryEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SubCategory</b></td>
			<td>
				<OrionsBelt:MessageSubCategoryEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>OwnerId</b></td>
			<td>
				<OrionsBelt:MessageOwnerIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Date</b></td>
			<td>
				<OrionsBelt:MessageDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Extended</b></td>
			<td>
				<OrionsBelt:MessageExtendedEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>TickDeadline</b></td>
			<td>
				<OrionsBelt:MessageTickDeadlineEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:MessageCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:MessageUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:MessageLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Message</h2>
	<p><OrionsBelt:MessageDelete OnDeleteRedirectTo="/admin/messageManage.aspx" runat="server" /></p>
	
</OrionsBelt:MessageEditor>
</asp:Content>