<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "testimonial";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<Institutional:TestimonialEditor runat="server" Source="QueryString" ID="TestimonialEditorId1" >
	<h2>Edit Testimonial </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<Institutional:TestimonialIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Locale</b></td>
			<td>
				<Institutional:TestimonialLocaleEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Content</b></td>
			<td>
				<Institutional:TestimonialContentEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Author</b></td>
			<td>
				<Institutional:TestimonialAuthorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<Institutional:TestimonialCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<Institutional:TestimonialUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<Institutional:TestimonialLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Testimonial</h2>
	<p><Institutional:TestimonialDelete OnDeleteRedirectTo="/admin/testimonialManage.aspx" runat="server" /></p>
	
</Institutional:TestimonialEditor>
</asp:Content>