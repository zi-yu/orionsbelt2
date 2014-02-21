<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="History.aspx.cs" Inherits="OrionsBelt.WebUserInterface.HistoryPage" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:BattleNumberPagination ID="pagination" ItemsPerPage="20" runat="server" />
     <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="LatestTournamentBattles" runat="server" /></h2></div>
        <div class='center'>
	        <OrionsBeltUI:BattleHistory ID="history" runat="server" />
	    </div>
        <div class='bottom'></div>
    </div>
</asp:Content>