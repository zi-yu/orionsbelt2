<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Quests/Quests.Master" Inherits="OrionsBelt.WebUserInterface.Quests.BountiesPage" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBeltUI:CustomBountyList runat="server" />
    <OrionsBeltUI:PirateBountyList runat="server" />
    
</asp:Content>
