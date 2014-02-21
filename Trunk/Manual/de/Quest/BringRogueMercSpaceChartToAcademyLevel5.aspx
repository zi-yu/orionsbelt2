<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Rogue Merc Weltraumkarte zu einer Level 5 Akademie
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Rogue Merc Weltraumkarte zu einer Level 5 Akademie" runat="server" /></h1>
	
	<div class="description">
		Mercs haben eine der besten Weltraum-Karten im Universum. Ich muss eine dieser Weltraum-Karten von einer Rogue Mercs Flotte erwerben. Wenn du eine erworben hast, bringe sie zu einer Level 5 Akademie.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +8500</li><li><a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a> : +4500</li><li><a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a> : +4500</li><li><a class='scourge' href='/de/Unit/Scourge.aspx'>Scourge</a> : +40</li></ul>
	</div>
	
</asp:Content>