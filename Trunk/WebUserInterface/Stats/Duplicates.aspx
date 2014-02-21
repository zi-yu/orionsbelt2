<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Duplicates.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.Duplicates" MasterPageFile="~/Stats/Stats.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">

	<OrionsBelt:DuplicateDetectionPagedList OrderBy="CreatedDate" OrderByParam="desc" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:DuplicateDetectionNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
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