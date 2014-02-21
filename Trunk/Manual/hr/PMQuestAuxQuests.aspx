<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Upravljanje Planetom
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misije</h2><ul><li><a href='/hr/PirateQuests.aspx'>Pirat</a></li><li><a href='/hr/RaceQuests.aspx'>Rasa</a></li><li><a href='/hr/ColonizerQuests.aspx'>Kolonizator</a></li><li><a href='/hr/GladiatorQuests.aspx'>Gladijator</a></li><li><a href='/hr/BattleQuests.aspx'>Bitka</a></li><li><a href='/hr/PMQuestQuests.aspx'>Upravljanje Planetom</a></li><li><a href='/hr/MerchantQuests.aspx'>Trgovac</a></li><li><a href='/hr/BountyHunterQuests.aspx'>Lovac na Glave</a></li><li><a href='/hr/MercsQuests.aspx'>Mercs</a></li><li><a href='/hr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Upravljanje Planetom</h1><div class='description'><a href='/hr/Quests.aspx'>Misije</a> koji se fokusiraju na unaprijeđenje vaših planeta.</div><h2>Upravljanje Planetom Misije</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='2'><a href='Quest/BuildSeriumExtractorQuest.aspx'>Izgradi Ekstraktor Seriuma na svome Početnom Planetu</a></td><td colspan='2'><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Izgradi Ekstraktor Titana na svom Početnom Planetu</a></td><td colspan='2'><a href='Quest/BuildElkExtractorQuest.aspx'>Izgradi Elk Ekstraktor na Početnoj Planeti</a></td></tr></table>
	
</asp:Content>