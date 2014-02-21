<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
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
		<OrionsBelt:ExceptionInfoSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:ExceptionInfoPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Message</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:ExceptionInfoItem runat="server">
		<tr>
			<td><OrionsBelt:ExceptionInfoId runat="server" /></td>
			<td><OrionsBelt:ExceptionInfoMessage runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:ExceptionInfoDelete runat="server" /></td>
		</tr>
		</OrionsBelt:ExceptionInfoItem>
	</table>
	</OrionsBelt:ExceptionInfoPagedList>
</asp:Content>