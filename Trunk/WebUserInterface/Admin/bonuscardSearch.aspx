<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bonuscard";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search BonusCard</h2>
	<p>Use this page to search for objects of the BonusCard type.</p>
	<div class="searchTable">
		<OrionsBelt:BonusCardSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BonusCardPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Type</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BonusCardItem runat="server">
		<tr>
			<td><OrionsBelt:BonusCardType runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BonusCardDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BonusCardItem>
	</table>
	</OrionsBelt:BonusCardPagedList>
</asp:Content>