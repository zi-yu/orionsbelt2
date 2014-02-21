<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "privateboard";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search PrivateBoard</h2>
	<p>Use this page to search for objects of the PrivateBoard type.</p>
	<div class="searchTable">
		<OrionsBelt:PrivateBoardSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:PrivateBoardPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Receiver</th>
			<th>Type</th>
			<th>Message</th>
			<th>WasRead</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:PrivateBoardItem runat="server">
		<tr>
			<td><OrionsBelt:PrivateBoardId runat="server" /></td>
			<td><OrionsBelt:PrivateBoardReceiver runat="server" /></td>
			<td><OrionsBelt:PrivateBoardType runat="server" /></td>
			<td><OrionsBelt:PrivateBoardMessage runat="server" /></td>
			<td><OrionsBelt:PrivateBoardWasRead runat="server" /></td>
			<td><OrionsBelt:PrivateBoardCreatedDate runat="server" /></td>
			<td><OrionsBelt:PrivateBoardUpdatedDate runat="server" /></td>
			<td><OrionsBelt:PrivateBoardLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:PrivateBoardDelete runat="server" /></td>
		</tr>
		</OrionsBelt:PrivateBoardItem>
	</table>
	</OrionsBelt:PrivateBoardPagedList>
</asp:Content>