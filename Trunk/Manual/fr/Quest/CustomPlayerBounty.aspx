<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ordered Player Bounty Hunt
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ordered Player Bounty Hunt</h1>
	<div class="description">
    Players can request custom bounties on any target. When a player creates a custom target,
    he has to pay a <a href='/fr/Commerce/Orions.aspx'>Orions</a> reward to the players that assist him/her. Several players may accept a bounty hunt,
    and they progress by taking points from the target on battles on the <a href='/fr/Battles/GameBoard.aspx'>Plateau de jeu</a>.
    <p />
    If more than one hunter steals points, the <a href='/fr/Commerce/Orions.aspx'>Orions</a> reguard will be split.
  </div>
	
</asp:Content>