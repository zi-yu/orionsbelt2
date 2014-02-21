<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bidhistorical";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:BidHistoricalPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:BidHistoricalNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:BidHistoricalIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:BidHistoricalValueSort InnerHtml="Value" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:BidHistoricalItem runat="server">
		<tr>
			<td><OrionsBelt:BidHistoricalId runat="server" /></td>
			<td><OrionsBelt:BidHistoricalValue runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:BidHistoricalDelete runat="server" /></td>
		</tr>
		</OrionsBelt:BidHistoricalItem>
	</table>
	<OrionsBelt:BidHistoricalNumberPagination runat="server" />
	</OrionsBelt:BidHistoricalPagedList>

</asp:Content>