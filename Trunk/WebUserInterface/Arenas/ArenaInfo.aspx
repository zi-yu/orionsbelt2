<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ArenaInfo.aspx.cs" Inherits="OrionsBelt.WebUserInterface.ArenaInfo"
    MasterPageFile="~/Arenas/Arena.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
 
<div id='arenabattle' class='smallBorder'>
    <div class='top'><h2><OrionsBelt:Label Key="ArenaBattle" runat="server" /> <asp:Literal ID="Literal1" runat="server" /></h2></div>
    <div class='center'>   
        <div id="battlePlace" runat="server" /></div>
       </div>
   <div class='bottom'></div>
</div>

 <div id='arenaInfo' class='normalBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label3" Key="Arena" runat="server" /> <asp:Literal ID="name" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBeltUI:ArenaFleetRender ID="fleetRender" runat="server" />        
        <div class='clear'></div>
        <OrionsBelt:ArenaStorageItem ID="ArenaStorageItem1" Source="QueryString" runat="server">    
            <dl>
                <dt><OrionsBelt:Label ID="Label4" Key="Level" runat="server" /></dt>
                <dd><OrionsBelt:ArenaStorageLevel ID="ArenaStorageLevel1" runat="server" /></dd>
                
                <OrionsBelt:RoleVisible ID="RoleVisible1" Role="admin" runat="server">
                <dt><OrionsBelt:Label ID="Label5" Key="Coordinates" runat="server" /></dt>
                <dd> <OrionsBelt:ArenaStorageCoordinate ID="ArenaStorageCoordinate1" runat="server" /></dd>
                </OrionsBelt:RoleVisible>
                
                <dt><OrionsBelt:Label Key="ChallengePayment" runat="server" /></dt>
                <dd><OrionsBelt:ArenaStoragePayment runat="server" /></dd>
                
                <dt><OrionsBelt:Label ID="Label6" Key="DiscoveredFor" runat="server" /></dt>
                <dd> <OrionsBeltUI:DiscoveredAt ID="discoveredAt" runat="server" /></dd>
                
                <dt><OrionsBelt:Label ID="Label7" Key="CurrentChampion" runat="server" /></dt>
                <dd><OrionsBelt:ArenaStorageOwner runat="server" /></dd>
                
                <dt><OrionsBelt:Label ID="Label2" Key="ChampionFor" runat="server" /></dt>
                <dd><OrionsBeltUI:ChampionFor ID="championFor" runat="server" /></dd>
                
                <dt><OrionsBelt:Label ID="Label1" Key="CurrentWinningSequence" runat="server" /></dt>
                <dd><OrionsBeltUI:CurrentWinningSequence ID="current" runat="server" /></dd>
            </dl>
    </OrionsBelt:ArenaStorageItem>
   </div>
   <div class='bottom'></div>
</div>

<div id='soonToStartTournaments' class='bigBorder'>
    <div class='top'><h2><OrionsBelt:Label ID="Label9" Key="GreatestChampions" runat="server" /></h2></div>
    <div class='center'>
        <OrionsBeltUI:ArenaStats ID="arenaStats" runat="server" />
    </div>
    <div class='bottom'></div>
</div>
    
</asp:Content>
