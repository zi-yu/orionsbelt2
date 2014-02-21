<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Destroy Captain Wolf
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Destroy Captain Wolf" runat="server" /></h1>
	
	<div class="description">
		The Space Force is destroying our empire and we need to stop it. Captain Wolf, the right hand of their leader, Commander Fox, has to be stopped. Bring me his head! Reports locate him in the level 7 zone but sometimes he wonders in the level 9 and level 10 zones. Find him and bring his Head to any level 7 Pirate Bay.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +100000</li><li><a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a> : +25000</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +25000</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +25000</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +25000</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +25000</li><li><a class='captainwolf' href='/fr/Unit/CaptainWolf.aspx'>CaptainWolf</a> : +1</li></ul>
	</div>
	
</asp:Content>