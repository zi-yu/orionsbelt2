<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/adminMaster.master"  %>
<%@ Register TagPrefix="Admin" Assembly="OrionsBelt.WebAdmin" Namespace="OrionsBelt.WebAdmin.Admin.Controls" %>
<script type="text/C#" runat="server">
	protected override void OnInit( EventArgs e ) {
		HttpContext.Current.Session["CurrentEntity"] = "queststorage";
		HttpContext.Current.Session["CurrentAction"] = "Create";
	}
</script>
<asp:Content ContentPlaceHolderID="content" runat="server">
	<h2>Create QuestStorage</h2>
	
	<asp:ValidationSummary runat="server" />
	
	<table class="createTable">
		<tr>
			<th>Field</th>
			<th>Value</th>
		</tr>
		<OrionsBelt:QuestStorageEditor runat="server" Source="New" ID="QuestStorageEditorId1" >
		<!-- OneToOne -->
		<tr>
			<td><b>Id</b></td>
			<td><OrionsBelt:QuestStorageIdEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Percentage</b></td>
			<td><OrionsBelt:QuestStoragePercentageEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsTemplate</b></td>
			<td><OrionsBelt:QuestStorageIsTemplateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Name</b></td>
			<td><OrionsBelt:QuestStorageNameEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Type</b></td>
			<td><OrionsBelt:QuestStorageTypeEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>DeadlineTick</b></td>
			<td><OrionsBelt:QuestStorageDeadlineTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>StartTick</b></td>
			<td><OrionsBelt:QuestStorageStartTickEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Reward</b></td>
			<td><OrionsBelt:QuestStorageRewardEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>QuestStringConfig</b></td>
			<td><OrionsBelt:QuestStorageQuestStringConfigEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>QuestIntConfig</b></td>
			<td><OrionsBelt:QuestStorageQuestIntConfigEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>QuestIntProgress</b></td>
			<td><OrionsBelt:QuestStorageQuestIntProgressEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>QuestStringProgress</b></td>
			<td><OrionsBelt:QuestStorageQuestStringProgressEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>Completed</b></td>
			<td><OrionsBelt:QuestStorageCompletedEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>IsProgressive</b></td>
			<td><OrionsBelt:QuestStorageIsProgressiveEditor runat="server" /></td>
		</tr>
		<!-- ManyToOne -->
		<tr>
			<td><b>Player</b></td>
			<td><OrionsBelt:QuestStoragePlayerEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>CreatedDate</b></td>
			<td><OrionsBelt:QuestStorageCreatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>UpdatedDate</b></td>
			<td><OrionsBelt:QuestStorageUpdatedDateEditor runat="server" /></td>
		</tr>
		<!-- OneToOne -->
		<tr>
			<td><b>LastActionUserId</b></td>
			<td><OrionsBelt:QuestStorageLastActionUserIdEditor runat="server" /></td>
		</tr>
		<tr>
			<td></td>
			<td><Admin:AdminUpdateButton runat="server" /></td>
		</tr>
		</OrionsBelt:QuestStorageEditor>
	</table>
	</asp:Content>