<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Catapult
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><h1>Catapult Attack</h1>
<div class="content">
    Probably the <a href='/en/Battles/Catapult.aspx'>Catapult</a> attack is the most unstoppable of all attacks, because even when exists <a href='/en/UnitIndex.aspx'>Units</a>
    serving as <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a>, they are useless in this case. <p />
    The <a href='/en/Battles/Catapult.aspx'>Catapult</a> ignore any unit that is in its front, friend or foe unit, and it is enable to attack
    any enemy unit that is in its <a href='/en/Battles/Range.aspx'>Range</a>. An example is the following image:

    <img class="block" src="/Resources/Images/Catapult.png" alt="Catapult" />

    This attack is perfect for surgical strikes behind a defensive barrier. <p />
    Another feature that makes this attack very interesting, is the <a href='/en/Battles/StrikeBack.aspx'>Strike Back</a> of the attacked unit be ignored
    if the unit that shoots have a unit between it and attacked unit.

  </div></h1>
	
</asp:Content>