<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Rebound
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Rebound</h1>
	<div class="content">
    The <a href='/en/Battles/Rebound.aspx'>Rebound</a> is the attack where no power is wasted, if it is too much to destroy the first set of <a href='/en/UnitIndex.aspx'>Units</a>,
    the remaind power goes to the <a href='/en/UnitIndex.aspx'>Units</a> that are immediately behind the first set of <a href='/en/UnitIndex.aspx'>Units</a> attacked. <p /><img class="block" src="/Resources/Images/Rebound.png" alt="Rebound" />

    In this image can be seen the <a class='fenix' href='/en/Unit/Fenix.aspx'>Fenix</a> attacking the <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a>, imagine that the <a class='fenix' href='/en/Unit/Fenix.aspx'>Fenix</a> attack is 10000 and protection of the
    <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> is only for 8000, then the <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> will suffer damage of 2000 (10000 - 8000 = 2000). But if the <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a> were not
    immediately behind the <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> will no longer suffer any damage, if there is one or more squares between the <a class='pretorian' href='/en/Unit/Pretorian.aspx'>Praetorian</a> and <a class='kamikaze' href='/en/Unit/Kamikaze.aspx'>Kamikaze</a>.
  </div>
	
</asp:Content>