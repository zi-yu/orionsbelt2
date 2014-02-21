<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pirat
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Pirat</h1><div class='description'>Als <a href='/de/PirateQuests.aspx'>Pirat</a> wirst du der Abschaum des <a href='/de/Universe/Default.aspx'>Universum</a> sein! Du wirst unschuldige Flotten angreifen,
  <a href='/de/Universe/Raids.aspx'>Plünderung</a> machen auf unbeschützte Planeten und Spieler und sowiel wie möglich ausrauben!</div><h2>Pirat Missionen</h2><div class='description'>Um diese Missionen zur Verfügung zu haben, musst du zuerst beenden : <ul><li><a href='Quest/FinishABattleQuest.aspx'>Beende eine Schlacht in der öffentlichen Zone</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3Fleets.aspx'>Attackiere und zerstöre 3 Planeten</a></td></tr><tr><td colspan='6'><a href='Quest/Raid3Planets.aspx'>Überfalle 3 Planeten</a></td></tr></table>
	
</asp:Content>