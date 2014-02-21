<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPlayers.aspx.cs" Inherits="OrionsBelt.WebUserInterface.SearchPlayers" MasterPageFile="~/OrionsBeltUniverse.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <OrionsBeltUI:TopsMenu ID="TopsMenu1" runat="server"></OrionsBeltUI:TopsMenu>    
    <OrionsBeltUI:ChooseOpponent TitleToken="SearchPlayer" SearchPlayers="true" id="searchPlayer" runat="server"/>
    <OrionsBeltUI:GenericButton ClientClick="Site.viewPlayer();" TextToken="ViewPlayer" runat="server" ></OrionsBeltUI:GenericButton>
</asp:Content>

