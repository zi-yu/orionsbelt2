<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zona Pública
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Hot Zone</h1>
<div class="content">
    The <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> is where all the action occurs. There you'll find other players, other <a href='/es/Race/Races.aspx'>Razas</a> and
    a vast <a href='/es/Universe/Default.aspx'>Universo</a> to explore. On the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> the game doesn't protect you against other players,
    you're on your own. The only protection the game provides, is that higher level players won't be
    able to attack low level players.
    <p />
    But you don't need to be alone on the universe, you should get an <a href='/es/Universe/Alliance.aspx'>Alianza</a> for protection
    and guidance. You should also choose a <a href='/es/Quests.aspx#Professions'>Profesión</a> and follow its <a href='/es/Quests.aspx'>Misiones</a>, because you'll grow
    faster that way.
    <p />
    Some points of interest that you may find on the <a href='/es/Universe/HotZone.aspx'>Zona Pública</a>:
    <ul><li>Other <a href='/es/Universe/Planets.aspx'>Planetas</a> to colonize, that will allow you to build the <a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a> and earn rare resources</li><li>
    <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> - there's a vast number of wormholes on the universe, and they are very useful to decrease
    your <a href='/es/Universe/Travel.aspx'>Viajar</a> time efficiently
  </li><li><a href='/es/Commerce/Markets.aspx'>Mercados</a> - find markets and follow <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> to be a rich <a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a> - battle on the arenas to become the supreme <a href='/es/GladiatorQuests.aspx'>Gladiador</a></li></ul><a id="levels" name="levels"></a><h2>Zone Level</h2>
    Every universe body has its own level, that depends on its zone. <a href='/es/Universe/Planets.aspx'>Planetas</a>, <a href='/es/Universe/Arenas.aspx'>Arenas</a>, <a href='/es/Commerce/Markets.aspx'>Mercados</a>, <a href='/es/Universe/Relics.aspx'>Relics</a>, etc.
    The more to the center you are, the greater the zone level is. The center zone is called <i>Sirius</i>.
    <p />
    These zone levels exist to provide the following flows:
    <ul><li>When a player starts the game, he has a private <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> that connects its <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> to a
  <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> on the outer universe. From there, he can move to the center to obtain better <a href='/es/Universe/Planets.aspx'>Planetas</a></li><li>This means that players start on the outer <i>rings</i> and work their way to the center</li><li>And also that rookie players shouldn't come to face more advanced players, because the advanced
  players had already moved to better positions</li></ul>
    Levels vary from 1 to 10, being 10 the most rich/powerful. The following image is a representation of
    the <a href='http://www.orionsbelt.eu'>Orion's Belt</a> universe:
  </div>
	<img class="block" src="/Resources/Images/WormHoleMapPreview.png" />
	
</asp:Content>