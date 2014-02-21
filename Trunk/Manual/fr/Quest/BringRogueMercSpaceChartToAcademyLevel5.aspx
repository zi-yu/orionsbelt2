<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Rogue Merc Space Chart to a level 5 Academy
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Rogue Merc Space Chart to a level 5 Academy" runat="server" /></h1>
	
	<div class="description">
		Mercs have one of the best charts of the universe. I need you to aquire one of those universe charts from a Rogue Mercs Fleet. When you adquire one, bring it to a level 5 Academy.
	</div>
	
	<h2>Récompense</h2>
	<div class="description">
		<ul><li>Score : +8500</li><li><a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li><li><a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='scourge' href='/fr/Unit/Scourge.aspx'>Scourge</a> : +40</li></ul>
	</div>
	
</asp:Content>