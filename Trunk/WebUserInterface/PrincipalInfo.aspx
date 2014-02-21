<%@ Page Language="C#" AutoEventWireup="false" Codebehind="PrincipalInfo.aspx.cs" Inherits="OrionsBelt.WebUserInterface.PrincipalInfo"
    MasterPageFile="~/Profile/PrincipalProfile.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBelt:PrincipalItem Source="Items" runat="server">
    
    <div id='account' class='normalBorder'>
        <div class='top'><h1><OrionsBelt:Label ID="Label8" Key="PrincipalInfo" runat="server" /></h1></div>
        <div class='center'>
            <div class='accountAvatar'><OrionsBeltUI:PrincipalAvatar runat="server" /></div>
            <div class='accountInformation'>
            <dl>
                <dt><OrionsBelt:Label ID="Label1" Key="Name" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalName ID="PrincipalName1" runat="server" /></dd>
            
                <dt><OrionsBelt:Label Key="Team" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalLinkedTeam  runat="server" /></dd>
            
                <dt><OrionsBelt:Label ID="Label6" Key="WebSite" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalWebSite  runat="server" /></dd>
                        
                <dt><OrionsBelt:Label ID="Label7" Key="PlayersRecruited" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalPlayersRecruited ID="PrincipalWebSite1"  runat="server" /></dd>
            
                <dt><OrionsBelt:Label ID="Label2" Key="EloRanking" runat="server" /></dt>
                <dd><OrionsBelt:PrincipalELORanking ID="PrincipalName2" runat="server" /></dd>
            
                <dt><OrionsBelt:Label ID="Label3" Key="Age" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalAge ID="PrincipalELORanking1" runat="server" /></dd>
            
                <dt><OrionsBelt:Label ID="Label4" Key="LastLogin" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalLastActivity ID="PlayerStorageAge2" runat="server" /></dd>
            
                <dt><OrionsBelt:Label Key="Vacations" runat="server" /></dt>
                <dd><OrionsBeltUI:PrincipalVacations ID="PrincipalLastActivity1" runat="server" /></dd>
                
                <OrionsBelt:RoleVisible Role="admin" runat="server">
                <dt>Mail</dt>
                <dd>
                    <OrionsBelt:PrincipalEmail runat="server" />
                </dd>
                </OrionsBelt:RoleVisible>
            </dl>
            <div>
                <asp:Button ID="impersonate" CssClass="button" runat="server" /> <asp:Button ID="unblock" CssClass="button" runat="server" />
            </div>
            </div>
        </div>    
        <div class='bottom'>
            <h2><OrionsBelt:Label ID="Label5" Key="Players" runat="server" /></h2>
            <ul class='accountPlayers'>
                <OrionsBelt:PrincipalPlayer runat="server">
                    <OrionsBelt:PlayerStorageItem runat="server">
                        <li><OrionsBeltUI:PlayerStorageLink runat="server" /></li>
                    </OrionsBelt:PlayerStorageItem>
                </OrionsBelt:PrincipalPlayer>
            </ul>
        </div>
    </div>
    <OrionsBeltUI:PlayerInfoReader ID="reader" InfoToShow="Principal" Title="EloRanking" runat="server" />
    
    <div class="clear"></div>
    
    <OrionsBeltUI:PrincipalMedals ID="PrincipalMedals1" runat="server" />
    <OrionsBeltUI:PrincipalELOStats runat="server" />
    <OrionsBeltUI:PrincipalHistorical runat="server" />

    </OrionsBelt:PrincipalItem>

</asp:Content>
