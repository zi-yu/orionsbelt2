<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Markets.aspx.cs" Inherits="OrionsBelt.WebUserInterface.Markets" 
MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
	<h1><OrionsBelt:Label Key="Markets" runat="server" /></h1>
	<br />
	<OrionsBelt:RoleVisible Role="gameMaster" runat="server">
        <OrionsBelt:MarketPagedList ItemsPerPage="50" OrderBy="Level, Coordinates"  ID="paged" runat="server" >
        <table>
		    <tr>
		        <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		        <th><OrionsBelt:Label Key="Level" runat="server" /></th>
		        <th><OrionsBelt:Label Key="Coordinates" runat="server" /></th>
		    </tr>
		    <OrionsBelt:MarketItem ID="AuctionHouseItem" runat="server">
		    <tr>
		        <td><OrionsBelt:MarketName runat="server" /></td>
		        <td><OrionsBelt:MarketLevel runat="server" /></td>
		        <td><OrionsBelt:MarketCoordinates runat="server" /></td>
		    </tr>
		    </OrionsBelt:MarketItem>
	    </table>
        </OrionsBelt:MarketPagedList>
    ´</OrionsBelt:RoleVisible>
</asp:Content>