<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tournament.aspx.cs" Inherits="OrionsBelt.WebUserInterface.TournamentViewer" MasterPageFile="~/OrionsBeltTournament.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBelt:TournamentItem Source="QueryString" runat="server">
        <h1>
            <OrionsBelt:Label Key="TournamentName" runat="server" />: 
            <asp:Literal ID="tName" runat="server" />
        </h1>
    </OrionsBelt:TournamentItem>
    
    <div id='tournamentBorderFleet' class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="Fleet" runat="server" /></h2></div>
        <div class='bottom'>
        <OrionsBeltUI:FleetRender ID="fleetRender" runat="server" />
        </div>
    </div>
    
    <OrionsBeltUI:TournamentLinkFasesRender runat="server" />
    
    <OrionsBeltUI:GroupsRender runat="server" />
    <OrionsBeltUI:PlayoffRender runat="server" />
    
</asp:Content>