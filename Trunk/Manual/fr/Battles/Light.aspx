<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Légère
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Concepts de Bataille</h2><ul><li><a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a></li><li><a href='/fr/Battles/Deploy.aspx'>Déploiement</a></li><li><a href='/fr/Battles/Movement.aspx'>Mouvement</a></li><li><a href='/fr/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attaque</h2><ul><li><a href='/fr/Battles/Range.aspx'>Portée</a></li><li><a href='/fr/Battles/Catapult.aspx'>Catapulte</a></li><li><a href='/fr/Battles/ParalyseAttack.aspx'>Attaque paralysante</a></li><li><a href='/fr/Battles/Replicator.aspx'>Réplicateur</a></li><li><a href='/fr/Battles/StrikeBack.aspx'>Contre-attaque</a></li><li><a href='/fr/Battles/InfestationAttack.aspx'>Attaque Vénéneuse</a></li><li><a href='/fr/Battles/RemoveAbilityAttack.aspx'>Attaque annulant les habiletés</a></li><li><a href='/fr/Battles/TripleAttack.aspx'>Attaque triple</a></li><li><a href='/fr/Battles/BombAttack.aspx'>Attaque explosive</a></li><li><a href='/fr/Battles/Rebound.aspx'>Rebond</a></li></ul><h2>Catégorie</h2><ul><li><a href='/fr/Battles/Light.aspx'>Légère</a></li><li><a href='/fr/Battles/Medium.aspx'>Médium</a></li><li><a href='/fr/Battles/Heavy.aspx'>Lourde</a></li><li><a href='/fr/Battles/Ultimate.aspx'>Ultime</a></li><li><a href='/fr/Battles/Special.aspx'>Spécial</a></li></ul><h2>Type de Combat</h2><ul><li><a href='/fr/Battles/TotalAnnihilation.aspx'>Anihilation totale</a></li><li><a href='/fr/Battles/Regicide.aspx'>Régicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Light Units</h1>
<div class="content">
    <a href='/fr/Battles/Light.aspx'>Légère</a> units are known to be the fastest and also que weakests of the game. Tipicaly, a <a href='/fr/Battles/Light.aspx'>Légère</a> unit
    has <a href='/fr/Battles/Movement.aspx#MovAll'>Mobilité totale</a> and <a href='/fr/Battles/Movement.aspx#MovCost'>Coût de mouvemment</a> of 1, and they are cheaper than <a href='/fr/Battles/Medium.aspx'>Médium</a> and <a href='/fr/Battles/Heavy.aspx'>Lourde</a> <a href='/fr/UnitIndex.aspx'>Unités de Combat</a>.
    <p />
    Any balanced <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> has a substantial percentage of <a href='/fr/Battles/Light.aspx'>Légère</a> units, mainly because they're
    necessary as <a href='/fr/Battles/DispensableUnits.aspx'>Chair à canon</a>, one of the most used <a href='/fr/Battles/BattleTactics.aspx'>Tactiques de Combat</a> in <a href='http://www.orionsbelt.eu'>Orion's Belt</a>.
    <p />
    But <a href='/fr/Battles/Light.aspx'>Légère</a> units aren't there only to be sacrificed. There're very powerful units that can easily
    strike down any bigger unit.
    <p />
    <a href='/fr/Battles/Light.aspx'>Légère</a> units:
  </div>
	<ul class='imageList'><li><a href='/fr/Unit/Raptor.aspx'><img class='raptor' src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /></a></li><li><a href='/fr/Unit/Rain.aspx'><img class='rain' src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Bruine' /></a></li><li><a href='/fr/Unit/Cypher.aspx'><img class='cypher' src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /></a></li><li><a href='/fr/Unit/Reaper.aspx'><img class='reaper' src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /></a></li><li><a href='/fr/Unit/Panther.aspx'><img class='panther' src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panthère' /></a></li><li><a href='/fr/Unit/Seeker.aspx'><img class='seeker' src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Ouvrier' /></a></li><li><a href='/fr/Unit/Egg.aspx'><img class='egg' src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Oeuf' /></a></li><li><a href='/fr/Unit/Maggot.aspx'><img class='maggot' src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Asticot' /></a></li><li><a href='/fr/Unit/DarkRain.aspx'><img class='darkrain' src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Bruine Noire' /></a></li><li><a href='/fr/Unit/Toxic.aspx'><img class='toxic' src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxique' /></a></li><li><a href='/fr/Unit/Anubis.aspx'><img class='anubis' src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /></a></li><li><a href='/fr/Unit/Jumper.aspx'><img class='jumper' src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /></a></li><li><a href='/fr/Unit/Samurai.aspx'><img class='samurai' src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /></a></li><li><a href='/fr/Unit/Interceptor.aspx'><img class='interceptor' src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Intercepteur' /></a></li><li><a href='/fr/Unit/Sentry.aspx'><img class='sentry' src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /></a></li></ul>
	
</asp:Content>