<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonize one additional planet on your private zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonize one additional planet on your private zone" runat="server" /></h1>
	
	<div class="description">
		The objective of this mission is to learn how to conquerer a <a href='/en/Universe/Planets.aspx'>Planet</a>. In your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> you can't be plagued
  by other players, so you do not have to have concerns about being attacked. <p />
  Search the universe with a <a href='/en/Universe/Fleet.aspx'>Fleet</a> to find a <a href='/en/Universe/Planets.aspx'>Planet</a>. Then select the <a href='/en/Universe/Fleet.aspx'>Fleet</a>, click on top of the <a href='/en/Universe/Planets.aspx'>Planet</a> and
  conquerer it. The following image shows an example, and you have the mission ready to be delivered.
  <img class="block" src="/Resources/Images/en/colonize.png" alt="Colonize" title="Colonize" />
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a> : +5</li></ul>
	</div>
	
</asp:Content>