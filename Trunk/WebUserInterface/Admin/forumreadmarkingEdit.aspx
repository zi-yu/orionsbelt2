<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "forumreadmarking";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:ForumReadMarkingEditor runat="server" Source="QueryString" ID="ForumReadMarkingEditorId1" >
	<h2>Edit ForumReadMarking </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastRead</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingLastReadEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Player</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingPlayerEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Thread</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingThreadEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:ForumReadMarkingLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete ForumReadMarking</h2>
	<p><OrionsBelt:ForumReadMarkingDelete OnDeleteRedirectTo="/admin/forumreadmarkingManage.aspx" runat="server" /></p>
	
</OrionsBelt:ForumReadMarkingEditor>
</asp:Content>