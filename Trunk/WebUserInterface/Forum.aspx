<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.ForumPage" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div id='forum'>
    <OrionsBeltUI:ListTopics runat="server"></OrionsBeltUI:ListTopics>
    <OrionsBeltUI:ListPrivateTopics runat="server"></OrionsBeltUI:ListPrivateTopics>
    <OrionsBeltUI:CreateTopics runat="server"></OrionsBeltUI:CreateTopics>
</div>
</asp:Content>

