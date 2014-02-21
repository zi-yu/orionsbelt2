<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bomb Attack
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Bomb Attack</h1>
	<div class="content">
    <a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a> may be the most powerful attack in the game, if used properly. A combat unit with <a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a>
    inflicts damage on all adversary units close to it when it attacks. This ability is excelent to eliminate
    the enemy's <a href='/en/Battles/DispensableUnits.aspx'>Cannon Fodder</a> or to inflict damage on a large number of groups.
    <p />
    Here's an example of the <a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a> in action:

    <img class="block" src="/Resources/Images/Bomb.png" alt="Bomb Attack" />
    
    On this example, the damage that the unit will inflict on the target, will also be inflicted on all the
    other adjacent groups of <a class='rain' href='/en/Unit/Rain.aspx'>Rain</a>. There is no damage attenuation.
  </div>
	
</asp:Content>