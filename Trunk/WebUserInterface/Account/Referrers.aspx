<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Account/Settings.Master" Inherits="OrionsBelt.WebUserInterface.Account.ReferrerPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div id="referalText" class='bigBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label2" Key="YourReferralLink" runat="server" /></h2></div>
        <div class='center'>
            <asp:Literal ID="content" runat="server" />
        </div>
        <div class='bottom'>
            <asp:Literal ID="referalLink" runat="server" />
        </div>
    </div>
    
    
    <div id="referalBanners" class='normalBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="Banners" runat="server" /></h2></div>
        <div class='center'>
            <asp:Literal ID="referralsMessage" runat="server" />
        </div>
        <div class='bottom'></div>
    </div>
    
    
    <div id="spreadingTheWord" class='smallBorder'>
        <div class='top'><h2><OrionsBelt:Label Key="SpreadingTheWord" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBelt:Label ID="Label3" Key="MoreReferralInfo" runat="server"></OrionsBelt:Label>
        </div>
        <div class='bottom'>
            <OrionsBelt:Label Key="DontSpam" runat="server"></OrionsBelt:Label>
        </div>
    </div>
    
    <div id="recruitedPlayers" class='smallBorder'>
        <div class='top'><h2><OrionsBelt:Label ID="Label4" Key="PlayersRecruited" runat="server" /></h2></div>
        <div class='center'>
            <OrionsBelt:PrincipalPagedList ID="referrals" runat="server">
            <table class="newtable">
                <OrionsBelt:PrincipalItem ID="PlayerStorageItem1" runat="server">
                    <tr>
                        <td><OrionsBeltUI:PrincipalActivityStatus runat="server" /></td>
                        <td><OrionsBeltUI:PrincipalLink runat="server" /></td>                        
                    </tr>
                </OrionsBelt:PrincipalItem>
            </table>
        </OrionsBelt:PrincipalPagedList>    
        </div>
        <div class='bottom'></div>
    </div>
    
    <div class="clear"></div>
    
</asp:Content>
