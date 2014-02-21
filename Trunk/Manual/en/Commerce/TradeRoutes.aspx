<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trade Routes
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a></li><li><a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a></li><li><a href='/en/Commerce/Shop.aspx'>Premium Services</a></li><li><a href='/en/Commerce/Markets.aspx'>Markets</a></li><li><a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Trade Routes</h1>
<div class="content">
    A <a href='/en/Commerce/TradeRoutes.aspx'>Trade Route</a> is the process of loading a trade good on one <a href='/en/Commerce/Markets.aspx'>Market</a> and delivering it to another <a href='/en/Commerce/Markets.aspx'>Market</a>.
    <a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a> are commonly used as objectives on <a href='/en/MerchantQuests.aspx'>Merchant</a> <a href='/en/Quests.aspx'>Quests</a>. In fact, you'll only be able to load
    trade goods at a <a href='/en/Commerce/Markets.aspx'>Market</a> if you're taking a trade quest at that moment.
    <p />
    Each <a href='/en/Commerce/Markets.aspx'>Market</a> deals with a specific trade good. For example, you may have a <a href='/en/Commerce/Markets.aspx'>Market</a> that deals with
    <a class='supplies' href='/en/Intrinsic/Supplies.aspx'>Supplies</a>. You may load up <a class='supplies' href='/en/Intrinsic/Supplies.aspx'>Supplies</a> to your <a href='/en/Universe/Fleet.aspx'>Fleet</a> on that <a href='/en/Commerce/Markets.aspx'>Market</a>, but the <a href='/en/Commerce/Markets.aspx'>Market</a> won't accept
    <a class='supplies' href='/en/Intrinsic/Supplies.aspx'>Supplies</a> as a trade route.
    <p />
    There are also some <a href='/en/Quests.aspx'>Quests</a> that require more complex <a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a>: you may have to trade on more than
    one trade good, or even do it on a deadline (example: <a href='/en/Quest/Complete10Level1TradeRoutes.aspx'>Complete 10 trade routes using Tools or Supplies in 24 hours</a>).
  </div>
	
</asp:Content>