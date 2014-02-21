<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Light
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Light Units</h1>
<div class="content">
    <a href='/en/Battles/Light.aspx'>Light</a> units are known to be the fastest and also que weakests of the game. Tipicaly, a <a href='/en/Battles/Light.aspx'>Light</a> unit
    has <a href='/en/Battles/Movement.aspx#MovAll'>Total Movement</a> and <a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a> of 1, and they are cheaper than <a href='/en/Battles/Medium.aspx'>Medium</a> and <a href='/en/Battles/Heavy.aspx'>Heavy</a> <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    <p />
    Any balanced <a href='/en/Universe/Fleet.aspx'>Fleet</a> has a substantial percentage of <a href='/en/Battles/Light.aspx'>Light</a> units, mainly because they're
    necessary as <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>, one of the most used <a href='/en/Battles/BattleTactics.aspx'>Battle Tactics</a> in <a href='http://www.orionsbelt.eu'>Orion's Belt</a>.
    <p />
    But <a href='/en/Battles/Light.aspx'>Light</a> units aren't there only to be sacrificed. There're very powerful units that can easily
    strike down any bigger unit.
    <p />
    <a href='/en/Battles/Light.aspx'>Light</a> units:
  </div>
	<ul class='imageList'><li><a href='/en/Unit/Raptor.aspx'><img class='raptor' src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /></a></li><li><a href='/en/Unit/Rain.aspx'><img class='rain' src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Rain' /></a></li><li><a href='/en/Unit/Cypher.aspx'><img class='cypher' src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /></a></li><li><a href='/en/Unit/Reaper.aspx'><img class='reaper' src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /></a></li><li><a href='/en/Unit/Panther.aspx'><img class='panther' src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Panther' /></a></li><li><a href='/en/Unit/Seeker.aspx'><img class='seeker' src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Seeker' /></a></li><li><a href='/en/Unit/Egg.aspx'><img class='egg' src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Egg' /></a></li><li><a href='/en/Unit/Maggot.aspx'><img class='maggot' src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Maggot' /></a></li><li><a href='/en/Unit/DarkRain.aspx'><img class='darkrain' src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Dark Rain' /></a></li><li><a href='/en/Unit/Toxic.aspx'><img class='toxic' src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxic' /></a></li><li><a href='/en/Unit/Anubis.aspx'><img class='anubis' src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /></a></li><li><a href='/en/Unit/Jumper.aspx'><img class='jumper' src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /></a></li><li><a href='/en/Unit/Samurai.aspx'><img class='samurai' src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /></a></li><li><a href='/en/Unit/Interceptor.aspx'><img class='interceptor' src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Interceptor' /></a></li><li><a href='/en/Unit/Sentry.aspx'><img class='sentry' src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /></a></li></ul>
	
</asp:Content>