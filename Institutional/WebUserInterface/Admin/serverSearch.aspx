<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "server";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Server</h2>
	<p>Use this page to search for objects of the Server type.</p>
	<div class="searchTable">
		<Institutional:ServerSearch runat="server" />
	</div>
	<p/>
	<Institutional:ServerPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>Url</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:ServerItem runat="server">
		<tr>
			<td><Institutional:ServerId runat="server" /></td>
			<td><Institutional:ServerName runat="server" /></td>
			<td><Institutional:ServerUrl runat="server" /></td>
			<td><Institutional:ServerCreatedDate runat="server" /></td>
			<td><Institutional:ServerUpdatedDate runat="server" /></td>
			<td><Institutional:ServerLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:ServerDelete runat="server" /></td>
		</tr>
		</Institutional:ServerItem>
	</table>
	</Institutional:ServerPagedList>
</asp:Content>