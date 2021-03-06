<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="UserDuplicates.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.UserDuplicates" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">
    <h1><OrionsBelt:Label Key="UserDetections" runat="server" /></h1>
	<OrionsBelt:DuplicateDetectionPagedList OrderBy="CreatedDate" OrderByParam="desc" ItemsPerPage="100" ID="paged" runat="server" >
    <table class="table">
		<tr>
		    <th><OrionsBelt:DuplicateDetectionCheaterSort ID="cheater" runat="server" /></th>
		    <th><OrionsBelt:DuplicateDetectionDuplicateSort ID="clone" runat="server" /></th>
		    <th><OrionsBelt:DuplicateDetectionFindTypeSort ID="type" runat="server" /></th>
		    <th><OrionsBelt:DuplicateDetectionExtraInfoSort ID="info" runat="server" /></th>
		    <th><OrionsBelt:DuplicateDetectionCreatedDateSort IsAscending="false" ID="date" runat="server" /></th>
		</tr>
		<OrionsBelt:DuplicateDetectionItem runat="server">
		<tr>
		    <td><OrionsBeltUI:DuplicateCheater id="customCheater" runat="server" /></td>
		    <td><OrionsBeltUI:DuplicateClone id="customClone" runat="server" /></td>
		    <td><OrionsBeltUI:DuplicateDetectionType runat="server" /></td>
		    <td><OrionsBeltUI:DuplicateInfo runat="server" /></td>
		    <td><OrionsBelt:DuplicateDetectionCreatedDate runat="server" /></td>
		</tr>
		</OrionsBelt:DuplicateDetectionItem>
	</table>
    </OrionsBelt:DuplicateDetectionPagedList>

</asp:Content>