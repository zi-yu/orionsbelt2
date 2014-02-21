<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.DefaulStats" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <h1><OrionsBelt:Label Key="LastStats" runat="server" />:</h1>
    <br />

	<OrionsBelt:GlobalStatsPagedList ItemsPerPage="500" ID="paged" runat="server" >
	
	<ul>
	    <OrionsBelt:GlobalStatsItem ID="AuctionHouseItem1" runat="server">
	        <li><b><OrionsBeltUI:GSName runat="server" />:</b> <OrionsBelt:GlobalStatsNumber runat="server" /></li>
		</OrionsBelt:GlobalStatsItem>
	
	</ul>
	
	</OrionsBelt:GlobalStatsPagedList>



</asp:Content>