<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonizar todos os cinco planetas na tua zona privada
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonizar todos os cinco planetas na tua zona privada" runat="server" /></h1>
	
	<div class="description">
		Agora que já aprendeste a colonizar <a href='/pt/Universe/Planets.aspx'>Planetas</a> a tua próxima <a href='/pt/Quests.aspx'>Missão</a> é colonizar todos os planetas da tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>.
  Na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> existem 5 <a href='/pt/Universe/Planets.aspx'>Planetas</a>, descobre-os e coloniza-os.<p />
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a> : +50</li></ul>
	</div>
	
</asp:Content>