<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kamikaze Menace
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Tactics</h2><ul><li><a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a></li><li><a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a></li><li><a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a></li><li><a href='/en/Battles/EagleStrike.aspx'>Eagle Strike</a></li><li><a href='/en/Battles/FiringSquad.aspx'>Firing Squad</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Kamikaze Menace</h1>
<div class="content">
    <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> are one the the most important <a href='/en/UnitIndex.aspx'>Combat Units</a> of the game. They are very fragile, but they
    have a huge devastating power and a movement liberty to reach almost every square on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>.
    Because of these characteristics, having <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> on play is always a <i>menace</i> to the opponent.
    However, you need to make this <i>menace</i> present at all times!
    <p />
    If you have a group of <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> stuck behind some other <a href='/en/UnitIndex.aspx'>Combat Units</a> or out of <a href='/en/Battles/Range.aspx'>Range</a>, then
    it's not considered a menace, at least on the upcoming turns. But a good <a href='/en/Battles/Deploy.aspx'>Deploy</a> can enforce
    the <a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a> from the start. Lets analyse the following example:

    <img class="block" src="/Resources/Images/KamikazeMenace.png" alt="Kamikaze Menace Example" />

    As we can see, the bottom player has two groups of <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a>, one on each side of the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>,
    protected by <a href='/en/Battles/Heavy.aspx'>Heavy</a> units, and with an open attack route.
    <p />
    This disposition enables the bottom player to easilly strike almost all the <a href='/en/Battles/GameBoard.aspx'>Game Board</a> with a group
    of <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a>. And this is very important, because while he doesn't need to spend <a href='/en/Battles/Movement.aspx#MovPoints'>Movement Points</a> with them,
    the opponent needs to be always aware of the <i>menace</i> and use <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> to protect his/her
    every move.
    <p />
    This <i>menace</i> completly changes the opponet's strategy, making him/her act more cautionally.

    <h2>How to fight the Kamikaze Menace?</h2>

    It's very tricky to fight the <a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a> because while doing so will allow the opponent to move other
    <a href='/en/UnitIndex.aspx'>Combat Units</a> to strategic positions. However there're some things that can be considered:
    <ul><li>
    If you have <a href='/en/UnitIndex.aspx'>Combat Units</a> with <a href='/en/Battles/Catapult.aspx'>Catapult</a>, <a href='/en/Battles/Rebound.aspx'>Rebound</a> or <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a>, you can use them to destroy
    the <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a>
  </li><li>
    Other strategy is trying to force the opponent to use the <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> against some sacrificable unit group;
    this way it may be possible to remove the <a href='/en/Battles/KamikazeMenace.aspx'>Kamikaze Menace</a> from other more importante <a href='/en/UnitIndex.aspx'>Combat Units</a>
  </li></ul></div>

</asp:Content>