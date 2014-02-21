<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "mediaarticle";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search MediaArticle</h2>
	<p>Use this page to search for objects of the MediaArticle type.</p>
	<div class="searchTable">
		<Institutional:MediaArticleSearch runat="server" />
	</div>
	<p/>
	<Institutional:MediaArticlePagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Url</th>
			<th>Name</th>
			<th>Locale</th>
			<th>Exceprt</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:MediaArticleItem runat="server">
		<tr>
			<td><Institutional:MediaArticleId runat="server" /></td>
			<td><Institutional:MediaArticleUrl runat="server" /></td>
			<td><Institutional:MediaArticleName runat="server" /></td>
			<td><Institutional:MediaArticleLocale runat="server" /></td>
			<td><Institutional:MediaArticleExceprt runat="server" /></td>
			<td><Institutional:MediaArticleCreatedDate runat="server" /></td>
			<td><Institutional:MediaArticleUpdatedDate runat="server" /></td>
			<td><Institutional:MediaArticleLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:MediaArticleDelete runat="server" /></td>
		</tr>
		</Institutional:MediaArticleItem>
	</table>
	</Institutional:MediaArticlePagedList>
</asp:Content>