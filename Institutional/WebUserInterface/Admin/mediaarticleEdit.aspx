<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "mediaarticle";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<Institutional:MediaArticleEditor runat="server" Source="QueryString" ID="MediaArticleEditorId1" >
	<h2>Edit MediaArticle </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<Institutional:MediaArticleIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Url</b></td>
			<td>
				<Institutional:MediaArticleUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<Institutional:MediaArticleNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locale</b></td>
			<td>
				<Institutional:MediaArticleLocaleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Exceprt</b></td>
			<td>
				<Institutional:MediaArticleExceprtEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<Institutional:MediaArticleCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<Institutional:MediaArticleUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<Institutional:MediaArticleLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete MediaArticle</h2>
	<p><Institutional:MediaArticleDelete OnDeleteRedirectTo="/admin/mediaarticleManage.aspx" runat="server" /></p>
	
</Institutional:MediaArticleEditor>
</asp:Content>