<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Metallic Beard
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Metallic Beard" runat="server" /></h1>
	
	<div class="description">
		Aujourd'hui, je vous donne votre mission la plus importante. Vous devez trouvez dans les zones de niveau 9 et 10 pour en finir avec la menace qu'est "Barbe métallique". Apportez sa tête à une académie niveau 10.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a> : +3000</li><li>Score : +100000</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +25000</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='metallicbeard' href='/fr/Unit/MetallicBeard.aspx'>Metallic Beard</a> : +1</li></ul>
	</div>
	
</asp:Content>