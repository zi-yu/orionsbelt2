<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planeten-Management
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Planeten-Management</h1><div class='description'><a href='/de/Quests.aspx'>Missionen</a> die darauf ausgerichtet sind deinen Planeten zu verbessern.</div><h2>Planeten-Management Missionen</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='2'><a href='Quest/BuildSeriumExtractorQuest.aspx'>Baue einen Serium Extraktor auf deinem Heimatplaneten</a></td><td colspan='2'><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Baue einen Titanium Extraktor auf deinem Heimatplaneten</a></td><td colspan='2'><a href='Quest/BuildElkExtractorQuest.aspx'>Baue einen Elk Extraktor auf deinem Heimatplaneten</a></td></tr></table>
	
</asp:Content>