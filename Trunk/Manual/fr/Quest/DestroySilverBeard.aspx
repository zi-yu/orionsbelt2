<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Silver Beard
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Silver Beard" runat="server" /></h1>
	
	<div class="description">
		Nous avons localisé le bras droit de "Barbe métallique". Il s'appel "Barbe Argent". Il aurait été vu dans une zone niveau 7 mais parfois dans les zones 9 et 10. Trouvez le et apporter sa tête dans une académie de niceau 7.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +50000</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +12000</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +12000</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +12000</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +12000</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +12000</li><li><a class='silverbeard' href='/fr/Unit/SilverBeard.aspx'>Silver Beard</a> : +1</li></ul>
	</div>
	
</asp:Content>