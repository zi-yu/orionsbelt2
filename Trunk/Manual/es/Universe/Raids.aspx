<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Saqueo
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1><h1>Raids</h1>
<div class="content">
    A raid consists on attacking another player's <a href='/es/Universe/Planets.aspx'>Planeta</a> with the sole purpose of stealing <a href='/es/IntrinsicIndex.aspx'>Intrínseco</a>
    resources. This action is usually performed by <a href='/es/PirateQuests.aspx'>Pirata</a> players on their <a href='/es/Quests.aspx'>Misiones</a>, but can also be done
    by anyone else.
    <p />
    When you raid a planet, two things can occur:
    <ul><li>The planet's defense <a href='/es/Universe/Fleet.aspx'>Flota</a> is empty and the raid is performed</li><li>
  The planet has some defenses and a battle will be started on the <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>; only if you win
  the raid is performed
 </li></ul>
    Even if the raid is performed, you may not get any resources at all. There is a raid timeout to prevent
    abuse, so it's only possible to raid a planet every ~14 hours.
    <p />
    If the raid is successufully performed, you will get some resources stolen and your <a href='/es/PirateQuests.aspx'>Pirata</a> ranking
    increased. You will steal two types of resources. One resource picked randomly and the other ressource
    is the one that the target planet's player has the most. And that varies by <a href='/es/Race/Races.aspx'>Raza</a>:
    <ul><li>If you're targeting a <a href='/es/Race/LightHumans.aspx'>Utopianos</a> planet, you'll get <a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a></li><li>If you're targeting a <a href='/es/Race/DarkHumans.aspx'>Renegados</a> planet, you'll get <a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>If you're targeting a <a href='/es/Race/Bugs.aspx'>Levyr</a> planet, you'll get <a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a></li></ul>
    The stolen quantity is a small percentage of the target player's total amount, and higher level planets
    provide better percentages.
   </div></h1>
	
</asp:Content>