<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Find a Worm Hole on your private zone and use it to travel to the hot zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Find a Worm Hole on your private zone and use it to travel to the hot zone" runat="server" /></h1>
	
	<div class="description">
		Once you have colonized all the <a href='/en/Universe/Planets.aspx'>Planets</a> on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> the only way to conquer more planets will be to
  leave for the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>. There is only way to get to the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>. You'll have to go through the [Wormhole] that
  is on your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a>, there is no other way to make the trip of tens of thousands of light years to the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a> otherwise.
  <p />
  Your <a href='/en/Quests.aspx'>Quest</a> is find the <a href='/en/Universe/WormHole.aspx'>WormHole</a> similar to the following image and travel through it to the <a href='/en/Universe/HotZone.aspx'>Hot Zone</a>.
  <img class="block" src="/Resources/Images/en/Wormhole.png" alt="Worm Hole" title="Worm Hole" />
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a> : +15</li></ul>
	</div>
	
</asp:Content>