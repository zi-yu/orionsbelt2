<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Possédez 8 planètes de niveau 5 sur la zone publique
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Possédez 8 planètes de niveau 5 sur la zone publique" runat="server" /></h1>
	
	<div class="description">
		Possédez 8 planètes de niveau 5 sur la zone publique
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +1320</li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a> : +37</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +800</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +400</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +700</li></ul>
	</div>
	
</asp:Content>