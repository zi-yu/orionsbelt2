<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Hot Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universe</h2><ul><li><a href='/en/Universe/PrivateZone.aspx'>Private Zone</a></li><li><a href='/en/Universe/HotZone.aspx'>Hot Zone</a></li><li><a href='/en/Universe/Coordinates.aspx'>Coordinates</a></li></ul><h2>Universe Actions</h2><ul><li><a href='/en/Universe/Travel.aspx'>Travel</a></li><li><a href='/en/Universe/LineOfSight.aspx'>Line of Sight</a></li><li><a href='/en/Universe/Colonize.aspx'>Colonize</a></li><li><a href='/en/Universe/UniverseAttack.aspx'>Attack</a></li><li><a href='/en/Universe/Conquer.aspx'>Conquer</a></li><li><a href='/en/Universe/Raids.aspx'>Raid</a></li><li><a href='/en/Universe/UnloadCargo.aspx'>Unload Cargo</a></li><li><a href='/en/Universe/DevastationAttack.aspx'>Devastation Attack</a></li></ul><h2>Universe Elements</h2><ul><li><a href='/en/Universe/Planets.aspx'>Planets</a></li><li><a href='/en/Universe/WormHole.aspx'>WormHole</a></li><li><a href='/en/Universe/Fleet.aspx'>Fleet</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/en/Universe/Beacon.aspx'>Beacon</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Other</h2><ul><li><a href='/en/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/en/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Hot Zone</h1>
<div class="content">
    The <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> is where all the action occurs. There you'll find other players, other <a href='/en/Race/Races.aspx'>Races</a> and
    a vast <a href='/en/Universe/Default.aspx'>Universe</a> to explore. On the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> the game doesn't protect you against other players,
    you're on your own. The only protection the game provides, is that higher level players won't be
    able to attack low level players.
    <p />
    But you don't need to be alone on the universe, you should get an <a href='/en/Universe/Alliance.aspx'>Alliance</a> for protection
    and guidance. You should also choose a <a href='/en/Quests.aspx#Professions'>Profession</a> and follow its <a href='/en/Quests.aspx'>Quests</a>, because you'll grow
    faster that way.
    <p />
    Some points of interest that you may find on the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>:
    <ul><li>Other <a href='/en/Universe/Planets.aspx'>Planets</a> to colonize, that will allow you to build the <a class='extractor' href='/en/Facility/Extractor.aspx'>Extractor</a> and earn rare resources</li><li>
    <a href='/en/Universe/WormHole.aspx'>WormHole</a> - there's a vast number of wormholes on the universe, and they are very useful to decrease
    your <a href='/en/Universe/Travel.aspx'>Travel</a> time efficiently
  </li><li><a href='/en/Commerce/Markets.aspx'>Markets</a> - find markets and follow <a href='/en/Commerce/TradeRoutes.aspx'>Trade Routes</a> to be a rich <a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/Universe/Arenas.aspx'>Arenas</a> - battle on the arenas to become the supreme <a href='/en/GladiatorQuests.aspx'>Gladiator</a></li></ul><a id="levels" name="levels"></a><h2>Zone Level</h2>
    Every universe body has its own level, that depends on its zone. <a href='/en/Universe/Planets.aspx'>Planets</a>, <a href='/en/Universe/Arenas.aspx'>Arenas</a>, <a href='/en/Commerce/Markets.aspx'>Markets</a>, <a href='/en/Universe/Relics.aspx'>Relics</a>, etc.
    The more to the center you are, the greater the zone level is. The center zone is called <i>Sirius</i>.
    <p />
    These zone levels exist to provide the following flows:
    <ul><li>When a player starts the game, he has a private <a href='/en/Universe/WormHole.aspx'>WormHole</a> that connects its <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> to a
  <a href='/en/Universe/WormHole.aspx'>WormHole</a> on the outer universe. From there, he can move to the center to obtain better <a href='/en/Universe/Planets.aspx'>Planets</a></li><li>This means that players start on the outer <i>rings</i> and work their way to the center</li><li>And also that rookie players shouldn't come to face more advanced players, because the advanced
  players had already moved to better positions</li></ul>
    Levels vary from 1 to 10, being 10 the most rich/powerful. The following image is a representation of
    the <a href='http://www.orionsbelt.eu'>Orion's Belt</a> universe:
  </div>
	<img class="block" src="/Resources/Images/WormHoleMapPreview.png" />
	
</asp:Content>