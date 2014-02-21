<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ultimate
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ultimate Units</h1>
<div class="content">
    <a href='/en/Battles/Ultimate.aspx'>Ultimate</a> units are the most powerful <a href='/en/UnitIndex.aspx'>Combat Units</a> of every race. These units are special because they
    aren't placed on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>. However, they can attack and be attacked.
    <p />
    Each <a href='/en/Battles/Ultimate.aspx'>Ultimate</a> unit has very special powers, that make them the ultimate winner decider.
    <p />
    <a href='/en/Battles/Ultimate.aspx'>Ultimate</a> units:
  </div>
	<ul class='imageList'><li><a href='/en/Unit/Queen.aspx'><img class='queen' src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Queen' /></a></li><li><a href='/en/Unit/Blinker.aspx'><img class='blinker' src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Blinker' /></a></li><li><a href='/en/Unit/BattleMoon.aspx'><img class='battlemoon' src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Battle Moon' /></a></li></ul>
	
</asp:Content>