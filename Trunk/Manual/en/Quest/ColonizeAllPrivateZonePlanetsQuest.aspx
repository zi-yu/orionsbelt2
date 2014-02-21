<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonize all five planets on your private zone
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonize all five planets on your private zone" runat="server" /></h1>
	
	<div class="description">
		Now you've learned how to colonize <a href='/en/Universe/Planets.aspx'>Planets</a>, your next <a href='/en/Quests.aspx'>Quest</a> is colonize all planets of your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a>.
  In your <a href='/en/Universe/PrivateZone.aspx'>Private Zone</a> there are 5 <a href='/en/Universe/Planets.aspx'>Planets</a>, discover and colonize them. <p />
	</div>
	
	<h2>Reward</h2>
	<div class="description">
		<ul><li><a href='/en/Commerce/Orions.aspx'>Orions</a> : +50</li></ul>
	</div>
	
</asp:Content>