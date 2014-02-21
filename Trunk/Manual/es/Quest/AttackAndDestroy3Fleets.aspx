<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Atacar y conquistar 3 flotas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Atacar y conquistar 3 flotas" runat="server" /></h1>
	
	<div class="description">
		Entrar en batalla con otra <a href='/es/Universe/Fleet.aspx'>Flota</a> es tan fácil como conquistar un <a href='/es/Universe/Planets.aspx'>Planeta</a>.
  Sólo tienes que tener tu <a href='/es/Universe/Fleet.aspx'>Flota</a> seleccionada (la que quieres usar para atacar otro jugador) y hacer click en la <a href='/es/Universe/Fleet.aspx'>Flota</a> que pretendes atacar. <p />
  Un pequeño menu va a aparecer con las opciones de "Atacar", hace click y  tu <a href='/es/Universe/Fleet.aspx'>Flota</a> va automáticamente perseguir y atacar la <a href='/es/Universe/Fleet.aspx'>Flota</a> enemiga.
  Así que tu <a href='/es/Universe/Fleet.aspx'>Flota</a>  alcancé a la otra, una batalla comenzará y estará acessible en el menu de batallas.<p />
  Tu <a href='/es/Universe/Fleet.aspx'>Flota</a> obviamente quedará imobilizada durante el tiempo de batalla. De la misma manera cuando la batalla acabe (y si ganas) podrás nuevamente
  controlar la <a href='/es/Universe/Fleet.aspx'>Flota</a>, si pierdes tu <a href='/es/Universe/Fleet.aspx'>Flota</a> será destruída y los recursos que tuviese serán robados. Por lo tanto ten cuidado antes de atacar
  otra <a href='/es/Universe/Fleet.aspx'>Flota</a>, si tuvieras recursos en la carga y no los quieres perder.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +3500</li><li><a href='/es/PirateQuests.aspx'>Pirata</a> : +20</li><li><a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a> : +1500</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +1500</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +1500</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +1500</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +1500</li></ul>
	</div>
	
</asp:Content>