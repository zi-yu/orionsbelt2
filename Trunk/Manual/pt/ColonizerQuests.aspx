﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonizador
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Colonizador</h1><div class='description'>Os colonizadores são aqueles que viajam pelo <a href='/pt/Universe/Default.aspx'>Universo</a> à conquista de planetas.</div><h2>Missões de Colonizador</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='6'><a href='Quest/ColonizeOnePlanetQuest.aspx'>Colonizar um outro planeta na tua zona privada</a></td></tr><tr><td colspan='6'><a href='Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Colonizar todos os cinco planetas na tua zona privada</a></td></tr><tr><td colspan='6'><a href='Quest/FindPrivateWormHoleQuest.aspx'>Encontra o Túnel Espacial da tua zona privada e usa-o para viajar para a zona pública</a></td></tr><tr><td colspan='2'><a href='Quest/Colonize1HotLevel1Quest.aspx'>Possuir um planeta de nível 1 na zona pública</a></td><td colspan='2'><a href='Quest/Colonize1HotLevel1QuestDark.aspx'>Possuir um planeta de nível 1 na zona pública</a></td><td colspan='2'><a href='Quest/Colonize1HotLevel1QuestBugs.aspx'>Possuir um planeta de nível 1 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize5HotLevel1Quest.aspx'>Possuir cinco planetas de nível 1 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize8HotLevel1Quest.aspx'>Possuir oito planetas de nível 1 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize1HotLevel3Quest.aspx'>Possuir um planeta de nível 3 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize5HotLevel3Quest.aspx'>Possuir cinco planetas de nível 3 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize8HotLevel3Quest.aspx'>Possuir oito planetas de nível 3 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize1HotLevel5Quest.aspx'>Possuir um planeta de nível 5 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize5HotLevel5Quest.aspx'>Possuir cinco planetas de nível 5 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize8HotLevel5Quest.aspx'>Possuir oito planetas de nível 5 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize1HotLevel7Quest.aspx'>Possuir um planeta de nível 7 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize5HotLevel7Quest.aspx'>Possuir cinco planetas de nível 7 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize8HotLevel7Quest.aspx'>Possuir oito planetas de nível 7 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize1HotLevel9Quest.aspx'>Possuir um planeta de nível 9 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize5HotLevel9Quest.aspx'>Possuir cinco planetas de nível 9 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize8HotLevel9Quest.aspx'>Possuir oito planetas de nível 9 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize1HotLevel10Quest.aspx'>Possuir um planeta de nível 10 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize5HotLevel10Quest.aspx'>Possuir cinco planetas de nível 10 na zona pública</a></td></tr><tr><td colspan='6'><a href='Quest/Colonize8HotLevel10Quest.aspx'>Possuir oito planetas de nível 10 na zona pública</a></td></tr></table>
	
</asp:Content>