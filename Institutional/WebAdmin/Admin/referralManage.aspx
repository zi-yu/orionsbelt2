<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "referral";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Institutional:ReferralPagedList ItemsPerPage="50" runat="server" >
	<Institutional:ReferralNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><Institutional:ReferralNameSort InnerHtml="Name" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<Institutional:ReferralItem runat="server">
		<tr>
			<td><Institutional:ReferralName runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><Institutional:ReferralDelete runat="server" /></td>
		</tr>
		</Institutional:ReferralItem>
	</table>
	<Institutional:ReferralNumberPagination runat="server" />
	</Institutional:ReferralPagedList>

</asp:Content>