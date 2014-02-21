<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bidhistorical";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search BidHistorical</h2>
	<p>Use this page to search for objects of the BidHistorical type.</p>
	<div class="searchTable">
		<OrionsBelt:BidHistoricalSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:BidHistoricalPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Value</th>
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
	</OrionsBelt:BidHistoricalPagedList>
</asp:Content>