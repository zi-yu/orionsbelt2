<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Colonizar um outro planeta na tua zona privada
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Colonizar um outro planeta na tua zona privada" runat="server" /></h1>
	
	<div class="description">
		O objectivo desta missão é aprender a conquistar um <a href='/pt/Universe/Planets.aspx'>Planeta</a>. Na tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> não podes ser importunado
  por outros jogadores, por isso não tens de ter preocupações em ser atacado.<p />
  Navega pelo universo com uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> até encontrares um <a href='/pt/Universe/Planets.aspx'>Planeta</a>. De seguida selecciona a <a href='/pt/Universe/Fleet.aspx'>Armada</a>, clica em cima do <a href='/pt/Universe/Planets.aspx'>Planeta</a> e
  faz conquistar como o que acontece na imagem seguinte e tens a missão pronta a ser entregue.
  <img class="block" src="/Resources/Images/pt/colonize.png" alt="Colonizar" title="Colonizar" />
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a> : +5</li></ul>
	</div>
	
</asp:Content>