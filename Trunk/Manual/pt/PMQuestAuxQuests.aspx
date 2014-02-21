<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gestão de Planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gestão de Planetas</h1><div class='description'><a href='/pt/Quests.aspx'>Missões</a> que se focam em melhorar os teus planetas.</div><h2>Missões de Gestão de Planetas</h2><table class='table' id='quests'><tr><th colspan='2'>Utopianos</th><th colspan='2'>Renegados</th><th colspan='2'>Levyr</th></tr><tr><td colspan='2'><a href='Quest/BuildSeriumExtractorQuest.aspx'>Construir um Extractor de Serium no teu planeta mãe</a></td><td colspan='2'><a href='Quest/BuildTitaniumExtractorQuest.aspx'>Construir um Extrator de Titanium no teu planeta mãe</a></td><td colspan='2'><a href='Quest/BuildElkExtractorQuest.aspx'>Construir um Extrator de Elk no teu planeta mãe</a></td></tr></table>
	
</asp:Content>