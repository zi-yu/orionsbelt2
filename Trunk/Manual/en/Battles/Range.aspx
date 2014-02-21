<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Range
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Range of Combat Units</h1>
<div class="content">
    <a href='/en/Battles/Range.aspx'>Range</a> defines the attack distance of a unit. All units can attack, and some even have some very powerful
    attack powers.
    <p />
    The following example shows the differences of <a href='/en/Battles/Range.aspx'>Range</a> between two <a href='/en/UnitIndex.aspx'>Combat Units</a>: the <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a>
    and the <a class='krill' href='/en/Unit/Krill.aspx'>Krill</a>. The <a class='crusader' href='/en/Unit/Crusader.aspx'>Crusader</a> has a <a href='/en/Battles/Range.aspx'>Range</a> of 6, and because of that can strike any unit
    on front of it. On the other hand, the <a class='krill' href='/en/Unit/Krill.aspx'>Krill</a> only has a <a href='/en/Battles/Range.aspx'>Range</a> of 3, and because of that can only
    attack units that are at a maximum of 3 squares.
    <p />
    Note that if you have another unit between the attacker and the target, the attack won't be possible,
    unless the attacker has <a href='/en/Battles/Catapult.aspx'>Catapult</a>.

    <img class="block" src="/Resources/Images/Range.png" alt="Mov Nove" /></div>
	
</asp:Content>