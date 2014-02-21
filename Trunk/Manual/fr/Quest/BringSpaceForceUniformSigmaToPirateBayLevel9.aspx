<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Space Force Sigma Uniforms to a level 1 Pirate Bay
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Space Force Sigma Uniforms to a level 1 Pirate Bay" runat="server" /></h1>
	
	<div class="description">
		I need to infiltrate in a Sigma Force's fleet and for that i need certain items. 10 Sigma Force's uniforms to be exact. Bring them to any level 9 Pirate Bay.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +14000</li><li><a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a> : +7000</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +7000</li><li><a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a> : +7000</li></ul>
	</div>
	
</asp:Content>