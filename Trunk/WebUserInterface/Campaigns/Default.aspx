<%@ Page Language="C#" MasterPageFile="~/Campaigns/Campaign.Master" Inherits="OrionsBelt.WebUserInterface.Campaigns.Default" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBelt:CampaignList runat="server">
    
        <dl class="campaigns">
            <OrionsBelt:CampaignItem runat="server">
                <dt><OrionsBeltUI:CampaignTitle runat="server" /></dt>
                <dd><OrionsBeltUI:CampaignDescription runat="server" /></dd>
                <dd><OrionsBeltUI:CampaignPlay runat="server" /> <OrionsBeltUI:CampaignHallOfFame runat="server" /><div class="clear"></div></dd>
            </OrionsBelt:CampaignItem>
        </dl>
    
    </OrionsBelt:CampaignList>
    
</asp:Content>
