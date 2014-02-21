<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Movement
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Battle Movement</h1>
<div class="content">
    Battle movements refers to the act of moving <a href='/en/UnitIndex.aspx'>Combat Units</a> on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a> after finishing the <a href='/en/Battles/Deploy.aspx'>Deploy</a>.
    Each unit has its own movement type, that can be one of the following:
    <ul><li><a href='/en/Battles/Movement.aspx#MovAll'>Total Movement</a></li><li><a href='/en/Battles/Movement.aspx#MovNormal'>Normal Movement</a></li><li><a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a></li><li><a href='/en/Battles/Movement.aspx#MovFront'>Front Movement</a></li><li><a href='/en/Battles/Movement.aspx#MovDrop'>Drop Movement</a></li><li><a href='/en/Battles/Movement.aspx#MovNone'>No Movement</a></li></ul>
    The movement type and the <a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a> define the speed of a unit.

    <a name="MovAll" id="MovAll"></a><h2><a href='/en/Battles/Movement.aspx#MovAll'>Total Movement</a></h2> 
    With <a href='/en/Battles/Movement.aspx#MovAll'>Total Movement</a> a unit can move to any adjacent square. Example:
    <img class="block" src="/Resources/Images/MovAll.png" alt="Mov All" /><a name="MovNormal" id="MovNormal"></a><h2><a href='/en/Battles/Movement.aspx#MovNormal'>Normal Movement</a></h2>
    With <a href='/en/Battles/Movement.aspx#MovNormal'>Normal Movement</a>  unit can move to any adjacent square, except diagonal ones. Example:
    <img class="block" src="/Resources/Images/MovNormal.png" alt="Mov Normal" /><a name="MovDiagonal" id="MovDiagonal"></a><h2><a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a></h2>
    With <a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a> a unit can only move to a diagonal (be aware of the <a href='/en/Battles/DiagonalTrap.aspx'>Diagonal Trap</a>). Example:
    <img class="block" src="/Resources/Images/MovDiagonal.png" alt="Mov Diagonal" /><a name="MovFront" id="MovFront"></a><h2><a href='/en/Battles/Movement.aspx#MovFront'>Front Movement</a></h2>
    With <a href='/en/Battles/Movement.aspx#MovFront'>Front Movement</a> a unit can only move up front. If you need to change the direction, you'll
    have to use a rotation. Example:
    <img class="block" src="/Resources/Images/MovFront.png" alt="Mov Front" /><a name="MovDrop" id="MovDrop"></a><h2><a href='/en/Battles/Movement.aspx#MovDrop'>Drop Movement</a></h2>
    A unit with <a href='/en/Battles/Movement.aspx#MovDrop'>Drop Movement</a> is a unit that may drop another unit on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a> by moving.
    Example: the <a class='queen' href='/en/Unit/Queen.aspx'>Queen</a> may drop an <a class='egg' href='/en/Unit/Egg.aspx'>Egg</a> on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>.

    <a name="MovNone" id="MovNone"></a><h2><a href='/en/Battles/Movement.aspx#MovNone'>No Movement</a></h2>
    A unit with <a href='/en/Battles/Movement.aspx#MovNone'>No Movement</a> can't move during all battle. Example:
    <img class="block" src="/Resources/Images/MovNone.png" alt="Mov Nove" /><a name="MovCost" id="MovCost"></a><h2><a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a></h2>
    The <a href='/en/Battles/Movement.aspx'>Movement</a> type defines how a unit can move on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>, But all <a href='/en/UnitIndex.aspx'>Combat Units</a> also have a
    <a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a> that translates to how fast they are. On each battle turn, a player has 6 <a href='/en/Battles/Movement.aspx#MovPoints'>Movement Points</a> to spend:
    he can move units, attack units, or even ignore them.
    <p />
    If a unit has a <a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a> of 2, that means that we can move it 3 times on the same turn (6/2=3). For
    example, the <a class='doomer' href='/en/Unit/Doomer.aspx'>Doomer</a> has a cost of 3 and the <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a> a cost of 2. And this makes the <a class='eagle' href='/en/Unit/Eagle.aspx'>Eagle</a>
    faster than the <a class='doomer' href='/en/Unit/Doomer.aspx'>Doomer</a>, even thought both units share <a href='/en/Battles/Movement.aspx#MovDiagonal'>Diagonal Movement</a>.

    <a name="MovPoints" id="MovPoints"></a><h2><a href='/en/Battles/Movement.aspx#MovPoints'>Movement Points</a></h2>
    The <a href='/en/Battles/Movement.aspx#MovPoints'>Movement Points</a> represent how much actions you can perform on your battle turn. On each turn you'll get
    six <a href='/en/Battles/Movement.aspx#MovPoints'>Movement Points</a> to spend, and there are several actions that you can take:
    <ul><li>An attack will cost 1 movement point</li><li>Moving a combat unit will have a cost that will depend on the combat unit. All <a href='/en/UnitIndex.aspx'>Combat Units</a>
  have a defined <a href='/en/Battles/Movement.aspx#MovCost'>Movement Cost</a></li><li>Splitting a unit group, will cost twice as much as moving that group</li></ul></div>
	
</asp:Content>