<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zone publique
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Hot Zone</h1>
<div class="content">
    The <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> is where all the action occurs. There you'll find other players, other <a href='/fr/Race/Races.aspx'>Races</a> and
    a vast <a href='/fr/Universe/Default.aspx'>Univers</a> to explore. On the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> the game doesn't protect you against other players,
    you're on your own. The only protection the game provides, is that higher level players won't be
    able to attack low level players.
    <p />
    But you don't need to be alone on the universe, you should get an <a href='/fr/Universe/Alliance.aspx'>Alliance</a> for protection
    and guidance. You should also choose a <a href='/fr/Quests.aspx#Professions'>Profession</a> and follow its <a href='/fr/Quests.aspx'>Quêtes</a>, because you'll grow
    faster that way.
    <p />
    Some points of interest that you may find on the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>:
    <ul><li>Other <a href='/fr/Universe/Planets.aspx'>Planètes</a> to colonize, that will allow you to build the <a class='extractor' href='/fr/Facility/Extractor.aspx'>Extracteur</a> and earn rare resources</li><li>
    <a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a> - there's a vast number of wormholes on the universe, and they are very useful to decrease
    your <a href='/fr/Universe/Travel.aspx'>Voyage</a> time efficiently
  </li><li><a href='/fr/Commerce/Markets.aspx'>Marchés</a> - find markets and follow <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> to be a rich <a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a> - battle on the arenas to become the supreme <a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li></ul><a id="levels" name="levels"></a><h2>Zone Level</h2>
    Every universe body has its own level, that depends on its zone. <a href='/fr/Universe/Planets.aspx'>Planètes</a>, <a href='/fr/Universe/Arenas.aspx'>Arenas</a>, <a href='/fr/Commerce/Markets.aspx'>Marchés</a>, <a href='/fr/Universe/Relics.aspx'>Reliques</a>, etc.
    The more to the center you are, the greater the zone level is. The center zone is called <i>Sirius</i>.
    <p />
    These zone levels exist to provide the following flows:
    <ul><li>When a player starts the game, he has a private <a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a> that connects its <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> to a
  <a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a> on the outer universe. From there, he can move to the center to obtain better <a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li>This means that players start on the outer <i>rings</i> and work their way to the center</li><li>And also that rookie players shouldn't come to face more advanced players, because the advanced
  players had already moved to better positions</li></ul>
    Levels vary from 1 to 10, being 10 the most rich/powerful. The following image is a representation of
    the <a href='http://www.orionsbelt.eu'>Orion's Belt</a> universe:
  </div>
	<img class="block" src="/Resources/Images/WormHoleMapPreview.png" />
	
</asp:Content>