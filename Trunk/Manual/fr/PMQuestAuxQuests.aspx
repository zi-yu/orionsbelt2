<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gérer les planètes
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Quêtes</h2><ul><li><a href='/fr/PirateQuests.aspx'>Pirate</a></li><li><a href='/fr/RaceQuests.aspx'>Race</a></li><li><a href='/fr/ColonizerQuests.aspx'>Coloniseur</a></li><li><a href='/fr/GladiatorQuests.aspx'>Gladiateur</a></li><li><a href='/fr/BattleQuests.aspx'>Bataille</a></li><li><a href='/fr/PMQuestQuests.aspx'>Gérer les planètes</a></li><li><a href='/fr/MerchantQuests.aspx'>Marchand</a></li><li><a href='/fr/BountyHunterQuests.aspx'>Chasseur de prime</a></li><li><a href='/fr/MercsQuests.aspx'>Mercs</a></li><li><a href='/fr/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gérer les planètes</h1><div class='description'><a href='/fr/Quests.aspx'>Quêtes</a> that focus on improving your planets.</div><h2>Gérer les planètes Quêtes</h2><table class='table' id='quests'><tr><th colspan='2'>Utopians</th><th colspan='2'>Renegades</th><th colspan='2'>Levyr</th></tr><tr><td colspan='2'><a href='Quest/BuildSeriumExtractorQuest.aspx'>Construire un extracteur de serium sur votre planète mère</a></td><td colspan='2'><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Construire un extracteur de Titanium sur votre planète mère</a></td><td colspan='2'><a href='Quest/BuildElkExtractorQuest.aspx'>Construire un extracteur d'elk sur votre planète mère</a></td></tr></table>
	
</asp:Content>