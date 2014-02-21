<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Arenas
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universo</h2><ul><li><a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a></li><li><a href='/es/Universe/HotZone.aspx'>Zona Pública</a></li><li><a href='/es/Universe/Coordinates.aspx'>Coordenadas</a></li></ul><h2>Accione en el Universo</h2><ul><li><a href='/es/Universe/Travel.aspx'>Viajar</a></li><li><a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a></li><li><a href='/es/Universe/Colonize.aspx'>Colonizar</a></li><li><a href='/es/Universe/UniverseAttack.aspx'>Ataque</a></li><li><a href='/es/Universe/Conquer.aspx'>Conquistar</a></li><li><a href='/es/Universe/Raids.aspx'>Saqueo</a></li><li><a href='/es/Universe/UnloadCargo.aspx'>Descargar Carga</a></li><li><a href='/es/Universe/DevastationAttack.aspx'>Ataque Devastación</a></li></ul><h2>Elementos del Universo</h2><ul><li><a href='/es/Universe/Planets.aspx'>Planetas</a></li><li><a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a></li><li><a href='/es/Universe/Fleet.aspx'>Flota</a></li><li><a href='/es/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/es/Universe/Beacon.aspx'>Centinela</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Otros</h2><ul><li><a href='/es/Universe/Alliance.aspx'>Alianza</a></li><li><a href='/es/Universe/Relics.aspx'>Relics</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Arenas</h1>
	<div class="description">
	The <a href='/es/Universe/Arenas.aspx'>Arena</a> is the place of choice for warrior players, where there is a chance to fight for glory and prestige. <p />
  There are several <a href='/es/Universe/Arenas.aspx'>Arenas</a> along in the <a href='/es/Universe/Default.aspx'>Universo</a>, whereas the more to the center of <a href='/es/Universe/Default.aspx'>Universo</a> the greater is the reward for victory. <p />
  When a player find an empty <a href='/es/Universe/Arenas.aspx'>Arena</a> he becomes automatically the champion of that <a href='/es/Universe/Arenas.aspx'>Arena</a>, otherwise he may challenge
  the current champion, and the <a href='/es/Universe/Fleet.aspx'>Flota</a> of the battle will be a <a href='/es/Universe/Fleet.aspx'>Flota</a> that is not chosen by any of the players, but will be a <a href='/es/Universe/Fleet.aspx'>Flota</a> equal
  for both players made available by the <a href='/es/Universe/Arenas.aspx'>Arena</a> just for one battle. In case of victory the champion is uncrowned and
  a new champion is crowned for that <a href='/es/Universe/Arenas.aspx'>Arena</a>. <p />
  But the biggest incentive is the possibility of winning <a href='/es/Commerce/Orions.aspx'>Orions</a>. The challenger has to pay <a href='/es/Commerce/Orions.aspx'>Orions</a> to challenge the champion, if
  the champion wins the battle, he also wins part of the <a href='/es/Commerce/Orions.aspx'>Orions</a> paid by the challenger. The more <a href='/es/Universe/Arenas.aspx'>Arena</a> battles a player win more points 
  he wins for the profession of <a href='/es/GladiatorQuests.aspx'>Gladiador</a>.
  The only question is - <i>How many <a href='/es/Universe/Arenas.aspx'>Arenas</a> can you handle as champion?</i>
	</div>
	
</asp:Content>