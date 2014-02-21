﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Upravljanje Planetom
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Upravljanje Planetom</h1><div class='description'><a href='/hr/Quests.aspx'>Misije</a> koji se fokusiraju na unaprijeđenje vaših planeta.</div><h2>Upravljanje Planetom Misije</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td><a href='Quest/BuildSolarPanelQuest.aspx'>Izgradi Solarnu Ploču na svome Početnom Planetu</a></td><td><a href='Quest/BuildSeriumExtractorQuest.aspx'>Izgradi Ekstraktor Seriuma na svome Početnom Planetu</a></td><td><a href='Quest/BuildDevotionSanctuaryQuest.aspx'>Izgradi Svetište Obožavanja na svome Početnom Planetu</a></td><td><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Izgradi Ekstraktor Titana na svom Početnom Planetu</a></td><td><a href='Quest/BuildProtolExtractorQuest.aspx'>Izgradi Protol Ekstraktor na Početnoj Planeti</a></td><td><a href='Quest/BuildElkExtractorQuest.aspx'>Izgradi Elk Ekstraktor na Početnoj Planeti</a></td></tr><tr><td colspan='2'><a href='Quest/BuildCommandCenterQuest.aspx'>Unaprijedi Komandni Centar na svome Početnome Planetu</a></td><td colspan='2'><a href='Quest/BuildDarknessHallQuest.aspx'>Izgradi Dvoranu Tame na Početnoj Planeti</a></td><td colspan='2'><a href='Quest/BuildNestQuest.aspx'>Unaprijedi Gnijezdo na Početnoj Planeti</a></td></tr><tr><td colspan='2'><a href='Quest/BuildUnitYardQuest.aspx'>Izgradi Brodogradilište na svom Početnom Planetu,  koje će ti dopustiti da gradiš borbene jedinice.</a></td><td colspan='2'><a href='Quest/BuildDominationYardQuest.aspx'>Izgradi Brodogradilište Dominacije  na Početnoj Planeti, koje će ti omogućiti da gradiš borbene jedinice</a></td><td colspan='2'><a href='Quest/BuildIncubatorQuest.aspx'>Izgradi Inkubator na svome Početnom Planetu, koji će ti omogućiti da gradiš borbene jedinice</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel1.aspx'>Posjeduj ekstraktor nivoa 1 na planetu hot zone</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel3.aspx'>Unaprijedi sva glavna postrojenja na planetima tvoje privatne zone na nivo 3</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel5.aspx'>Unaprijedi sva glavna postrojenja na svojim privatnim planetima na nivo 5</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel3.aspx'>Posjeduj ekstraktor nivoa 3 na planetu u hot zoni</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel7.aspx'>Unaprijedi sva glavna postrojenja na svojim privatnim planetima na nivo 7</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel9.aspx'>Unaprijedi sva glavna postrojenja na svojim privatnim planetima na nivo 9</a></td></tr><tr><td colspan='6'><a href='Quest/OwnExtractorLevel5.aspx'>Posjeduj ekstraktor nivo 5 na planetu hot zone</a></td></tr><tr><td colspan='6'><a href='Quest/ReachPlayerLevel10.aspx'>Unaprijedi sva glavna postrojenja na planetima tvoje privatne zone na nivo 10</a></td></tr></table>
	
</asp:Content>