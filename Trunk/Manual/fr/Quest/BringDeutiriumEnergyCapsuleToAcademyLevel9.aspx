<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring a Deuterium Energy Capsule to a level 9 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring a Deuterium Energy Capsule to a level 9 Academy" runat="server" /></h1>
	
	<div class="description">
		Les Mercs noirs utilise des capsules énergie spéciale provenant du Deutérium pour alimenter leurs unités. Trouvez 3 capsules et apportez les à une académie niveau 9.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +13500</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +7000</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +7000</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +7000</li></ul>
	</div>
	
</asp:Content>