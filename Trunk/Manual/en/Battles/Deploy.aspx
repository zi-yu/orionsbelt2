<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Deploy
	
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Battle Concepts</h2><ul><li><a href='/en/Battles/GameBoard.aspx'>Game Board</a></li><li><a href='/en/Battles/Deploy.aspx'>Deploy</a></li><li><a href='/en/Battles/Movement.aspx'>Movement</a></li><li><a href='/en/Battles/Rules.aspx'>Rules</a></li></ul><h2>Attack</h2><ul><li><a href='/en/Battles/Range.aspx'>Range</a></li><li><a href='/en/Battles/Catapult.aspx'>Catapult</a></li><li><a href='/en/Battles/ParalyseAttack.aspx'>Paralyse Attack</a></li><li><a href='/en/Battles/Replicator.aspx'>Replicator</a></li><li><a href='/en/Battles/StrikeBack.aspx'>Strike Back</a></li><li><a href='/en/Battles/InfestationAttack.aspx'>Infestation Attack</a></li><li><a href='/en/Battles/RemoveAbilityAttack.aspx'>Remove Ability Attack</a></li><li><a href='/en/Battles/TripleAttack.aspx'>Triple Attack</a></li><li><a href='/en/Battles/BombAttack.aspx'>Bomb Attack</a></li><li><a href='/en/Battles/Rebound.aspx'>Rebound</a></li></ul><h2>Category</h2><ul><li><a href='/en/Battles/Light.aspx'>Light</a></li><li><a href='/en/Battles/Medium.aspx'>Medium</a></li><li><a href='/en/Battles/Heavy.aspx'>Heavy</a></li><li><a href='/en/Battles/Ultimate.aspx'>Ultimate</a></li><li><a href='/en/Battles/Special.aspx'>Special</a></li></ul><h2>Battle Type</h2><ul><li><a href='/en/Battles/TotalAnnihilation.aspx'>Total Annihilation</a></li><li><a href='/en/Battles/Regicide.aspx'>Regicide</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Deploy</h1>
	<div class="content">
    <a href='/en/Battles/Deploy.aspx'>Deploy</a> is the first thing every player must make in the beginning of the battle. Each player starts with a certain number of units 
    that must be place in any of the 16 beggining squares (see picture below):
    <p /><img class="block" src="/Resources/Images/DeployArea.png" alt="Deploy Area" /><p />
    In the <a href='/en/Battles/Deploy.aspx'>Deploy</a> there aren't any <a href='/en/Battles/Movement.aspx#MovPoints'>Movement Points</a> to spend and the <a href='/en/Battles/Movement.aspx'>Movement</a> type of each unit is not taken into account. You can insert all
    the units whereaver you like and splitting them at your own will.
    <p />
    In the battle between 4 players the same rules of the battle between 2 players are applied. Also, the area you have for deploying you'r units
    is the same (see picture below).
    <p /><img class="block" style="width:510px;" src="/Resources/Images/DeployArea4.png" alt="Deploy Area for a 4 players battle" /><p />
    The Battle will only start when the players have deployed their units. Also, when you are deploying your units, you can't see the adversary(ies) deploying 
    theirs. The adversary(ies) units will only be visible when the battle starts.
    <p />
    In every battle, even in a 4 player battle, the maximum number of units you can have is 8. The only exception is a <a href='/en/Battles/Regicide.aspx'>Regicide</a> battle where you will have 9 units. 
    The 9nth unit is the <a class='flag' href='/en/Unit/Flag.aspx'>Flag</a> that is added automatically to your fleet.
    <p />
    Below is a video that teach you how to deploy your units:
    <p /></div>
</asp:Content>