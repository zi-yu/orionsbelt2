<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Téléporteur Unité
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Unités</h2><ul><li><a href='/fr/Unit/Eagle.aspx' class='eagle'><img src='http://resources.orionsbelt.eu/Images/Common/Units/eagle.png' alt='Aigle' /> Aigle</a></li><li><a href='/fr/Unit/Doomer.aspx' class='doomer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Anihilateur' /> Anihilateur</a></li><li><a href='/fr/Unit/Anubis.aspx' class='anubis'><img src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /> Anubis</a></li><li><a href='/fr/Unit/Spider.aspx' class='spider'><img src='http://resources.orionsbelt.eu/Images/Common/Units/spider.png' alt='Araignée' /> Araignée</a></li><li><a href='/fr/Unit/Maggot.aspx' class='maggot'><img src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Asticot' /> Asticot</a></li><li><a href='/fr/Unit/Bozer.aspx' class='bozer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /> Bozer</a></li><li><a href='/fr/Unit/Rain.aspx' class='rain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Bruine' /> Bruine</a></li><li><a href='/fr/Unit/DarkRain.aspx' class='darkrain'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Bruine Noire' /> Bruine Noire</a></li><li><a href='/fr/Unit/CaptainWolf.aspx' class='captainwolf'><img src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /> CaptainWolf</a></li><li><a href='/fr/Unit/CommanderFox.aspx' class='commanderfox'><img src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /> Commander Fox</a></li><li><a href='/fr/Unit/Crawler.aspx' class='crawler'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crawler.png' alt='Crawler' /> Crawler</a></li><li><a href='/fr/Unit/Crusader.aspx' class='crusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Croiseur' /> Croiseur</a></li><li><a href='/fr/Unit/DarkCrusader.aspx' class='darkcrusader'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Croiseur Noir' /> Croiseur Noir</a></li><li><a href='/fr/Unit/Cypher.aspx' class='cypher'><img src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /> Cypher</a></li><li><a href='/fr/Unit/Destroyer.aspx' class='destroyer'><img src='http://resources.orionsbelt.eu/Images/Common/Units/destroyer.png' alt='Destructeur' /> Destructeur</a></li><li><a href='/fr/Unit/Flag.aspx' class='flag'><img src='http://resources.orionsbelt.eu/Images/Common/Units/flag.png' alt='Drapeau' /> Drapeau</a></li><li><a href='/fr/Unit/Fenix.aspx' class='fenix'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fénix' /> Fénix</a></li><li><a href='/fr/Unit/Fist.aspx' class='fist'><img src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /> Fist</a></li><li><a href='/fr/Unit/Interceptor.aspx' class='interceptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Intercepteur' /> Intercepteur</a></li><li><a href='/fr/Unit/Jumper.aspx' class='jumper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /> Jumper</a></li><li><a href='/fr/Unit/Kahuna.aspx' class='kahuna'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kahuna.png' alt='Kahuna' /> Kahuna</a></li><li><a href='/fr/Unit/Kamikaze.aspx' class='kamikaze'><img src='http://resources.orionsbelt.eu/Images/Common/Units/kamikaze.png' alt='Kamikaze' /> Kamikaze</a></li><li><a href='/fr/Unit/Krill.aspx' class='krill'><img src='http://resources.orionsbelt.eu/Images/Common/Units/krill.png' alt='Krill' /> Krill</a></li><li><a href='/fr/Unit/BattleMoon.aspx' class='battlemoon'><img src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Lune de Combat' /> Lune de Combat</a></li><li><a href='/fr/Unit/MetallicBeard.aspx' class='metallicbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metallic Beard' /> Metallic Beard</a></li><li><a href='/fr/Unit/Myst.aspx' class='myst'><img src='http://resources.orionsbelt.eu/Images/Common/Units/myst.png' alt='Myst' /> Myst</a></li><li><a href='/fr/Unit/Nova.aspx' class='nova'><img src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /> Nova</a></li><li><a href='/fr/Unit/Egg.aspx' class='egg'><img src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Oeuf' /> Oeuf</a></li><li><a href='/fr/Unit/Seeker.aspx' class='seeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Ouvrier' /> Ouvrier</a></li><li><a href='/fr/Unit/HeavySeeker.aspx' class='heavyseeker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Ouvrier lourd' /> Ouvrier lourd</a></li><li><a href='/fr/Unit/Panther.aspx' class='panther'><img src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panthère' /> Panthère</a></li><li><a href='/fr/Unit/Driller.aspx' class='driller'><img src='http://resources.orionsbelt.eu/Images/Common/Units/driller.png' alt='Perçeur' /> Perçeur</a></li><li><a href='/fr/Unit/Stinger.aspx' class='stinger'><img src='http://resources.orionsbelt.eu/Images/Common/Units/stinger.png' alt='Piqueur' /> Piqueur</a></li><li><a href='/fr/Unit/Pretorian.aspx' class='pretorian'><img src='http://resources.orionsbelt.eu/Images/Common/Units/pretorian.png' alt='Prédateur' /> Prédateur</a></li><li><a href='/fr/Unit/HiveProtector.aspx' class='hiveprotector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveprotector.png' alt='protecteur coloniale' /> protecteur coloniale</a></li><li><a href='/fr/Unit/Raptor.aspx' class='raptor'><img src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /> Raptor</a></li><li><a href='/fr/Unit/Reaper.aspx' class='reaper'><img src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /> Reaper</a></li><li><a href='/fr/Unit/Queen.aspx' class='queen'><img src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Reine' /> Reine</a></li><li><a href='/fr/Unit/HiveKing.aspx' class='hiveking'><img src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Roi coloniale' /> Roi coloniale</a></li><li><a href='/fr/Unit/Samurai.aspx' class='samurai'><img src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /> Samurai</a></li><li><a href='/fr/Unit/Scarab.aspx' class='scarab'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scarab.png' alt='Scarabé' /> Scarabé</a></li><li><a href='/fr/Unit/Scourge.aspx' class='scourge'><img src='http://resources.orionsbelt.eu/Images/Common/Units/scourge.png' alt='Scourge' /> Scourge</a></li><li><a href='/fr/Unit/Sentry.aspx' class='sentry'><img src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /> Sentry</a></li><li><a href='/fr/Unit/SilverBeard.aspx' class='silverbeard'><img src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silver Beard' /> Silver Beard</a></li><li><a href='/fr/Unit/Taurus.aspx' class='taurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Taureau' /> Taureau</a></li><li><a href='/fr/Unit/DarkTaurus.aspx' class='darktaurus'><img src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Taureau Noir' /> Taureau Noir</a></li><li><a href='/fr/Unit/Blinker.aspx' class='blinker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Téléporteur' /> Téléporteur</a></li><li><a href='/fr/Unit/Titan.aspx' class='titan'><img src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /> Titan</a></li><li><a href='/fr/Unit/Toxic.aspx' class='toxic'><img src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxique' /> Toxique</a></li><li><a href='/fr/Unit/Vector.aspx' class='vector'><img src='http://resources.orionsbelt.eu/Images/Common/Units/vector.png' alt='Vecteur' /> Vecteur</a></li><li><a href='/fr/Unit/Worm.aspx' class='worm'><img src='http://resources.orionsbelt.eu/Images/Common/Units/worm.png' alt='Vers' /> Vers</a></li><li><a href='/fr/Unit/BlackWidow.aspx' class='blackwidow'><img src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Veuve Noire' /> Veuve Noire</a></li><li><a href='/fr/Unit/Walker.aspx' class='walker'><img src='http://resources.orionsbelt.eu/Images/Common/Units/walker.png' alt='Walker' /> Walker</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<div class='smallerContent'>

	<h1><asp:Literal Text="Téléporteur" runat="server" /></h1>

	<div class="description">
		<img src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Téléporteur' />
		This is <a href='/fr/Race/LightHumans.aspx'>Utopians</a> <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> unit. It cannot attack but it can respond to enemy attacks due to it's <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> ability.
   <p />
   It's main power its the blink (or teleport) of any unit (own by the player or but the enemy) to any of the squares in the <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a> (limited to 4 sqares of distance from 
    the <a class='blinker' href='/fr/Unit/Blinker.aspx'>Téléporteur</a>). When you use this power, the <a class='blinker' href='/fr/Unit/Blinker.aspx'>Téléporteur</a> enter a cooldown state to recharge and it stays this way durring 8 battle turns. During that period, the power cannot be used
   and the <a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a> power will not work.
	</div>
	
	<h2>Information de bataille</h2>
	
	<table class='table'>
		<tr>
			<td>Attaque</td>
			<td>1000000</td>
		</tr>
		<tr>
			<td>Défense</td>
			<td>1000000</td>
		</tr>
		<tr>
			<td>Portée</td>
			<td>4</td>
		</tr>
		<tr>
			<td>Coût de mouvement</td>
			<td>5</td>
		</tr>
		<tr>
			<td>Races</td>
			<td><a href='/fr/Race/LightHumans.aspx'>Utopians</a></td>
		</tr>
		<tr>
			<td>Catégorie</td>
			<td><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></td>
		</tr>
		<tr>
			<td>Position</td>
			<td>Air</td>
		</tr>
		<tr>
			<td>Mouvement</td>
			<td><a href='/fr/Battles/Movement.aspx#MovNone'>Aucune mobilité</a></td>
		</tr>
	</table>
	
	<h3>Habiletés spéciales</h3><table class='table'><tr><th>Type</th><th>Habiletés spéciales</th></tr><tr><td>Après les mouvements de défense</td><td><ul><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li></ul></td></tr></table>
	
	
	<h2>Information de construction</h2>
	<table class='table'><tr><th>Dépendences</th><th>Coût</th><th>Durée</th><th>Lorsque complété</th><th>Déverouiller</th></tr><tr><td><ul><li><a href='../Facility/BlinkerAssembler.aspx'>Assembleur de Téléporteur</a> Niveau 1</li></ul></td><td><ul><li>21750 <a href='../Intrinsic/Energy.aspx'>Énergie</a></li><li>22250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>25250 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>8625 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>6875 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>7250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>6125 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>2250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>Vous ne pouvez pas avoir plus d"unité ultimes que de constructions permettant de les construire</li></ul></td><td class='duration'>16 Heures 40 Minutes </td><td><ul><li>Transférer les unités vers l'escadrille de défense</li></ul></td><td><ul></ul></td></tr></table>
	
	</div>
	
</asp:Content>