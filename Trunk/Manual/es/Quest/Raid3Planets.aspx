<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Saquear 3 planetas
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Misiones</h2><ul><li><a href='/es/PirateQuests.aspx'>Pirata</a></li><li><a href='/es/RaceQuests.aspx'>Raza</a></li><li><a href='/es/ColonizerQuests.aspx'>Colonizador</a></li><li><a href='/es/GladiatorQuests.aspx'>Gladiador</a></li><li><a href='/es/BattleQuests.aspx'>Batalla</a></li><li><a href='/es/PMQuestQuests.aspx'>Gestión de Planetas</a></li><li><a href='/es/MerchantQuests.aspx'>Comerciante</a></li><li><a href='/es/BountyHunterQuests.aspx'>Cazador de Premios</a></li><li><a href='/es/MercsQuests.aspx'>Mercs</a></li><li><a href='/es/SpaceForceQuests.aspx'>Space Force</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Saquear 3 planetas" runat="server" /></h1>
	
	<div class="description">
		Saquear un <a href='/es/Universe/Planets.aspx'>Planeta</a> es una acción idéntica a conquistar un <a href='/es/Universe/Planets.aspx'>Planeta</a>.
  Cuando cargas sobre el botón izquierdo del mouse (y tienes una <a href='/es/Universe/Fleet.aspx'>Flota</a> previamente seleccionada) en un <a href='/es/Universe/Planets.aspx'>Planeta</a> que tenga dueño, aparecen dos opciones:
  "Atacar Planeta y Conquistar" y "Saquear Planeta". Ya sabes lo que significa la primeira opción, pero que es la segunda? Saquear?
  Saquear es casi lo mismo que conquistar un <a href='/es/Universe/Planets.aspx'>Planeta</a>,  se aplican todas las reglas, sólo una cosa cambia: el Premio .<p />
  En la primera opción si ganas, ganas el derecho al <a href='/es/Universe/Planets.aspx'>Planeta</a>.
  En la segunda opción robas recursos del <a href='/es/Universe/Planets.aspx'>Planeta</a>. Si el <a href='/es/Universe/Planets.aspx'>Planeta</a> no tuviera <a href='/es/Universe/Fleet.aspx'>Flota</a> de defensa el <a href='/es/Universe/Raids.aspx'>Saqueo</a> es automático, de lo  contrário comienza
  una batalla, y si ganas la <a href='/es/Universe/Raids.aspx'>Saqueo</a> es ejecutada con Éxito.<p />
  Mientras tengas un nivel bajo de saqueo puede no parecer una acción interesante porque hasta normalmente tienes todos los recursos
  que necessitas, pero cuando progreses en el juego vas a tener mas necesidades de recursos y existen mas recursos para robar. Claro que no
  es posible saquear un <a href='/es/Universe/Planets.aspx'>Planeta</a> sin dueño.<p />
  Nota: Saquear solo roba recursos raros, la probabilidad del recurso robado depende de la <a href='/es/Race/Races.aspx'>Raza</a> del jogador que es dueño del <a href='/es/Universe/Planets.aspx'>Planeta</a>.
	</div>
	
	<h2>Recompensa</h2>
	<div class="description">
		<ul><li>Pontuación : +5500</li><li><a href='/es/PirateQuests.aspx'>Pirata</a> : +30</li><li><a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a> : +600</li><li><a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a> : +600</li><li><a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a> : +600</li><li><a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a> : +600</li><li><a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> : +600</li></ul>
	</div>
	
</asp:Content>