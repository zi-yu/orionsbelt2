<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pelotón de Fusilamiento
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalla</h2><ul><li><a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a></li><li><a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a></li><li><a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a></li><li><a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a></li><li><a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Pelotón de Fusilamiento</h1>
<div class="content">
    Los <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a> fué una estratégia de batalla muy utilizada en los inicios de <a href='http://www.orionsbelt.eu'>Orion's Belt</a>. En la antigüedad
    era posible obtener un <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> muy temprano. El <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> es una unidad <a href='/es/Battles/Heavy.aspx'>Gran Porte</a> muy poderosa y con 6 de
    <a href='/es/Battles/Range.aspx'>Alcance</a>, lo que hizo que varios jugadores se concentrasen en producir solamente estas unidades y las
    colocasen todas en la fila de enfrente. Con un <a href='/es/Battles/Range.aspx'>Alcance</a> de 6 ellas conseguian alcanzar todo el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>.
    De ahí vino el nombre de <i>pelotón de Fucilamiento</i>.
    <p /><h2>Batalla de Ejemplo</h2>
    El <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a> puede ser una táctica muy compleja de defender por parte del adversário, tal como
    también puede ser muy simple de contraatacar. Veamos el seguiente ejemplo de una batalla de
    <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a>:
  </div>

	<p><iframe class='battle' src="/Resources/Battles/FiringSquad1.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
	<div class="content">
  <p>
  Como podemos ver el adversário no logra resistir al poder de <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a>. Esta táctica no requiere
  gran capacidad de batalla, solamente requiere tener en la <a href='/es/Universe/Fleet.aspx'>Flota</a> una enorme cantidad de <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> de largo
  alcance.
    </p>
  <h2>Alteraciones al Juego para Atenuar el Pelotón de Fusilamiento</h2>
  <p>
  El <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a> se volvio una táctica tan común que el juego tuvo que ser modificado y adicionar algunas reglas extra para
  atenuar su efecto, relativamente:
  <ul><li>
  El daño dado por las unidades llevo una atenuación en base a la distancia. De esta forma un
  <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> no haría tanto daño en las defensas adversárias.
    </li><li>Fueron creadas unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> con bonos especiales contra unidades de <a href='/es/Battles/Heavy.aspx'>Gran Porte</a>.</li></ul></p>
  <h2>Desventajas del Pelotón de Fusilamiento</h2>
  <p>
  Aparentemente,aún con las alteraciones al juego, el <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a> parece ser una táctica ideal y sin defensa.
  A pesar que las apariencias engañan y la verdad que cualquier jugador con mas experiencia logra vencer facilmente
  un <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a>, Aún que no se libere de perder una cantidad razonable de naves.
    </p>
  <p>
  La siguiente batalla ilustra exactamente la estratégia usada para vencer un <a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a>. Como se puede ver,
  una <a href='/es/Universe/Fleet.aspx'>Flota</a> con unidades <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> con el servicio de  <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> y una pequeñaa cantidad de unidades
  <a href='/es/Battles/Medium.aspx'>Médio Porte</a> logra vencer una armada con una gra cantidad de <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a>.
    </p>
</div>
	
	<p><iframe class='battle' src="/Resources/Battles/FiringSquad2.html" scrolling='no' frameborder='0' marginheight='0' marginwidth='0' width='479' height='505'><br /></iframe></p> 
	
</asp:Content>