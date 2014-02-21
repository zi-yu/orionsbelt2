<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumpost";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ForumPostEditor runat="server" Source="QueryString" ID="ForumPostEditorId1" >
	<h2>Edit ForumPost </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ForumPostIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Text</b></td>
			<td>
				<OrionsBelt:ForumPostTextEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Thread</b></td>
			<td>
				<OrionsBelt:ForumPostThreadEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Owner</b></td>
			<td>
				<OrionsBelt:ForumPostOwnerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ForumPostCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ForumPostUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ForumPostLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete ForumPost</h2>
	<p><OrionsBelt:ForumPostDelete OnDeleteRedirectTo="/admin/forumpostManage.aspx" runat="server" /></p>
	
</OrionsBelt:ForumPostEditor>
</asp:Content>