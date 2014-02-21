<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Infestation Attack
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Infestation Attack</h1>
	<div class="content">
    <a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a> is like poisoning the enemy unit. If a unit is hit with an <a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a> attack, it will receive a certain ammout of damage during 3 turns (in this 3 turns is included
    the turn of attack).
    <p />
    The amount of damage done is equivalent to 20% of the damage made by the attacked unit. If a unit gave you 1000 of damage, in the first turn (the attack turn), the target will receive 1200.
    In the next 2 turns it will receive 200 damage per turn.
    <p />
    This attack is cummulative which means that a target unit can have several infestations at the same time.
    <p />
    This attack is used by the <a class='blackwidow' href='/en/Unit/BlackWidow.aspx'>Black Widow</a> and <a class='hiveking' href='/en/Unit/HiveKing.aspx'>Hive King</a>.
    <p />
    Here is a image that represents a <a class='hiveking' href='/en/Unit/HiveKing.aspx'>Hive King</a> using Infestation against a <a class='scarab' href='/en/Unit/Scarab.aspx'>Scarab</a>:
    <img class="block" src="/Resources/Images/Infestation.png" alt="Infestation Attack" /></div>
	
</asp:Content>