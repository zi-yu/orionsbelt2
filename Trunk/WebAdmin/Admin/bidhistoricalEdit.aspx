<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "bidhistorical";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:BidHistoricalEditor runat="server" Source="QueryString" ID="BidHistoricalEditorId1" >
	<h2>Edit BidHistorical </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:BidHistoricalIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Value</b></td>
			<td>
				<OrionsBelt:BidHistoricalValueEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Date</b></td>
			<td>
				<OrionsBelt:BidHistoricalDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Resource</b></td>
			<td>
				<OrionsBelt:BidHistoricalResourceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>MadeBy</b></td>
			<td>
				<OrionsBelt:BidHistoricalMadeByEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:BidHistoricalCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:BidHistoricalUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:BidHistoricalLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete BidHistorical</h2>
	<p><OrionsBelt:BidHistoricalDelete OnDeleteRedirectTo="/admin/bidhistoricalManage.aspx" runat="server" /></p>
	
</OrionsBelt:BidHistoricalEditor>
</asp:Content>