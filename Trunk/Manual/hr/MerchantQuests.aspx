﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trgovac
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Trgovac</h1><div class='description'><a href='/hr/Quests.aspx'>Misije</a> koji se fokusiraju na <a href='/hr/Commerce/TradeRoutes.aspx'>Trgovačke Rute</a>.</div><h2>Trgovac Misije</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/GetAllPrivateZoneResources.aspx'>Uhvati sve resurse unutar tvoje privatne zone</a></td></tr><tr><td colspan='6'><a href='Quest/FindOneMarketQuest.aspx'>Nađi jedan market u javnoj zoni</a></td></tr><tr><td colspan='6'><a href='Quest/FirstTradeRouteQuest.aspx'>Završi trgovačku rutu</a></td></tr><tr><td colspan='6'><a href='Quest/CompleteForLevel1TradeRoutes.aspx'>Završi 4 trgovačke rute sa Alatima ili Zalihama</a></td></tr><tr><td colspan='6'><a href='Quest/Complete10Level1TradeRoutes.aspx'>Završi 10 trgovačkih ruta sa Alatima ili Zalihama unutar 24 sata.</a></td></tr><tr><td colspan='6'><a href='Quest/BringToolsAndSuppliesToMarketLevel3.aspx'>Dovedi flotu sa Alatima  i Zalihama na Market između nivoa 3 i 5</a></td></tr><tr><td colspan='6'><a href='Quest/Complete8Level3TradeRoutes.aspx'>Završi 8 trgovačkih ruta sa Alkoholom ili Lijekovima</a></td></tr><tr><td colspan='6'><a href='Quest/Complete12Level3TradeRoutes.aspx'>Završi 12 trgovačkih ruta sa Alkoholom ili Lijekovima unutar 24 sata</a></td></tr><tr><td colspan='6'><a href='Quest/BringMedicineAndAlcoholToMarketLevel7.aspx'>Dovedi flotu sa Lijekovima  i Alkoholom na Market nivoa 7</a></td></tr><tr><td colspan='6'><a href='Quest/Complete12Level7TradeRoutes.aspx'>Završi 12 trgovačkih ruta sa Živom ili Dijamantima</a></td></tr><tr><td colspan='6'><a href='Quest/Complete16Level7TradeRoutes.aspx'>Završi 16 trgovačkih ruta sa Živom ili Dijamantima unutar 24 sata</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercuryAndDiamondsToMarketLevel10.aspx'>Dovedi flotu sa  Živom i  Dijamantima na Market nivoa 10</a></td></tr><tr><td colspan='6'><a href='Quest/Complete16Level10TradeRoutes.aspx'>Završi 16 trgovačkih ruta sa Životinjama ili Kozmičkom Prašinom</a></td></tr><tr><td colspan='6'><a href='Quest/Complete20Level10TradeRoutes.aspx'>Završi 20 trgovačkih ruta rabeći Životinje ili Kozmičku Prašinu u 24 sata.</a></td></tr></table>
	
</asp:Content>