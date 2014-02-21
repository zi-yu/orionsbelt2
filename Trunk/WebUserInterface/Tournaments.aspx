<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Tournaments.aspx.cs" Inherits="OrionsBelt.WebUserInterface.Tournaments"
    MasterPageFile="~/OrionsBeltTournament.Master" %>
<%@ Register TagPrefix="Tour" TagName="XL" Src="~/Controls/Tournament/XLPartyTournaments.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBeltUI:TournamentTopMenu runat="server"></OrionsBeltUI:TournamentTopMenu>
    
    <div id='soonToStartTournaments' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="RegistFase" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBeltUI:NotStartedTournamentList runat="server" >
                <table class="newtable">
                    <tr>
                        <th><OrionsBelt:Label Key="TournamentName" runat="server" /></th>
                        <th><OrionsBelt:Label Key="TournamentType" runat="server" /></th>
                        <th><OrionsBelt:Label Key="Prize" runat="server" /></th>
                        <th><OrionsBelt:Label Key="Cost" runat="server" /></th>
                        <th><OrionsBelt:Label Key="SubscriptionTime" runat="server" /></th>
                        <th><OrionsBelt:Label Key="NPlayers" runat="server" /></th>
                        <th><OrionsBelt:Label Key="MaxElo" runat="server" /></th>
                        <th><OrionsBelt:Label Key="MinElo" runat="server" /></th>
                        <th><OrionsBelt:Label Key="MakeRegist" runat="server" /></th>
                    </tr>
                    <OrionsBelt:TournamentItem runat="server">
                        <tr>
                            <td><OrionsBeltUI:TournamentNameRender runat="server" /></td>
                            <td><OrionsBeltUI:TournamentTypeRender runat="server" /></td>
                            <td><OrionsBelt:TournamentPrize runat="server" /></td>
                            <td><OrionsBelt:TournamentCostCredits runat="server" /></td>
                            <td><OrionsBeltUI:SubscriptionTimeRender runat="server" /></td>
                            <td><OrionsBeltUI:NPlayersRender runat="server" /></td>
                            <td><OrionsBeltUI:MaxEloRender runat="server" /></td>
                            <td><OrionsBeltUI:MinEloRender runat="server" /></td>
                            <td><OrionsBeltUI:MakeRegist runat="server" /></td>
                        </tr>
                    </OrionsBelt:TournamentItem>
                    <Tour:XL ID="xl" runat="server" />
                </table>    
            </OrionsBeltUI:NotStartedTournamentList>
        </div>
        <div class='bottom'></div>
    </div>

    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="LatestTournamentBattles" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBeltUI:LatestMoves ID="LatestMoves1" runat="server" />
        </div>
         <div class='bottom'></div>
    </div>

    <div id='currentTournaments' class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label Key="InTournament" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBelt:TournamentNumberPagination ID="TournamentNumberPagination2" ItemsPerPage="50" runat="server" />
        <OrionsBelt:TournamentPagedList OrderBy="UpdatedDate" OrderByParam="desc" Where="CreatedDate <> StartTime" ID="registedTournaments" ItemsPerPage="50" runat="server">
        <table class="newtable">
            <tr>
                <th><OrionsBelt:Label Key="TournamentName" runat="server" /></th>
                <th><OrionsBelt:Label Key="TournamentType" runat="server" /></th>
                <th><OrionsBelt:Label Key="Prize" runat="server" /></th>
                <th><OrionsBelt:Label Key="InitPlayers" runat="server" /></th>
                <th><OrionsBelt:Label Key="ViewTournament" runat="server" /></th>
                <th><OrionsBelt:Label Key="Status" runat="server" /></th>
            </tr>
            <OrionsBelt:TournamentItem runat="server">
                <tr>
                    <td><OrionsBeltUI:TournamentNameRender runat="server" /></td>
                    <td><OrionsBeltUI:TournamentTypeRender runat="server" /></td>
                    <td><OrionsBelt:TournamentPrize runat="server" /></td>
                    <td><OrionsBeltUI:InitPlayers runat="server" /></td>
                    <td><OrionsBeltUI:TournamentLink runat="server" /></td>
                    <td><OrionsBeltUI:TournamentStatus runat="server" /></td>
                </tr>
            </OrionsBelt:TournamentItem>
        </table>
    </OrionsBelt:TournamentPagedList>
    </div>
    <div class='bottom'><OrionsBelt:TournamentNumberPagination ID="TournamentNumberPagination1" ItemsPerPage="50" runat="server" /></div>
    </div>

    
    
    <div class="clear"></div>

</asp:Content>
