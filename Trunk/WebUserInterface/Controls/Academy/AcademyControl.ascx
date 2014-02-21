<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcademyControl.ascx.cs" 
Inherits="OrionsBelt.WebUserInterface.Controls.AcademyControl" %>

<h1><OrionsBelt:Label Key="Academy" runat="server" /></h1>
<OrionsBeltUI:ErrorBoard runat="server" />
<OrionsBeltUI:InformationBoard runat="server" />
<OrionsBeltUI:ChooseOpponent SearchPlayers="true" TitleToken="Player" id="finder" runat="server"/>
<div class='center'>
    <asp:Button ID="findPlanet" CssClass='button' OnClick="FindPlanet" runat="server" />
    <asp:Button ID="findFleet" CssClass='button' OnClick="FindFleet" runat="server" />
</div>
<br />
<h2><OrionsBelt:Label Key="NearPirateFleets" runat="server" /></h2>
<OrionsBeltUI:NearPirateFleets runat="server" />
<br />
<OrionsBelt:Label Key="FindRules" runat="server" />

   