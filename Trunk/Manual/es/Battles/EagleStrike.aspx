<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Lluvia de Aguilas
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalla</h2><ul><li><a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a></li><li><a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a></li><li><a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a></li><li><a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a></li><li><a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Lluvia de Aguilas</h1>
<div class="content">
   La táctica <a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a> tiene como objetivo eliminar en los primeros turnos algunas <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> adversárias
   fragiles pero que pueden ser una amenaza en el trancurso del juego. Esta táctica sacrifica pequeños grupos de <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>
   y tiene como objetivo atacar:
   <ul><li><a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> - que en el futuro pueden destruir <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> importantes, por no mencionar la siempre presente <a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a></li><li><a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a> - Con un gran bono contra unidades de <a href='/es/Battles/Heavy.aspx'>Gran Porte</a>, la <a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a> es una amenaza relevante</li><li><a class='seeker' href='/es/Unit/Seeker.aspx'>Buscador</a> - Con un gran bono contra unidades de <a href='/es/Battles/Medium.aspx'>Médio Porte</a>, el <a class='seeker' href='/es/Unit/Seeker.aspx'>Buscador</a> también es una amenaza relevante</li><li>Grupos con grandes cantidades de unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a>, que puedan ser usados para <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a></li></ul>
   Todas estas <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> pueden hacer grandes estragos en nuestra <a href='/es/Universe/Fleet.aspx'>Flota</a>, pero tienen como desventaja ser muy fragiles. De ahí la necesidad de colocar pequeños grupos de <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a> para que las   destruyan.
   <p />
   La preparación para la <a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a> comienza en el <a href='/es/Battles/Deploy.aspx'>Posicionar</a> y consiste en colocar 2/3 grupos de <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a> en la linea de frente. 
  En la primera jugada esos 3 grupos son movidos a una cuadrícula. Ver ejemplo:
   
   <img class="block" src="/Resources/Images/EagleStrike.png" alt="Exemplo Chuva de Águias" />

   Como se puede ver los grupos de <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a> ponen en jaque tanto al grupo de <a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a> como al grupo de <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>.
   Y va a ser muy complicado para el adversário proteger ambos grupos. Y aún si lo consigue , probablemente no logrará hacer ningún movimiento de ataque.

   <p />

   La <a class='kahuna' href='/es/Unit/Kahuna.aspx'>Kahuna</a> también puede ser considerada en vez de la <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>, pero no será tan eficaz.

    </div>

</asp:Content>