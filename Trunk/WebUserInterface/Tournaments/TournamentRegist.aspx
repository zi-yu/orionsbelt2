<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TournamentRegist.aspx.cs"
    Inherits="OrionsBelt.WebUserInterface.TournamentRegist" MasterPageFile="~/OrionsBeltTournament.Master" %>
<%@ Import namespace="OrionsBelt.WebComponents"%>

<asp:Content ContentPlaceHolderID="Content" runat="server">

   
    <OrionsBeltUI:TournamentDescription ID="description" runat="server"/>
    
     <div id='tournamentRegister' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="Fleet" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBeltUI:FleetRender ID="fleetRender" runat="server" />
        </div>
        <div class='bottom'>
            <OrionsBeltUI:RegistInTournament ID="registration" runat="server"/>  
        </div>
    </div>
    
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="RegistedPlayers" runat="server" /></h2></div>
        <div class='center'>   
            <OrionsBeltUI:RegistedPlayers ID="registedPlayers" runat="server"/>
        </div>
        <div class='bottom'></div>
    </div>   
</asp:Content>
