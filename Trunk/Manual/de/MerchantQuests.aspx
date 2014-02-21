﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Händler
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missionen</h2><ul><li><a href='/de/PirateQuests.aspx'>Pirat</a></li><li><a href='/de/RaceQuests.aspx'>Rasse</a></li><li><a href='/de/ColonizerQuests.aspx'>Siedler</a></li><li><a href='/de/GladiatorQuests.aspx'>Gladiator</a></li><li><a href='/de/BattleQuests.aspx'>Schlacht</a></li><li><a href='/de/PMQuestQuests.aspx'>Planeten-Management</a></li><li><a href='/de/MerchantQuests.aspx'>Händler</a></li><li><a href='/de/BountyHunterQuests.aspx'>Kopfgeldjäger</a></li><li><a href='/de/MercsQuests.aspx'>Mercs</a></li><li><a href='/de/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Händler</h1><div class='description'><a href='/de/Quests.aspx'>Missionen</a> die auf <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> ausgerichtet sind.</div><h2>Händler Missionen</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/GetAllPrivateZoneResources.aspx'>Fange all die Ressourcen in deiner Privat-Zone ein</a></td></tr><tr><td colspan='6'><a href='Quest/FindOneMarketQuest.aspx'>Finde einen Markt in der öffentlichen Zone</a></td></tr><tr><td colspan='6'><a href='Quest/FirstTradeRouteQuest.aspx'>Vollende eine Handelsroute</a></td></tr><tr><td colspan='6'><a href='Quest/CompleteForLevel1TradeRoutes.aspx'>Vollende 4 Handelsrouten mit "Werkzeuge und Vorräte"</a></td></tr><tr><td colspan='6'><a href='Quest/Complete10Level1TradeRoutes.aspx'>Vollende 10 Handelsrouten mit "Werkzeuge oder Vorräte" in 24 Stunden</a></td></tr><tr><td colspan='6'><a href='Quest/BringToolsAndSuppliesToMarketLevel3.aspx'>Bring eine Flotte sowohl mit Werkzeugen als auch mit Vorräten zu einem Level 3 oder Level 5 Markt</a></td></tr><tr><td colspan='6'><a href='Quest/Complete8Level3TradeRoutes.aspx'>Vollende 8 Handelsrouten indem du Alkohol oder Medizin benutzt</a></td></tr><tr><td colspan='6'><a href='Quest/Complete12Level3TradeRoutes.aspx'>Vollende 12 Handelsrouten indem du Alkohol oder Medizin benutzt, in 24 Stunden</a></td></tr><tr><td colspan='6'><a href='Quest/BringMedicineAndAlcoholToMarketLevel7.aspx'>Bring Medizin und Alkohol zu einem Level 7 Markt</a></td></tr><tr><td colspan='6'><a href='Quest/Complete12Level7TradeRoutes.aspx'>Vollende 12 Handelsrouten indem du Quecksilber oder Diamanten benutzt</a></td></tr><tr><td colspan='6'><a href='Quest/Complete16Level7TradeRoutes.aspx'>Vollende 16 Handelsrouten indem du Quecksilber oder Diamanten benutzt, in 24 Stunden</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercuryAndDiamondsToMarketLevel10.aspx'>Bring Quecksilber und Diamanten zu einem Level 10 Markt</a></td></tr><tr><td colspan='6'><a href='Quest/Complete16Level10TradeRoutes.aspx'>Vollende 16 Handelsrouten indem du Tiere oder Kosmischen Staub benutzt</a></td></tr><tr><td colspan='6'><a href='Quest/Complete20Level10TradeRoutes.aspx'>Vollende 20 Handelsrouten indem du Tiere oder Kosmischen Staub benutzt, in 24 Stunden</a></td></tr></table>
	
</asp:Content>