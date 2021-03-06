﻿<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "offering";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Offering</h2>
	<p>Use this page to search for objects of the Offering type.</p>
	<div class="searchTable">
		<OrionsBelt:OfferingSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:OfferingPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>InitialValue</th>
			<th>CurrentValue</th>
			<th>Product</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:OfferingItem runat="server">
		<tr>
			<td><OrionsBelt:OfferingId runat="server" /></td>
			<td><OrionsBelt:OfferingInitialValue runat="server" /></td>
			<td><OrionsBelt:OfferingCurrentValue runat="server" /></td>
			<td><OrionsBelt:OfferingProduct runat="server" /></td>
			<td><OrionsBelt:OfferingCreatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingUpdatedDate runat="server" /></td>
			<td><OrionsBelt:OfferingLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:OfferingDelete runat="server" /></td>
		</tr>
		</OrionsBelt:OfferingItem>
	</table>
	</OrionsBelt:OfferingPagedList>
</asp:Content>