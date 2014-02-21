<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Baue eine Herrschafts-Fabrik auf deinem Heimatplaneten, die es dir erlauben wird Kampfeinheiten zu bauen
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Baue eine Herrschafts-Fabrik auf deinem Heimatplaneten, die es dir erlauben wird Kampfeinheiten zu bauen" runat="server" /></h1>
	
	<div class="description">
		Baue den Domination Yard auf deinen Heimatplaneten, der es dir erlaubt Kampfeinheiten zu bauen
	</div>
	
	<h2>Belohnung</h2>
	<div class="description">
		<ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a> : +15</li></ul>
	</div>
	
</asp:Content>