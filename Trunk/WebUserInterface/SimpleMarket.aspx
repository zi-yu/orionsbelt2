<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="SimpleMarket.aspx.cs" Inherits="OrionsBelt.WebUserInterface.SimpleMarket" MasterPageFile="~/PopupWindow.Master" %>
<%@ Register TagPrefix="Market" TagName="MarketControl" Src="~/Controls/Market/MarketControl.ascx" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<div>
   <Market:MarketControl ID="search" runat="server" />
</div>
<OrionsBeltUI:Script id='scriptRegister' runat="server" />
</asp:Content>
