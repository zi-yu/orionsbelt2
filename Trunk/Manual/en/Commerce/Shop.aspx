<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Premium Services
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a></li><li><a href='/en/Commerce/AuctionHouse.aspx'>Auction House</a></li><li><a href='/en/Commerce/Shop.aspx'>Premium Services</a></li><li><a href='/en/Commerce/Markets.aspx'>Markets</a></li><li><a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Premium Services</h1>
<div class="content">
  On the <a href='/en/Commerce/Shop.aspx'>Premium Services</a> you can buy special services that will assist you or decrease the game's dificulty. You may only
  buy these services using <a href='/en/Commerce/Orions.aspx'>Orions</a>.
  <p />
    Here's the list of available services:
    <ul><li><a href='/en/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Get a 30% deduction on intrinsic costs of Facilities and Units</a></li><li><a href='/en/Commerce/Shop.aspx#BuyRareDeduction'>Get a 30% deduction on rare resource costs of Facilities and Units</a></li><li><a href='/en/Commerce/Shop.aspx#BuyQueueSpace'>Additional 3 slots on your queue space. This will be used on Facility and Unit queues.</a></li><li><a href='/en/Commerce/Shop.aspx#BuyFastSpeed'>Build everything 50% faster</a></li><li><a href='/en/Commerce/Shop.aspx#BuyFullLineOfSight'>No Fog Of War on discovered Universe</a></li><li><a href='/en/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Make all the universe discovered</a></li></ul><a name="BuyIntrinsicDeduction" id="BuyIntrinsicDeduction"></a><h2><a href='/en/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Get a 30% deduction on intrinsic costs of Facilities and Units</a></h2>
    With this service activated the <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> cost of your <a href='/en/FacilityIndex.aspx'>Facilities</a> and <a href='/en/UnitIndex.aspx'>Combat Units</a> will be 30% less. 
    This is only valid for your <a href='/en/Race/Races.aspx'>Race</a> resources, it won't affect rare resources.
    
    <ul><li>If you're <a href='/en/Race/LightHumans.aspx'>Utopians</a>, it affects <a class='energy' href='/en/Intrinsic/Energy.aspx'>Energy</a>, <a class='serium' href='/en/Intrinsic/Serium.aspx'>Serium</a> and <a class='mithril' href='/en/Intrinsic/Mithril.aspx'>Mithril</a> costs</li><li>If you're <a href='/en/Race/DarkHumans.aspx'>Renegades</a>, it affects <a class='gold' href='/en/Intrinsic/Gold.aspx'>Gold</a>, <a class='titanium' href='/en/Intrinsic/Titanium.aspx'>Titanium</a> and <a class='uranium' href='/en/Intrinsic/Uranium.aspx'>Uranium</a> costs</li><li>If you're <a href='/en/Race/Bugs.aspx'>Levyr</a>, it affects <a class='protol' href='/en/Intrinsic/Protol.aspx'>Protol</a> and <a class='elk' href='/en/Intrinsic/Elk.aspx'>Elk</a> costs</li></ul><a name="BuyRareDeduction" id="BuyRareDeduction"></a><h2><a href='/en/Commerce/Shop.aspx#BuyRareDeduction'>Get a 30% deduction on rare resource costs of Facilities and Units</a></h2>
    With this service activated the <a href='/en/IntrinsicIndex.aspx'>Intrinsic</a> cost of your <a href='/en/FacilityIndex.aspx'>Facilities</a> and <a href='/en/UnitIndex.aspx'>Combat Units</a> will be 30% less.
    Unlike the previous service, this is only valid for rare resources: <a class='astatine' href='/en/Intrinsic/Astatine.aspx'>Astatine</a>, <a class='prismal' href='/en/Intrinsic/Prismal.aspx'>Prismal</a>, <a class='radon' href='/en/Intrinsic/Radon.aspx'>Radon</a>, <a class='cryptium' href='/en/Intrinsic/Cryptium.aspx'>Cryptium</a>
    and <a class='argon' href='/en/Intrinsic/Argon.aspx'>Argon</a>.

    <a name="BuyQueueSpace" id="BuyQueueSpace"></a><h2><a href='/en/Commerce/Shop.aspx#BuyQueueSpace'>Additional 3 slots on your queue space. This will be used on Facility and Unit queues.</a></h2>
    The queue space is the amount of <a href='/en/FacilityIndex.aspx'>Facilities</a> or <a href='/en/UnitIndex.aspx'>Combat Units</a> that you are able to put on hold for
    construction at a given time. By default, your queue space only has one slot. Means that if you're already
    building something, you can put another item on queue to start as soon as the one in production ends.
    <p />
    With this service you may put more 3 items on hold.

    <a name="BuyFastSpeed" id="BuyFastSpeed"></a><h2><a href='/en/Commerce/Shop.aspx#BuyFastSpeed'>Build everything 50% faster</a></h2>
    The amount of time that a construttion takes depends on your production factor and on the item being built.
    With this service, your production factor is reduced by 50%, meaning that anything that you build, will
    take half the time to complete.

    <a name="BuyFullLineOfSight" id="BuyFullLineOfSight"></a><h2><a href='/en/Commerce/Shop.aspx#BuyFullLineOfSight'>No Fog Of War on discovered Universe</a></h2>
    You can only see other players if they are moving on your <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a>. Your <a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a> is determined
    by the <a href='/en/Universe/Planets.aspx'>Planets</a> and <a href='/en/Universe/Fleet.aspx'>Fleets</a> that you have nearby. With this service, you'll be able to have full line
    of sight on your discovered universe, we won't show any fog of war.

    <a name="BuyNoUndiscoveredUniverse" id="BuyNoUndiscoveredUniverse"></a><h2><a href='/en/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Make all the universe discovered</a></h2>
    The black squares on the <a href='/en/Universe/Default.aspx'>Universe</a> are undiscovered space. You don't know what's there, and you need
    to <a href='/en/Universe/Travel.aspx'>Travel</a> with a <a href='/en/Universe/Fleet.aspx'>Fleet</a> to that location to see what's there. With this service you'll have <b>all</b>
    the universe marked as discovered.
  </div>
	
</asp:Content>