<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="Institutional.WebAdmin" Namespace="Institutional.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "referral";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
<Institutional:ReferralEditor runat="server" Source="QueryString" ID="ReferralEditorId1" >
	<h2>Edit Referral &lt;<Institutional:ReferralName runat="server" />&gt;</h2>
	
		<table class="editTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		
		<tr>
			<td><b>Id</b></td>
			<td>
				<Institutional:ReferralIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Code</b></td>
			<td>
				<Institutional:ReferralCodeEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Name</b></td>
			<td>
				<Institutional:ReferralNameEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>SourceUrl</b></td>
			<td>
				<Institutional:ReferralSourceUrlEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>Filters</b></td>
			<td>
				<Institutional:ReferralFiltersEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>CreatedDate</b></td>
			<td>
				<Institutional:ReferralCreatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>UpdatedDate</b></td>
			<td>
				<Institutional:ReferralUpdatedDateEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td><b>LastActionUserId</b></td>
			<td>
				<Institutional:ReferralLastActionUserIdEditor runat="server" /> 
			</td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
	</table>

	<h2>Delete Referral</h2>
	<p><Institutional:ReferralDelete OnDeleteRedirectTo="/admin/referralManage.aspx" runat="server" /></p>
	
</Institutional:ReferralEditor>
</asp:Content>