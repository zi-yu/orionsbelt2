<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Schlacht
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Schlacht</h1><div class='description'><a href='/de/Quests.aspx'>Missionen</a> die auf Kämpfe ausgerichtet sind.</div><h2>Schlacht Missionen</h2><div class='description'>Um diese Missionen zur Verfügung zu haben, musst du zuerst beenden : <ul><li><a href='Quest/FindPrivateWormHoleQuest.aspx'>Finde ein Wurmloch in deiner Privat-Zone und benutze es um in die öffentliche Zone zu reisen</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/FinishABattleQuest.aspx'>Beende eine Schlacht in der öffentlichen Zone</a></td></tr></table>
	
</asp:Content>