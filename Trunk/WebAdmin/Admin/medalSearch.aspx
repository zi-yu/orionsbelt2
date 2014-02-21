<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "medal";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Medal</h2>
	<p>Use this page to search for objects of the Medal type.</p>
	<div class="searchTable">
		<OrionsBelt:MedalSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:MedalPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Name</th>
			<th>IsAuto</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:MedalItem runat="server">
		<tr>
			<td><OrionsBelt:MedalId runat="server" /></td>
			<td><OrionsBelt:MedalName runat="server" /></td>
			<td><OrionsBelt:MedalIsAuto runat="server" /></td>
			<td><OrionsBelt:MedalCreatedDate runat="server" /></td>
			<td><OrionsBelt:MedalUpdatedDate runat="server" /></td>
			<td><OrionsBelt:MedalLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:MedalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:MedalItem>
	</table>
	</OrionsBelt:MedalPagedList>
</asp:Content>