<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Atacar e conquistar 3 armadas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Missões</h2><ul><li><a href='/pt/PirateQuests.aspx'>Pirata</a></li><li><a href='/pt/RaceQuests.aspx'>Raça</a></li><li><a href='/pt/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/pt/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/pt/BattleQuests.aspx'>Batalha</a></li><li><a href='/pt/PMQuestQuests.aspx'>Gestão de Planetas</a></li><li><a href='/pt/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/pt/BountyHunterQuests.aspx'>Caçador de Prémios</a></li><li><a href='/pt/MercsQuests.aspx'>Mercs</a></li><li><a href='/pt/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Atacar e conquistar 3 armadas" runat="server" /></h1>
	
	<div class="description">
		Entrar em batalha com outra <a href='/pt/Universe/Fleet.aspx'>Armada</a> é tão fácil como conquistar um <a href='/pt/Universe/Planets.aspx'>Planeta</a>.
  Só tens de ter a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a> seleccionada (a que queres usar para atacar outro jogador) e clicar na <a href='/pt/Universe/Fleet.aspx'>Armada</a> que pretendes atacar. <p />
  Um pequeno menu vai aparecer com as opções "Atacar", clica e a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a> vai automaticamente perseguir e atacar a <a href='/pt/Universe/Fleet.aspx'>Armada</a> inimiga.
  Assim que a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a>  alcançar a outra, uma batalha irá começar e estará acessível no menu de batalhas.<p />
  A tua <a href='/pt/Universe/Fleet.aspx'>Armada</a> obviamente ficará imobilizada durante o tempo de batalha. Assim que a batalha acabar (e se ganhares) poderás novamente
  controlar a <a href='/pt/Universe/Fleet.aspx'>Armada</a>, se perderes a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a> será destruída e os recursos que tiver serão roubados. Então tem cuidado antes de atacares
  outra <a href='/pt/Universe/Fleet.aspx'>Armada</a>, se tiveres recursos na carga e não os quiseres perder.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuação : +3500</li><li><a href='/pt/PirateQuests.aspx'>Pirata</a> : +20</li><li><a class='astatine' href='/pt/Intrinsic/Astatine.aspx'>Astatine</a> : +1500</li><li><a class='radon' href='/pt/Intrinsic/Radon.aspx'>Radon</a> : +1500</li><li><a class='prismal' href='/pt/Intrinsic/Prismal.aspx'>Prismal</a> : +1500</li><li><a class='argon' href='/pt/Intrinsic/Argon.aspx'>Argon</a> : +1500</li><li><a class='cryptium' href='/pt/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1500</li></ul>
	</div>
	
</asp:Content>