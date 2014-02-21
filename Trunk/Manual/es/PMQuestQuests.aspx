﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gestión de Planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gestión de Planetas</h1><div class='description'><a href='/es/Quests.aspx'>Misiones</a> que se enfocan en mejorar tus planetas.</div><h2>Misiones de Gestión de Planetas</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td><a href='Quest/BuildSolarPanelQuest.aspx'>Construir un Panel Solar en tu planeta madre</a></td><td><a href='Quest/BuildSeriumExtractorQuest.aspx'>Construir un Extractor de Serium en tu planeta madre</a></td><td><a href='Quest/BuildDevotionSanctuaryQuest.aspx'>Construir un Santuário de Devoción en tu planeta madre</a></td><td><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Construir un Extractor de Titanium en tu planeta madre</a></td><td><a href='Quest/BuildProtolExtractorQuest.aspx'>Construir un Extractor de Protol en tu planeta madre</a></td><td><a href='Quest/BuildElkExtractorQuest.aspx'>Construir un Extractor de Elk en tu planeta madre</a></td></tr><tr><td colspan='2'><a href='Quest/BuildCommandCenterQuest.aspx'>Evoluciones el  Centro de Comando en tu planeta madre</a></td><td colspan='2'><a href='Quest/BuildDarknessHallQuest.aspx'>Evolucionar la Capital de la Oscuridad de tu planeta madre</a></td><td colspan='2'><a href='Quest/BuildNestQuest.aspx'>Evolucionar el Nido de tu planeta madre</a></td></tr><tr><td colspan='2'><a href='Quest/BuildUnitYardQuest.aspx'>Construir un Puerto Espacial en tu planeta madre, que permitirá construir unidades de combate</a></td><td colspan='2'><a href='Quest/BuildDominationYardQuest.aspx'>Construir un Puerto de Domínio en te planeta madre, que te permitirá construir unidades de combate</a></td><td colspan='2'><a href='Quest/BuildIncubatorQuest.aspx'>Construir una Encubadora en tu planeta madre, que te permitirá construir unidades de combate</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel1.aspx'>Poseer un Extractor nível 1 en un planeta de la zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel3.aspx'>Evolucionar el edifício principal de todos tus planetas privados para nivel 3</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel5.aspx'>Evolucionar el edifício principal de todos tus planetas privados para nivel 5</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel3.aspx'>Poseer un Extractor nivel 3 en un planeta de la zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel7.aspx'>Evolucionar el edifício principal de todos tus planetas privados para nivel 7</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel9.aspx'>Evolucionar el edifício principal de todos tus planetas privados para nivel 9</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel5.aspx'>Poseer un Extractor nivel 5 en un planeta de la zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel10.aspx'>Evolucionar el edifício principal de todos tus planetas privados para nivel 10</a></td></tr></table>
	
</asp:Content>