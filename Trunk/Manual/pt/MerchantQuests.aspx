﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Comerciante
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Comerciante</h1><div class='description'><a href='/pt/Quests.aspx'>Missões</a> que se focam em <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a>.</div><h2>Missões de Comerciante</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/GetAllPrivateZoneResources.aspx'>Apanhar todos os recursos que tens na zona privada</a></td></tr><tr><td colspan='6'><a href='Quest/FindOneMarketQuest.aspx'>Encontrar um mercado na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/FirstTradeRouteQuest.aspx'>Completar uma rota comercial</a></td></tr><tr><td colspan='6'><a href='Quest/CompleteForLevel1TradeRoutes.aspx'>Completar 4 rotas comerciais de Ferramentas ou Mantimentos</a></td></tr><tr><td colspan='6'><a href='Quest/Complete10Level1TradeRoutes.aspx'>Completar 10 rotas comerciais de Ferramentas ou Mantimentos em 24 horas</a></td></tr><tr><td colspan='6'><a href='Quest/BringToolsAndSuppliesToMarketLevel3.aspx'>Transportar Ferramentas e Mantimentos numa só armada para um Mercado de nível 3 ou 5</a></td></tr><tr><td colspan='6'><a href='Quest/Complete8Level3TradeRoutes.aspx'>Completar 8 rotas comerciais de Álcool ou Medicamentos</a></td></tr><tr><td colspan='6'><a href='Quest/Complete12Level3TradeRoutes.aspx'>Completar 12 rotas comerciais de Álcool ou Medicamentos em 24 horas</a></td></tr><tr><td colspan='6'><a href='Quest/BringMedicineAndAlcoholToMarketLevel7.aspx'>Trás Medicamentos e Álcool a um Mercado nível 7</a></td></tr><tr><td colspan='6'><a href='Quest/Complete12Level7TradeRoutes.aspx'>Completar 12 rotas comerciais de Mercúrio ou Diamantes</a></td></tr><tr><td colspan='6'><a href='Quest/Complete16Level7TradeRoutes.aspx'>Completar 16 rotas comerciais de Mercúrio ou Diamantes em 24 horas</a></td></tr><tr><td colspan='6'><a href='Quest/BringMercuryAndDiamondsToMarketLevel10.aspx'>Trás Mercúrio e Diamantes a a uma Academia nível 10</a></td></tr><tr><td colspan='6'><a href='Quest/Complete16Level10TradeRoutes.aspx'>Completar 16 rotas comerciais de Animais ou Poeira Cósmica</a></td></tr><tr><td colspan='6'><a href='Quest/Complete20Level10TradeRoutes.aspx'>Completar 20 rotas comerciais de Animais ou Poeira Cósmica em 24 horas</a></td></tr></table>
	
</asp:Content>