<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gestión de Planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gestión de Planetas</h1><div class='description'><a href='/es/Quests.aspx'>Misiones</a> que se enfocan en mejorar tus planetas.</div><h2>Misiones de Gestión de Planetas</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='2'><a href='Quest/BuildSeriumExtractorQuest.aspx'>Construir un Extractor de Serium en tu planeta madre</a></td><td colspan='2'><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Construir un Extractor de Titanium en tu planeta madre</a></td><td colspan='2'><a href='Quest/BuildElkExtractorQuest.aspx'>Construir un Extractor de Elk en tu planeta madre</a></td></tr></table>
	
</asp:Content>