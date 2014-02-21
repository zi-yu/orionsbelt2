<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Auction House
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a></li><li><a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a></li><li><a href='/en/Commerce/Shop.aspx'>Premium Services</a></li><li><a href='/en/Commerce/Markets.aspx'>Markets</a></li><li><a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Auction House</h1>
	<div class="description">
	The <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a> is the place where a player can buy or sell things to another player. The transactions are always made
  using <a href='/en/Commerce/Orions.aspx'>Orions</a> as currency to buy. <p /><h2>
    What can I sell and how do I sell it?
  </h2>
  You can sell resources and <a href='/en/UnitIndex.aspx'>Units</a>. To sell <a href='/en/UnitIndex.aspx'>Units</a> they must be in the defense <a href='/en/Universe/Fleet.aspx'>Fleet</a> of your home <a href='/en/Universe/Planets.aspx'>Planet</a>. <p />
  To sell (put into auction) is necessary to go to the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a> page and then proceed to the "Add to Auction House" page. <p />
  On this page you can see the resources/<a href='/en/UnitIndex.aspx'>Units</a> you can put into auction, the produt quantity, the minimum amount of bidding,
  the value for immediate sale, the time it will be in <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a> and if it is to advertise the product that is put up for sale.
  The fields required are the quantity and base value for bidding. <p />
  Is necessary that the player didn't change accounts for the past 3 days to put items in the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a>.<p /><h2>
    How does the sale proceeds?
  </h2>
  During the time that is chosen when the product was put in <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a>, it is possible for players bid or buy the product right away.
  For the immediate purchase the seller player gets the <a href='/en/Commerce/Orions.aspx'>Orions</a> immediately, in the case of bidding the seller receives only the <a href='/en/Commerce/Orions.aspx'>Orions</a> when
  finish the bidding. time <p />
  All sales have the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a> rate associate that can vary from 8% to 25%, the greater is the final sales value the lower is the rate.
  This means that the seller will receive the value of the sale (paid by another player) minus the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a> rate. <p />
  In case the product isn't sold, if it's a unit it returns to the defense <a href='/en/Universe/Fleet.aspx'>Fleet</a> of the home <a href='/en/Universe/Planets.aspx'>Planet</a>, if it's a resourse it goes to the
  repository of resources until the maximum limit is achieved. <p />
  There is also a page where the player can see the products he put in the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a>, and the products already sold by him/her in the <a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a>. <p /><h2>How the purchase proceeds? </h2>
  After winning a bid the player receives the product purchased in the defense <a href='/en/Universe/Fleet.aspx'>Fleet</a> of the home <a href='/en/Universe/Planets.aspx'>Planet</a>. In the case the product is a unit it appears directly
  in the <a href='/en/Universe/Fleet.aspx'>Fleet</a> and is ready to be moved to another <a href='/en/Universe/Fleet.aspx'>Fleet</a> that can navigate over the <a href='/en/Universe/Default.aspx'>Universe</a>. <p />
  In case the product is a resource or a <a href='/en/Battles/Ultimate.aspx'>Ultimate</a> it goes to the defense <a href='/en/Universe/Fleet.aspx'>Fleet</a>'s cargo on the home <a href='/en/Universe/Planets.aspx'>Planet</a>. In the case of resources they can be unload from the cargo to
  the repository of resources, in the case of a <a href='/en/Battles/Ultimate.aspx'>Ultimate</a> is created a <a href='/en/Universe/Fleet.aspx'>Fleet</a> in of home <a href='/en/Universe/Planets.aspx'>Planet</a> orbit if the player has not reached the limit of <a href='/en/Universe/Fleet.aspx'>Fleets</a>,
  otherwise the player can not unload the <a href='/en/Battles/Ultimate.aspx'>Ultimate</a>.
	</div>
	
</asp:Content>