<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "exceptioninfo";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search ExceptionInfo</h2>
	<p>Use this page to search for objects of the ExceptionInfo type.</p>
	<div class="searchTable">
		<Institutional:ExceptionInfoSearch runat="server" />
	</div>
	<p/>
	<Institutional:ExceptionInfoPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Message</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:ExceptionInfoItem runat="server">
		<tr>
			<td><Institutional:ExceptionInfoId runat="server" /></td>
			<td><Institutional:ExceptionInfoMessage runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:ExceptionInfoDelete runat="server" /></td>
		</tr>
		</Institutional:ExceptionInfoItem>
	</table>
	</Institutional:ExceptionInfoPagedList>
</asp:Content>