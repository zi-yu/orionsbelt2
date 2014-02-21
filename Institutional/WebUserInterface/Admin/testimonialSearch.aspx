<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "testimonial";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Testimonial</h2>
	<p>Use this page to search for objects of the Testimonial type.</p>
	<div class="searchTable">
		<Institutional:TestimonialSearch runat="server" />
	</div>
	<p/>
	<Institutional:TestimonialPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Locale</th>
			<th>Content</th>
			<th>Author</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</Institutional:TestimonialPagedList>
</asp:Content>