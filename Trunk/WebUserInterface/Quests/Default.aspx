<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Quests/Quests.Master" Inherits="OrionsBelt.WebUserInterface.Quests.Default" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <OrionsBeltUI:ProfessionStatus runat="server" />
    <OrionsBeltUI:AvailableQuestList runat="server" />
    
</asp:Content>
