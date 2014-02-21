<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
Inherits="OrionsBelt.WebUserInterface.Battles.Default" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <asp:Literal ID="noBattlesMessage" EnableViewState="false" runat="server" />
    <OrionsBeltUI:CurrentBattles ID="CurrentBattles1" runat="server" />
    
    <div class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label1" Key="LatestTournamentBattles" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBeltUI:LatestMovesUniverse runat="server" />
        </div>
        <div class='bottom'></div>
    </div>
</asp:Content>