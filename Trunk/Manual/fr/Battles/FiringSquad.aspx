<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Escouade de tir
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tactiques de Combat</h2><ul><li><a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a></li><li><a href='/fr/Battles/KamikazeMenace.aspx'>Menace Kamikaze</a></li><li><a href='/fr/Battles/DiagonalTrap.aspx'>Piège Diagonale</a></li><li><a href='/fr/Battles/EagleStrike.aspx'>Attaque de l'aigle</a></li><li><a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>L'escadrille de tir</h1>
<div class="content">
    L' <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a> est une stratégie populaire utilisée depuis longtemps sur <a href='http://www.orionsbelt.eu'>Orion's Belt</a>. Dans les vieux jours,
    il était possible de construire le <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a> très tôt dans la partie. Le <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a> est une unité <a href='/fr/Battles/Heavy.aspx'>Lourde</a> très puissante ayant une <a href='/fr/Battles/Range.aspx'>Portée</a>. Plusieurs joueurs se sont concentrés à construire seulement des croiseurs pour les positionner sur la ligne de front. Avec une <a href='/fr/Battles/Range.aspx'>Portée</a> de 6, il pouvait atteindre toutes les unités partout sur le
    <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>, et cela explique pourquoi on appel cette stratégie "escdrille de tir" <i>firing squad</i>.
    <p /><h2>Exemple de Combat</h2>
    Le <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a> peut être une tactique très difficile à contre-attaquer pour votre adversaire, mais il est aussi possible qu'il vous élimine facilement. Analysons un combat où un joueur décide d'essayer la stratégie <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a>:
  </div>

	<p><iframe class='battle' src="/Resources/Battles/FiringSquad1.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
	<div class="content">
  <p>
  Comme on peut le voir, l'adversaire ne peut résister à la puissance du <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a>. Cette tactiqe nécessite seulement un gros groupes de <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> ayant une longue portée sur votre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> pour fonctionner.
    </p>
  <h2>Les changements au jeu</h2>
  <p>
  <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a> est alors devenu une tactique obligatoire, et il a été nécessaire de changer certaines règles pour atténuer l'efficacité de cette tactique::
  <ul><li>
  Les dégats sont atténués lorsque les ennemis doivent être tirés à très longue portée. De cette façon, le <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a>
  ne fait plus autant de dégats aux défenses de l'adversaire.
    </li><li>Quleques unités <a href='/fr/Battles/Light.aspx'>Légère</a> ayant des bonus contre les unités <a href='/fr/Battles/Heavy.aspx'>Lourde</a> ont été créer.</li></ul></p>
  <h2>Comment combattre une escadrille de tir</h2>
  <p>
  Même avec les changeents au jeu, <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a> semble être une tactique idéal et imbattable. Néanmoins, un joueur peut facilement détruire une <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a>, même si cela signifie perdre une grand nombre de
  <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>.
    </p>
  <p>
  La bataille suivante illustre la stratégie pouvant être utilisé pour gagner contre un <a href='/fr/Battles/FiringSquad.aspx'>Escouade de tir</a>.
  Comme vous pouvez le voir, il faut seulement une <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> avec quelques unités <a href='/fr/Battles/Light.aspx'>Légère</a> pouvant être utilisés en tant que <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a>
  et une   petite quantité d'unités <a href='/fr/Battles/Medium.aspx'>Médium</a> pour détruire la grande quantité de <a class='crusader' href='/fr/Unit/Crusader.aspx'>Croiseur</a>.
  </p>
</div>
	
	<p><iframe class='battle' src="/Resources/Battles/FiringSquad2.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
</asp:Content>