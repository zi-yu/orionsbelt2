<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Black Merc Weltraumkarte zu einer Level 9 Akademie
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Black Merc Weltraumkarte zu einer Level 9 Akademie" runat="server" /></h1>
	
	<div class="description">
		Mercs haben eine der besten Weltraum-Karten. Ich möchte das du eine von diesen Karten von einer Black Mercs Flotte erwirbst. Wenn du eine erworben hast, bringe sie zu einer Level 9 Akademie.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +14500</li><li><a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a> : +7000</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +7000</li><li><a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a> : +7000</li><li><a class='walker' href='/de/Unit/Walker.aspx'>Walker</a> : +40</li></ul>
	</div>
	
</asp:Content>