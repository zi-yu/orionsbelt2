<%@ Page Language="C#" AutoEventWireup="false" Codebehind="Market.aspx.cs" Inherits="OrionsBelt.WebUserInterface.MarketPage"
    MasterPageFile="~/OrionsbeltUniverse.Master" %>
<%@ Register TagPrefix="Market" TagName="MarketControl" Src="~/Controls/Market/MarketControl.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

<Market:MarketControl ID="search" runat="server" />

</asp:Content>
