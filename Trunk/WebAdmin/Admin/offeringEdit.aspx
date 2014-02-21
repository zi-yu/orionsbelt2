<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "offering";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<OrionsBelt:OfferingEditor runat="server" Source="QueryString" ID="OfferingEditorId1" >
	<h2>Edit Offering </h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<OrionsBelt:OfferingIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>InitialValue</b></td>
			<td>
				<OrionsBelt:OfferingInitialValueEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CurrentValue</b></td>
			<td>
				<OrionsBelt:OfferingCurrentValueEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Product</b></td>
			<td>
				<OrionsBelt:OfferingProductEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Donor</b></td>
			<td>
				<OrionsBelt:OfferingDonorEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Receiver</b></td>
			<td>
				<OrionsBelt:OfferingReceiverEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Alliance</b></td>
			<td>
				<OrionsBelt:OfferingAllianceEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<OrionsBelt:OfferingCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<OrionsBelt:OfferingUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<OrionsBelt:OfferingLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Offering</h2>
	<p><OrionsBelt:OfferingDelete OnDeleteRedirectTo="/admin/offeringManage.aspx" runat="server" /></p>
	
</OrionsBelt:OfferingEditor>
</asp:Content>