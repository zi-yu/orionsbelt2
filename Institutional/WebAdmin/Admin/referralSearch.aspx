<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "referral";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Referral</h2>
	<p>Use this page to search for objects of the Referral type.</p>
	<div class="searchTable">
		<Institutional:ReferralSearch runat="server" />
	</div>
	<p/>
	<Institutional:ReferralPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Name</th>
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
	</Institutional:ReferralPagedList>
</asp:Content>