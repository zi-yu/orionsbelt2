<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Replicator
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Replicator</h1>
	<div class="content">
    <a href='/en/Battles/Replicator.aspx'>Replicator</a> is the attack that can change the numbers in each side. When a unit with this special move attacks, it replicates a certain number of times, equivalent
    to the number of units you destroy. If you destroy 6 units, you'll replicate 6 times.
    <p />
    This special move only works if the attacked unit is fo the same category of above. Example: a <a href='/en/Battles/Medium.aspx'>Medium</a> unit with <a href='/en/Battles/Replicator.aspx'>Replicator</a> only replicates if the target is a <a href='/en/Battles/Medium.aspx'>Medium</a>
    unit or a <a href='/en/Battles/Heavy.aspx'>Heavy</a> unit.
    <p />
    The only unit that has this attack is the <a class='stinger' href='/en/Unit/Stinger.aspx'>Stinger</a>. Which means that this unit will only replicate against <a href='/en/Battles/Medium.aspx'>Medium</a> and <a href='/en/Battles/Heavy.aspx'>Heavy</a> units.
   </div>
</asp:Content>