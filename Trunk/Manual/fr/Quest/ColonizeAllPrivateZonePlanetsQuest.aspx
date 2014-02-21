<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonisez les 5 planètes sur votre zone privée
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonisez les 5 planètes sur votre zone privée" runat="server" /></h1>
	
	<div class="description">
		Now you've learned how to colonize <a href='/fr/Universe/Planets.aspx'>Planètes</a>, your next <a href='/fr/Quests.aspx'>Quête</a> is colonize all planets of your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a>.
  In your <a href='/fr/Universe/PrivateZone.aspx'>Zone privée</a> there are 5 <a href='/fr/Universe/Planets.aspx'>Planètes</a>, discover and colonize them. <p />
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a> : +50</li></ul>
	</div>
	
</asp:Content>