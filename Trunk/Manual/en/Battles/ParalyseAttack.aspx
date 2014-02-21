<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Paralyse Attack
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Paralyse Attack</h1>
	<div class="content">
    <a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a> is a very strong attack. A single unit with this power can prevent a group of enemy units usage ( attack
    and movement) during a battle turn. This can be very useful to block important units and/or destroy them slowly
    or to prevent the passage of important units.
    <p />
    Be aware that in your turn the unit won't be Paralysed anymore. So if you want to Paralyse a unit (specially the units with
    <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> and [ParalyseAttack] - like <a class='spider' href='/en/Unit/Spider.aspx'>Spider</a>) don't forget to Paralyse the target unit first or attack it from the sides or behind.
    <p />
    Here is a image that represents a <a class='spider' href='/en/Unit/Spider.aspx'>Spider</a> attacking a <a class='doomer' href='/en/Unit/Doomer.aspx'>Doomer</a>:
    <img class="block" src="/Resources/Images/Paralyse.png" alt="Paralyse Attack" /></div>
</asp:Content>