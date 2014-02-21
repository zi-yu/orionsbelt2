<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PirateBayControl.ascx.cs" 
Inherits="OrionsBelt.WebUserInterface.Controls.PirateBayControl" %>

<h1><OrionsBelt:Label Key="PirateBay" runat="server" /></h1>
<OrionsBeltUI:ErrorBoard runat="server" />
<OrionsBeltUI:InformationBoard runat="server" />
<div class='center'>
    <asp:Button ID="findPlanet" CssClass='button' OnClick="FindPlanet" runat="server" />
    <asp:Button ID="findFleet" CssClass='button' OnClick="FindFleet" runat="server" />
</div>
<br />
<OrionsBelt:Label Key="FindPirateBayRules" runat="server" />

   