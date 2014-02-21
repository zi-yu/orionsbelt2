<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Space Force Wrecks to a level 3 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Space Force Wrecks to a level 3 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		Myst is a dangerous unit. We need to study its components. Bring 4 Myst Propulsion Systems and 3 Myst Targeting Systems to any level 3 Pirate Bay.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +3500</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +3500</li></ul>
	</div>
	
</asp:Content>