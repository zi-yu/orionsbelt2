<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pirata
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Pirata</h1><div class='description'>Um [Pirata] é a escumalha do <a href='/pt/Universe/Default.aspx'>Universo</a>! Como pirata vais atacar armadas inocentes,
  fazer <a href='/pt/Universe/Raids.aspx'>Pilhagens</a> a planetas desprotegidos e roubar o máximo possível!</div><h2>Missões de Pirata</h2><div class='description'>Para desbloquear estas missões, é preciso completar primeiro: <ul><li><a href='Quest/FinishABattleQuest.aspx'>Fazer uma batalha na zona pública</a></li></ul></div><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/AttackAndDestroy3Fleets.aspx'>Atacar e conquistar 3 armadas</a></td></tr><tr><td colspan='6'><a href='Quest/Raid3Planets.aspx'>Pilhar 3 planetas</a></td></tr></table>
	
</asp:Content>