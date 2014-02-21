<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bonuscard";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BonusCardPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BonusCardNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BonusCardTypeSort InnerHtml="Type" runat="server" /></th>
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
	<OrionsBelt:BonusCardNumberPagination runat="server" />
	</OrionsBelt:BonusCardPagedList>

</asp:Content>