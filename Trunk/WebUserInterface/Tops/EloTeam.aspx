<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="EloTeam.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.EloTeam" MasterPageFile="~/Tops/Tops.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:TeamStoragePagedList OrderBy="EloRanking" OrderByParam="desc" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:TeamStorageNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="TopByEloTeam" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Score" runat="server" /></th>
		        </tr>
		        <OrionsBelt:TeamStorageItem ID="AuctionHouseItem" runat="server">
		        <tr>
		            <td><OrionsBeltUI:TeamPosition runat="server" /></td>
		            <td><OrionsBeltUI:TeamLinkedName runat="server" /></td>
		            <td><OrionsBelt:TeamStorageEloRanking runat="server" /></td>
		        </tr>
		        </OrionsBelt:TeamStorageItem>
	        </table>
	    </div>
        <div class='bottom'></div>
    </div>
    <OrionsBelt:PrincipalNumberPagination ItemsPerPage="50" ID="PrincipalNumberPagination1" runat="server" />
    </OrionsBelt:TeamStoragePagedList>
</asp:Content>