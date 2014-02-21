<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "interaction";
		HttpContext.Current.Session["CurrentAction"] = "Manage";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<OrionsBelt:InteractionPagedList ItemsPerPage="50" runat="server" >
	<OrionsBelt:InteractionNumberPagination runat="server" />
	<table class="table">
		<tr>
			<th><OrionsBelt:InteractionIdSort InnerHtml="Id" runat="server" /></th>
			<th><OrionsBelt:InteractionSourceSort InnerHtml="Source" runat="server" /></th>
			<th><OrionsBelt:InteractionTargetSort InnerHtml="Target" runat="server" /></th>
			<th><OrionsBelt:InteractionTypeSort InnerHtml="Type" runat="server" /></th>
			<th><OrionsBelt:InteractionResponseSort InnerHtml="Response" runat="server" /></th>
			<th><OrionsBelt:InteractionResponseExtensionSort InnerHtml="ResponseExtension" runat="server" /></th>
			<th><OrionsBelt:InteractionInteractionContextSort InnerHtml="InteractionContext" runat="server" /></th>
			<th><OrionsBelt:InteractionResolvedSort InnerHtml="Resolved" runat="server" /></th>
			<th><OrionsBelt:InteractionSourceAditionalDataSort InnerHtml="SourceAditionalData" runat="server" /></th>
			<th><OrionsBelt:InteractionTargetAditionalDataSort InnerHtml="TargetAditionalData" runat="server" /></th>
			<th><OrionsBelt:InteractionSourceTypeSort InnerHtml="SourceType" runat="server" /></th>
			<th><OrionsBelt:InteractionTargetTypeSort InnerHtml="TargetType" runat="server" /></th>
			<th><OrionsBelt:InteractionCreatedDateSort InnerHtml="CreatedDate" runat="server" /></th>
			<th><OrionsBelt:InteractionUpdatedDateSort InnerHtml="UpdatedDate" runat="server" /></th>
			<th><OrionsBelt:InteractionLastActionUserIdSort InnerHtml="LastActionUserId" runat="server" /></th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<OrionsBelt:InteractionItem runat="server">
		<tr>
			<td><OrionsBelt:InteractionId runat="server" /></td>
			<td><OrionsBelt:InteractionSource runat="server" /></td>
			<td><OrionsBelt:InteractionTarget runat="server" /></td>
			<td><OrionsBelt:InteractionType runat="server" /></td>
			<td><OrionsBelt:InteractionResponse runat="server" /></td>
			<td><OrionsBelt:InteractionResponseExtension runat="server" /></td>
			<td><OrionsBelt:InteractionInteractionContext runat="server" /></td>
			<td><OrionsBelt:InteractionResolved runat="server" /></td>
			<td><OrionsBelt:InteractionSourceAditionalData runat="server" /></td>
			<td><OrionsBelt:InteractionTargetAditionalData runat="server" /></td>
			<td><OrionsBelt:InteractionSourceType runat="server" /></td>
			<td><OrionsBelt:InteractionTargetType runat="server" /></td>
			<td><OrionsBelt:InteractionCreatedDate runat="server" /></td>
			<td><OrionsBelt:InteractionUpdatedDate runat="server" /></td>
			<td><OrionsBelt:InteractionLastActionUserId runat="server" /></td>
			<td><Admin:EditLink runat="server" /></td>
			<td><OrionsBelt:InteractionDelete runat="server" /></td>
		</tr>
		</OrionsBelt:InteractionItem>
	</table>
	<OrionsBelt:InteractionNumberPagination runat="server" />
	</OrionsBelt:InteractionPagedList>

</asp:Content>