<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "mediaarticle";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Institutional:MediaArticlePagedList ItemsPerPage="50" runat="server" >
	<Institutional:MediaArticleNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><Institutional:MediaArticleIdSort InnerHtml="Id" runat="server" /></th>
			<th><Institutional:MediaArticleUrlSort InnerHtml="Url" runat="server" /></th>
			<th><Institutional:MediaArticleNameSort InnerHtml="Name" runat="server" /></th>
			<th><Institutional:MediaArticleLocaleSort InnerHtml="Locale" runat="server" /></th>
			<th><Institutional:MediaArticleExceprtSort InnerHtml="Exceprt" runat="server" /></th>
			<th><Institutional:MediaArticleCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><Institutional:MediaArticleUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><Institutional:MediaArticleLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
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
	<Institutional:MediaArticleNumberPagination runat="server" />
	</Institutional:MediaArticlePagedList>

</asp:Content>