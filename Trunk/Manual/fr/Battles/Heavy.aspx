﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Lourde
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Heavy Units</h1>
<div class="content">
    <a href='/fr/Battles/Heavy.aspx'>Lourde</a> units are the strongest of them all. They usualy have a huge <a href='/fr/Battles/Range.aspx'>Portée</a> and attack power. However,
    they are limited in <a href='/fr/Battles/Movement.aspx'>Mouvement</a> and <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a>.
    <p />
    Not all <a href='/fr/Battles/Heavy.aspx'>Lourde</a> units follow this pattern. For example: <a class='doomer' href='/fr/Unit/Doomer.aspx'>Anihilateur</a>, <a class='blackwidow' href='/fr/Unit/BlackWidow.aspx'>Veuve Noire</a> and <a class='taurus' href='/fr/Unit/Taurus.aspx'>Taureau</a> only have a
    <a href='/fr/Battles/Range.aspx'>Portée</a> of 3, but they are compensated with aditional <a href='/fr/Battles/Movement.aspx'>Mouvement</a> liberty, or extra powers.
    <p />
    <a href='/fr/Battles/Heavy.aspx'>Lourde</a> units should specially fear the <a class='rain' href='/fr/Unit/Rain.aspx'>Bruine</a> and the <a class='darkrain' href='/fr/Unit/DarkRain.aspx'>Bruine Noire</a>, because they both have damage bonus
    against <a href='/fr/Battles/Heavy.aspx'>Lourde</a> units.
    <p />
    <a href='/fr/Battles/Heavy.aspx'>Lourde</a> units:
  </div>
	<ul class='imageList'><li><a href='/fr/Unit/Fist.aspx'><img class='fist' src='http://resources.orionsbelt.eu/Images/Common/Units/fist.png' alt='Fist' /></a></li><li><a href='/fr/Unit/Nova.aspx'><img class='nova' src='http://resources.orionsbelt.eu/Images/Common/Units/nova.png' alt='Nova' /></a></li><li><a href='/fr/Unit/HiveKing.aspx'><img class='hiveking' src='http://resources.orionsbelt.eu/Images/Common/Units/hiveking.png' alt='Roi coloniale' /></a></li><li><a href='/fr/Unit/Bozer.aspx'><img class='bozer' src='http://resources.orionsbelt.eu/Images/Common/Units/bozer.png' alt='Bozer' /></a></li><li><a href='/fr/Unit/Doomer.aspx'><img class='doomer' src='http://resources.orionsbelt.eu/Images/Common/Units/doomer.png' alt='Anihilateur' /></a></li><li><a href='/fr/Unit/Titan.aspx'><img class='titan' src='http://resources.orionsbelt.eu/Images/Common/Units/titan.png' alt='Titan' /></a></li><li><a href='/fr/Unit/BlackWidow.aspx'><img class='blackwidow' src='http://resources.orionsbelt.eu/Images/Common/Units/blackwidow.png' alt='Veuve Noire' /></a></li><li><a href='/fr/Unit/CaptainWolf.aspx'><img class='captainwolf' src='http://resources.orionsbelt.eu/Images/Common/Units/captainwolf.png' alt='CaptainWolf' /></a></li><li><a href='/fr/Unit/Fenix.aspx'><img class='fenix' src='http://resources.orionsbelt.eu/Images/Common/Units/fenix.png' alt='Fénix' /></a></li><li><a href='/fr/Unit/Taurus.aspx'><img class='taurus' src='http://resources.orionsbelt.eu/Images/Common/Units/taurus.png' alt='Taureau' /></a></li><li><a href='/fr/Unit/CommanderFox.aspx'><img class='commanderfox' src='http://resources.orionsbelt.eu/Images/Common/Units/commanderfox.png' alt='Commander Fox' /></a></li><li><a href='/fr/Unit/HeavySeeker.aspx'><img class='heavyseeker' src='http://resources.orionsbelt.eu/Images/Common/Units/heavyseeker.png' alt='Ouvrier lourd' /></a></li><li><a href='/fr/Unit/SilverBeard.aspx'><img class='silverbeard' src='http://resources.orionsbelt.eu/Images/Common/Units/silverbeard.png' alt='Silver Beard' /></a></li><li><a href='/fr/Unit/DarkTaurus.aspx'><img class='darktaurus' src='http://resources.orionsbelt.eu/Images/Common/Units/darktaurus.png' alt='Taureau Noir' /></a></li><li><a href='/fr/Unit/DarkCrusader.aspx'><img class='darkcrusader' src='http://resources.orionsbelt.eu/Images/Common/Units/darkcrusader.png' alt='Croiseur Noir' /></a></li><li><a href='/fr/Unit/MetallicBeard.aspx'><img class='metallicbeard' src='http://resources.orionsbelt.eu/Images/Common/Units/metallicbeard.png' alt='Metallic Beard' /></a></li><li><a href='/fr/Unit/Crusader.aspx'><img class='crusader' src='http://resources.orionsbelt.eu/Images/Common/Units/crusader.png' alt='Croiseur' /></a></li></ul>
	
</asp:Content>