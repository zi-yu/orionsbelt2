<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Transport Systems to a level 7 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Transport Systems to a level 7 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		Our transport systems are becoming outdated and we need to upgrade it. Bring, to any Pirate Bay level 7, 4 Transport Systems from any Delta Force Fleets.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +9500</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +5500</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +5500</li></ul>
	</div>
	
</asp:Content>