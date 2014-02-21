<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Elo.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.EloTable" MasterPageFile="~/Tops/Tops.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:PrincipalPagedList OrderBy="EloRanking" Where="EloRanking <> 1000" OrderByParam="desc" ItemsPerPage="50" ID="paged" runat="server" >
    <OrionsBelt:PrincipalNumberPagination ItemsPerPage="50" ID="pagination" runat="server" />
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="TopByElo" runat="server" /></h2></div>
        <div class='center'>
            <table class='newtable'>
		        <tr>
		            <th><OrionsBelt:Label Key="Position" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		            <th><OrionsBelt:Label Key="WinsDefeats" runat="server" /></th>
		            <th><OrionsBelt:Label Key="EloRanking" runat="server" /></th>
		        </tr>
		        <OrionsBelt:PrincipalItem ID="AuctionHouseItem" runat="server">
		        <tr>
		            <td><OrionsBeltUI:Position runat="server" /></td>
		            <td><OrionsBeltUI:PrincipalLinkAndAvatar runat="server" /></td>
		            <td><OrionsBeltUI:ELOWinsDefeats runat="server" /></td>
		            <td><OrionsBelt:PrincipalEloRanking runat="server" /></td>
		        </tr>
		        </OrionsBelt:PrincipalItem>
	        </table>
	    </div>
        <div class='bottom'></div>
    </div>
    <OrionsBelt:PrincipalNumberPagination ItemsPerPage="50" ID="PrincipalNumberPagination1" runat="server" />
    </OrionsBelt:PrincipalPagedList>
</asp:Content>