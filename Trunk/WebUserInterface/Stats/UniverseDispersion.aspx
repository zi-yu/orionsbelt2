<%@ Page Language="C#" AutoEventWireup="false" Inherits="OrionsBelt.WebUserInterface.UniverseDispersion" 
MasterPageFile="~/Stats/Stats.Master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

    <h1>Universe Dispersion</h1>
  
    <h2>Planets</h2>
    <OrionsBeltUI:Image ServerRoot="true" Src="Jobs/Stats/Planets.gif" runat="server" />

    <h2>Fleets</h2>
    <OrionsBeltUI:Image ServerRoot="true" ID="Image1" Src="Jobs/Stats/Fleets.gif" runat="server" />

    <h2>Alliances</h2>
    <OrionsBeltUI:Image ServerRoot="true" ID="Image2" Src="Jobs/Stats/Alliances.gif" runat="server" />
    
</asp:Content>