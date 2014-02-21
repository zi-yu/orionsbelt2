<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Encontra o Túnel Espacial da tua zona privada e usa-o para viajar para a zona pública
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Encontra o Túnel Espacial da tua zona privada e usa-o para viajar para a zona pública" runat="server" /></h1>
	
	<div class="description">
		Depois de teres colonizado todos os <a href='/pt/Universe/Planets.aspx'>Planetas</a> da tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> não tens hipoteses de possuir mais <a href='/pt/Universe/Planets.aspx'>Planetas</a>
  a não ser <a href='/pt/Universe/Planets.aspx'>Planetas</a> na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>. Para chegares à <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> só existe uma maneira, fazeres uma viagem pelo <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> que existe
  na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a>, caso contrário nunca conseguirias fazer uma viaja de milhões de anos luz.<p />
  A tua <a href='/pt/Quests.aspx'>Missão</a> é encontrar o <a href='/pt/Universe/WormHole.aspx'>Túnel Espacial</a> idêntico ao da imagem seguinte e viajar através dele até à <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a>.
  <img class="block" src="/Resources/Images/pt/Wormhole.png" alt="Túnel Espacial" title="Tunel Espacial" />
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a> : +15</li></ul>
	</div>
	
</asp:Content>