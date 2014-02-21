<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Triple Attack
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Triple Attack</h1>
	<div class="content">
    <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a> is a devastating attack that may destroy three groups of units with just an attack. When
    you use a group having <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a> to attack, the adjacent unit groups will get <b>50%</b> of
    the damage inflicted on the target group.
    <p />
    This attack is ideal to destroy the enemy's <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> and also to reach <i>unreachable</i> groups.
    Here's an example of the attack:

    <img class="block" src="/Resources/Images/Triple1.png" alt="Triple Attack" />

    All the enemy's <a class='rain' href='/en/Unit/Rain.aspx'>Rain</a> will be destroyed by that <a class='driller' href='/en/Unit/Driller.aspx'>Driller</a>. That's because the <a class='driller' href='/en/Unit/Driller.aspx'>Driller</a> has <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a>
    and because the <a class='rain' href='/en/Unit/Rain.aspx'>Rain</a> groups are on exactly that positions, adjacent to the target, and perpendicular
    to the <a class='driller' href='/en/Unit/Driller.aspx'>Driller</a>.

    <p />
    <a href='/en/UnitIndex.aspx'>Combat Units</a> with <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a> are also able to reach <i>unreachable</i> groups. Consider the folloging
    example. The enemy's <a class='fenix' href='/en/Unit/Fenix.aspx'>Fenix</a> is well protected by <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>, that prevent a direct attack.
    However, once again, the <a class='driller' href='/en/Unit/Driller.aspx'>Driller</a> can sneak in and inflict damage on the <a class='fenix' href='/en/Unit/Fenix.aspx'>Fenix</a> using <a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a>:

    <img class="block" src="/Resources/Images/Triple2.png" alt="Triple Attack" /></div>
	
</asp:Content>