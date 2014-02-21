<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trouvez un trou stellaire sur votre zone privée en direction "zone publique"
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Trouvez un trou stellaire sur votre zone privée en direction "zone publique"" runat="server" /></h1>
	
	<div class="description">
		Once you have colonized all the <a href='/fr/Universe/Planets.aspx'>Planètes</a> on your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> the only way to conquer more planets will be to
  leave for the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>. There is only way to get to the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>. You'll have to go through the [Wormhole] that
  is on your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>, there is no other way to make the trip of tens of thousands of light years to the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a> otherwise.
  <p />
  Your <a href='/fr/Quests.aspx'>Quête</a> is find the <a href='/fr/Universe/WormHole.aspx'>Trou stellaire</a> similar to the following image and travel through it to the <a href='/fr/Universe/HotZone.aspx'>Zone publique</a>.
  <img class="block" src="/Resources/Images/en/Wormhole.png" alt="Worm Hole" title="Worm Hole" />
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a> : +15</li></ul>
	</div>
	
</asp:Content>