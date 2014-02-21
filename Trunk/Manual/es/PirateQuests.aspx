<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pirata
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Pirata</h1><div class='description'>Un [Pirata] es la escoría del <a href='/es/Universe/Default.aspx'>Universo</a>! Como pirata vas a atacar flotas inocentes,
  hacer <a href='/es/Universe/Raids.aspx'>Saqueos</a> a planetas desprotegidos y robar lo máximo posíble!</div><h2>Misiones de Pirata</h2><div class='description'>Para desbloquear estas missões, es necesario completar primero: <ul><li><a href='Quest/FinishABattleQuest.aspx'>Hacer una batalha en la zona pública</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3Fleets.aspx'>Atacar y conquistar 3 flotas</a></td></tr><tr><td colspan='6'><a href='Quest/Raid3Planets.aspx'>Saquear 3 planetas</a></td></tr></table>
	
</asp:Content>