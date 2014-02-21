<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "testimonial";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Institutional:TestimonialPagedList ItemsPerPage="50" runat="server" >
	<Institutional:TestimonialNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><Institutional:TestimonialIdSort InnerHtml="Id" runat="server" /></th>
			<th><Institutional:TestimonialLocaleSort InnerHtml="Locale" runat="server" /></th>
			<th><Institutional:TestimonialContentSort InnerHtml="Content" runat="server" /></th>
			<th><Institutional:TestimonialAuthorSort InnerHtml="Author" runat="server" /></th>
			<th><Institutional:TestimonialCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><Institutional:TestimonialUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><Institutional:TestimonialLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:TestimonialItem runat="server">
		<tr>
			<td><Institutional:TestimonialId runat="server" /></td>
			<td><Institutional:TestimonialLocale runat="server" /></td>
			<td><Institutional:TestimonialContent runat="server" /></td>
			<td><Institutional:TestimonialAuthor runat="server" /></td>
			<td><Institutional:TestimonialCreatedDate runat="server" /></td>
			<td><Institutional:TestimonialUpdatedDate runat="server" /></td>
			<td><Institutional:TestimonialLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:TestimonialDelete runat="server" /></td>
		</tr>
		</Institutional:TestimonialItem>
	</table>
	<Institutional:TestimonialNumberPagination runat="server" />
	</Institutional:TestimonialPagedList>

</asp:Content>