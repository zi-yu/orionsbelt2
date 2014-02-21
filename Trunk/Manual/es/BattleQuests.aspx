<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Batalla
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Batalla</h1><div class='description'><a href='/es/Quests.aspx'>Misiones</a> mas orientadas para las batallas.</div><h2>Misiones de Batalla</h2><div class='description'>Para desbloquear estas missões, es necesario completar primero: <ul><li><a href='Quest/FindPrivateWormHoleQuest.aspx'>Encuentra el Túnel Espacial de tu zona privada y usalo para viajar hacia la zona pública</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/FinishABattleQuest.aspx'>Hacer una batalha en la zona pública</a></td></tr></table>
	
</asp:Content>