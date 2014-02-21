<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Arenas
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Univers</h2><ul><li><a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a></li><li><a href='/fr/Universe/HotZone.aspx'>Zone publique</a></li><li><a href='/fr/Universe/Coordinates.aspx'>Coordonées</a></li></ul><h2>Actions dans l'univers</h2><ul><li><a href='/fr/Universe/Travel.aspx'>Voyage</a></li><li><a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a></li><li><a href='/fr/Universe/Colonize.aspx'>Coloniser</a></li><li><a href='/fr/Universe/UniverseAttack.aspx'>Attaque</a></li><li><a href='/fr/Universe/Conquer.aspx'>Conquérir</a></li><li><a href='/fr/Universe/Raids.aspx'>Pillage</a></li><li><a href='/fr/Universe/UnloadCargo.aspx'>Déposer cargainson</a></li><li><a href='/fr/Universe/DevastationAttack.aspx'>Attaque dévastation</a></li></ul><h2>Éléments de l'univers</h2><ul><li><a href='/fr/Universe/Planets.aspx'>Planètes</a></li><li><a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a></li><li><a href='/fr/Universe/Fleet.aspx'>Escadrile</a></li><li><a href='/fr/Universe/Arenas.aspx'>Arenas</a></li><li><a href='/fr/Universe/Beacon.aspx'>Satellite</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Autre</h2><ul><li><a href='/fr/Universe/Alliance.aspx'>Alliance</a></li><li><a href='/fr/Universe/Relics.aspx'>Reliques</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Arenas</h1>
	<div class="description">
	The <a href='/fr/Universe/Arenas.aspx'>Arena</a> is the place of choice for warrior players, where there is a chance to fight for glory and prestige. <p />
  There are several <a href='/fr/Universe/Arenas.aspx'>Arenas</a> along in the <a href='/fr/Universe/Default.aspx'>Univers</a>, whereas the more to the center of <a href='/fr/Universe/Default.aspx'>Univers</a> the greater is the reward for victory. <p />
  When a player find an empty <a href='/fr/Universe/Arenas.aspx'>Arena</a> he becomes automatically the champion of that <a href='/fr/Universe/Arenas.aspx'>Arena</a>, otherwise he may challenge
  the current champion, and the <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> of the battle will be a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> that is not chosen by any of the players, but will be a <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> equal
  for both players made available by the <a href='/fr/Universe/Arenas.aspx'>Arena</a> just for one battle. In case of victory the champion is uncrowned and
  a new champion is crowned for that <a href='/fr/Universe/Arenas.aspx'>Arena</a>. <p />
  But the biggest incentive is the possibility of winning <a href='/fr/Commerce/Orions.aspx'>Orions</a>. The challenger has to pay <a href='/fr/Commerce/Orions.aspx'>Orions</a> to challenge the champion, if
  the champion wins the battle, he also wins part of the <a href='/fr/Commerce/Orions.aspx'>Orions</a> paid by the challenger. The more <a href='/fr/Universe/Arenas.aspx'>Arena</a> battles a player win more points 
  he wins for the profession of <a href='/fr/GladiatorQuests.aspx'>Gladiateur</a>.
  The only question is - <i>How many <a href='/fr/Universe/Arenas.aspx'>Arenas</a> can you handle as champion?</i>
	</div>
	
</asp:Content>