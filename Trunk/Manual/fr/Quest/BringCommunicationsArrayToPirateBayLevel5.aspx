﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring a Communications Array to a level 5 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring a Communications Array to a level 5 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		Space Force is becomming strong in the universe and we need to intercept their communications. Bring to any level 5 Pirate Bay 5 Communications Array. You can find them in any Gamma Force Fleet.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +7500</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +4500</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +4500</li></ul>
	</div>
	
</asp:Content>