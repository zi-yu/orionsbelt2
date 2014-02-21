<%@ Page Language="C#" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "interaction";
		HttpContext.Current.Session["CurrentAction"] = "Search";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Search Interaction</h2>
	<p>Use this page to search for objects of the Interaction type.</p>
	<div class="searchTable">
		<OrionsBelt:InteractionSearch runat="server" />
	</div>
	<p/>
	<OrionsBelt:InteractionPagedList ItemsPerPage="50" runat="server" >
	<table class="table">
		<tr>
			<th>Id</th>
			<th>Source</th>
			<th>Target</th>
			<th>Type</th>
			<th>Response</th>
			<th>ResponseExtension</th>
			<th>InteractionContext</th>
			<th>Resolved</th>
			<th>SourceAditionalData</th>
			<th>TargetAditionalData</th>
			<th>SourceType</th>
			<th>TargetType</th>
			<th>CreatedDate</th>
			<th>UpdatedDate</th>
			<th>LastActionUserId</th>
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
	</OrionsBelt:InteractionPagedList>
</asp:Content>