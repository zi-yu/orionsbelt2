<%@ Page Language="C#" MasterPageFile="~/Campaigns/Campaign.Master" Inherits="OrionsBelt.WebUserInterface.Campaigns.Detail" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h2><asp:Literal ID="title" runat="server" /></h2>

    <OrionsBelt:CampaignLevelList ID="levelList" runat="server">
        
        <table class="table">
        
            <tr>
                <th><OrionsBelt:Label Key="Level" runat="server" /></th>
                <th><OrionsBelt:Label Key="CampaignPlayerFleet" runat="server" /></th>
                <th><OrionsBelt:Label Key="CampaignBotFleet" runat="server" /></th>
                <th><OrionsBelt:Label Key="CampaignMoves" runat="server" /></th>
                <th><OrionsBelt:Label Key="CampaignPlay" runat="server" /></th>
            </tr>
        
            <OrionsBelt:CampaignLevelItem ID="CampaignLevelItem1" runat="server">
                <tr>
                    <td><OrionsBelt:CampaignLevelLevel runat="server" /></td>
                    <td><OrionsBeltUI:CampaignLevelPlayerFleet runat="server" /></td>
                    <td><OrionsBeltUI:CampaignLevelBotFleet runat="server" /></td>
                    <td><OrionsBeltUI:CampaignLevelMoves runat="server" /></td>
                    <td><OrionsBeltUI:CampaignLevelPlay runat="server" /></td>
                </tr>
            </OrionsBelt:CampaignLevelItem>
        </table>        
    
    </OrionsBelt:CampaignLevelList>
    
</asp:Content>