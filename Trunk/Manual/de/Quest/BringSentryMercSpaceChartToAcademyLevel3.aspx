<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Bring Sentry Merc Weltraumkarte zu einer Level 3 Akademie
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Bring Sentry Merc Weltraumkarte zu einer Level 3 Akademie" runat="server" /></h1>
	
	<div class="description">
		Mercs haben eine der besten Weltraum-Karten im Universum. Ich muss eine dieser Karten von einer Sentry Mercs Flotte erwerben. Wenn du eine erworben hast, bringe sie zu einer Level 3 Akademie.
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li>Spielstand : +3500</li><li><a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> : +3500</li><li><a class='reaper' href='/de/Unit/Reaper.aspx'>Reaper</a> : +50</li></ul>
	</div>
	
</asp:Content>