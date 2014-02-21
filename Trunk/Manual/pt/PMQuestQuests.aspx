﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gestão de Planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gestão de Planetas</h1><div class='description'><a href='/pt/Quests.aspx'>Missões</a> que se focam em melhorar os teus planetas.</div><h2>Missões de Gestão de Planetas</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td><a href='Quest/BuildSolarPanelQuest.aspx'>Construir um Painel Solar no teu planeta mãe</a></td><td><a href='Quest/BuildSeriumExtractorQuest.aspx'>Construir um Extractor de Serium no teu planeta mãe</a></td><td><a href='Quest/BuildDevotionSanctuaryQuest.aspx'>Construir um Santuário de Devoção no teu planeta mãe</a></td><td><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Construir um Extrator de Titanium no teu planeta mãe</a></td><td><a href='Quest/BuildProtolExtractorQuest.aspx'>Construir um Extractor de Protol no teu planeta mãe</a></td><td><a href='Quest/BuildElkExtractorQuest.aspx'>Construir um Extrator de Elk no teu planeta mãe</a></td></tr><tr><td colspan='2'><a href='Quest/BuildCommandCenterQuest.aspx'>Evoluir o Centro de Comando no teu planeta mãe</a></td><td colspan='2'><a href='Quest/BuildDarknessHallQuest.aspx'>Evoluir a Capital da Escuridão do teu planeta mãe</a></td><td colspan='2'><a href='Quest/BuildNestQuest.aspx'>Evoluir o Ninho do teu planeta mãe</a></td></tr><tr><td colspan='2'><a href='Quest/BuildUnitYardQuest.aspx'>Construir o Porto Espacial no teu planeta mãe, que permitirá construir unidades de combate</a></td><td colspan='2'><a href='Quest/BuildDominationYardQuest.aspx'>Construir um Porto do Domínio no teu planeta mãe, que te permitirá construir unidades de combate</a></td><td colspan='2'><a href='Quest/BuildIncubatorQuest.aspx'>Construir uma Incubadora no teu planeta mãe, que te permitirá construir unidades de combate</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel1.aspx'>Possuir um Extractor nível 1 num planeta da zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel3.aspx'>Evoluir o edifício principal de todos os teus planetas privados para nível 3</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel5.aspx'>Evoluir o edifício principal de todos os teus planetas privados para nível 5</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel3.aspx'>Possuir um Extractor nível 3 num planeta da zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel7.aspx'>Evoluir o edifício principal de todos os teus planetas privados para nível 7</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel9.aspx'>Evoluir o edifício principal de todos os teus planetas privados para nível 9</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel5.aspx'>Possuir um Extractor nível 5 num planeta da zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel10.aspx'>Evoluir o edifício principal de todos os teus planetas privados para nível 10</a></td></tr></table>
	
</asp:Content>