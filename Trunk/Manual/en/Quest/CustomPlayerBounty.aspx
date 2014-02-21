<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/en/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ordered Player Bounty Hunt
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Quests</h2><ul><li><a href='/en/PirateQuests.aspx'>Pirate</a></li><li><a href='/en/RaceQuests.aspx'>Race</a></li><li><a href='/en/ColonizerQuests.aspx'>Colonizer</a></li><li><a href='/en/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/en/BattleQuests.aspx'>Battle</a></li><li><a href='/en/PMQuestQuests.aspx'>Planet Management</a></li><li><a href='/en/MerchantQuests.aspx'>Merchant</a></li><li><a href='/en/BountyHunterQuests.aspx'>Bounty Hunter</a></li><li><a href='/en/MercsQuests.aspx'>Mercs</a></li><li><a href='/en/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ordered Player Bounty Hunt</h1>
	<div class="description">
    Players can request custom bounties on any target. When a player creates a custom target,
    he has to pay a <a href='/en/Commerce/Orions.aspx'>Orions</a> reward to the players that assist him/her. Several players may accept a bounty hunt,
    and they progress by taking points from the target on battles on the <a href='/en/Battles/GameBoard.aspx'>Game Board</a>.
    <p />
    If more than one hunter steals points, the <a href='/en/Commerce/Orions.aspx'>Orions</a> reguard will be split.
  </div>
	
</asp:Content>