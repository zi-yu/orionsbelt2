﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Apportez une esadrille avec des outils et approvisionnements à un marché de niveau 3 ou 5
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Apportez une esadrille avec des outils et approvisionnements à un marché de niveau 3 ou 5" runat="server" /></h1>
	
	<div class="description">
		Diriger une escadrille ayant des outils et des provisions à un marché niveau 3 ou 5
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +2500</li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a> : +30</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +500</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +500</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +500</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +500</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +500</li></ul>
	</div>
	
</asp:Content>