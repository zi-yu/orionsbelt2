<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Cannon Fodder
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Tactics</h2><ul><li><a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a></li><li><a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a></li><li><a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a></li><li><a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a></li><li><a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Cannon Fodder</h1>
	<div class="content">
    The <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> is the <u>most used tactic on <a href='http://www.orionsbelt.eu'>Orion's Belt</a></u>! It consists on using small amounts of
    <a href='/en/Battles/Light.aspx'>Light</a> units to defend other more important unit groups on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>. A <a href='/en/Battles/Light.aspx'>Light</a> unit is very
    cheap and has good movement and so, it's ideal to be sacrified to protect more powerful <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    That's why it's called <i>cannon fodder</i>.
    <p />
    Normally we use <a href='/en/Battles/Light.aspx'>Light</a> units, with <a href='/en/Battles/Movement.aspx#MovAll'>Total Movement</a> and <a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a> of 1 as <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>. For example:
    <a class='rain' href='/en/Unit/Rain.aspx'>Rain</a>, <a class='anubis' href='/en/Unit/Anubis.aspx'>Anubis</a>, <a class='seeker' href='/en/Unit/Seeker.aspx'>Seeker</a>, <a class='raptor' href='/en/Unit/Raptor.aspx'>Raptor</a> and if you're really desperate: <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a>.

    <p />
    Lets analyse the following example:

    <img class="block" src="/Resources/Images/DispensableUnits1.png" alt="Exemplo de Carne para Canhão 1" />

    As we can see, we have two groups of <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a> treatining a group of <a class='spider' href='/en/Unit/Spider.aspx'>Spider</a>. But they won't be
    able to attack because there are 2 small groups of <a class='anubis' href='/en/Unit/Anubis.aspx'>Anubis</a> in the way. And it's not worth moving and attacking
    just to destroy such small amount of <a href='/en/UnitIndex.aspx'>Combat Units</a>.
    <p />
    The <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> tactic is very important and it's used by all players. But disabling the adversary's
    attack isn't the only use of <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>.

    <h2>Stop Adversary Movement</h2>

    On <a href='http://www.orionsbelt.eu'>Orion's Belt</a> it's possible to have only 1 unit of <a href='/en/Battles/Light.aspx'>Light</a> on one <a href='/en/Battles/GameBoard.aspx'>Game Board</a> square. And the main advantage
    of doing so is that no adversary unit can move onto that square without destroying the <a href='/en/Battles/Light.aspx'>Light</a> first.
    Meaning: we can use <a href='/en/Battles/Light.aspx'>Light</a> <a href='/en/UnitIndex.aspx'>Combat Units</a> to prevent adversary units to move to an attacking position.
    Lets analyse the previous example, now showing another way to protect the <a class='spider' href='/en/Unit/Spider.aspx'>Spider</a>:

    <img class="block" src="/Resources/Images/DispensableUnits2.png" alt="Exemplo de Carne para Canhão 1" />

    This method is particularly useful agains units with <a href='/en/Battles/Catapult.aspx'>Catapult</a>, that may ignore <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> and
    attack anyway. So, if you can't prevent the attack, consider preventing the move that will enable the attack
    (don't forget this tip if you're up against <a class='vector' href='/en/Unit/Vector.aspx'>Vector</a> or <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a>).

    <h2>How to Fight Cannon Fodder?</h2>

    Fighting <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> can be a game of patience, where you just go by destroying the opponent's 
    <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> until you create an oppening, or the opponent makes a mistake.
    <p />
    However, there are some <a href='/en/UnitIndex.aspx'>Combat Units</a> specially useful agains <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>. All units with the abilities:
    <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a>, <a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a> and <a href='/en/Battles/Rebound.aspx'>Rebound</a> may destroy more than one group of units per attack. On the
    other hand, units with <a href='/en/Battles/Catapult.aspx'>Catapult</a> in <a href='/en/Battles/Range.aspx'>Range</a> may circumvent the opponent's <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> for a direct attack.
    <p />
    But the best way to fight <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> is simply to destroy them all! If you destroy all of your
    opponent's <a href='/en/Battles/Light.aspx'>Light</a> units, he'll be unable to use <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> and will loose for sure.
    A very good unit agains <a href='/en/Battles/Light.aspx'>Light</a> units is the <a class='raptor' href='/en/Unit/Raptor.aspx'>Raptor</a>. With a substantial attack bonus against
    <a href='/en/Battles/Light.aspx'>Light</a> units and a <a href='/en/Battles/Range.aspx'>Range</a> of two, the <a class='raptor' href='/en/Unit/Raptor.aspx'>Raptor</a> is <u>the</u> ultimate <a href='/en/Battles/Light.aspx'>Light</a> unit' hunter!

  </div>

</asp:Content>