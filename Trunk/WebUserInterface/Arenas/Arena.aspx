<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Arena.aspx.cs" Inherits="OrionsBelt.WebUserInterface.ArenaPage" 
MasterPageFile="~/Arenas/Arena.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

 <div id='arenasList' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="Arenas" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBelt:ArenaStoragePagedList ItemsPerPage="50" ID="paged" runat="server" >
            <table class="newtable">
		        <tr>
		            <th><OrionsBelt:Label Key="Name" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Champion" runat="server" /></th>
		            <th><OrionsBelt:Label Key="ChampionFor" runat="server" /></th>
		            <th><OrionsBelt:Label Key="BattleType" runat="server" /></th>
		            <th><OrionsBelt:Label Key="Level" runat="server" /></th>
		            <th><OrionsBelt:Label Key="ChallengeCost" runat="server" /></th>
		            <th><OrionsBelt:Label Key="ChampionPrize" runat="server" /></th>
		            <th><OrionsBelt:Label Key="IsInBattle" runat="server" /></th>
		            <th></th>
		        </tr>
		        <OrionsBelt:ArenaStorageItem ID="AuctionHouseItem" runat="server">
		        <tr>
		            <td><OrionsBeltUI:ArenaName runat="server" /></td>
		            <td><OrionsBeltUI:ArenaLinkedPlayer runat="server" /></td>
		            <td><OrionsBeltUI:ChampionTime runat="server" /></td>
		            <td><OrionsBeltUI:ArenaType runat="server" /></td>
		            <td><OrionsBelt:ArenaStorageLevel runat="server" /></td>
		            <td><OrionsBeltUI:ArenaStoragePayment runat="server" /></td>
		            <td><OrionsBeltUI:ArenaPrize runat="server" /></td>
		            <td><OrionsBeltUI:ArenaIsInBattle runat="server" /></td>
		            <td><OrionsBeltUI:ViewArena runat="server" /></td>
		        </tr>
		        </OrionsBelt:ArenaStorageItem>
	        </table>
            </OrionsBelt:ArenaStoragePagedList>
        </div>
        <div class='bottom'></div>
    </div>
</asp:Content>