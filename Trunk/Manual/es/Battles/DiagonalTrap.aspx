<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Trampa Diagonal
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Tácticas de Batalla</h2><ul><li><a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a></li><li><a href='/es/Battles/KamikazeMenace.aspx'>Amenaza Kamikaze</a></li><li><a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a></li><li><a href='/es/Battles/EagleStrike.aspx'>Lluvia de Aguilas</a></li><li><a href='/es/Battles/FiringSquad.aspx'>Pelotón de Fusilamiento</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Trampa Diagonal</h1>
<div class="content">
 
  La <a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a> es una táctica que permite aproveitar las limitaciones de movimiento de todas las unidades con
  <a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a>, como por ejemplo: <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>, <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a>, <a class='doomer' href='/es/Unit/Doomer.aspx'>Aniquiladora</a> o <a class='interceptor' href='/es/Unit/Interceptor.aspx'>Interceptador</a>. Muchos jugadores llaman cariñosamente
  a esta táctica: <i>prisión de vientre</i>.
  <p />
  Las <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> con <a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a> pueden quedar presas sin cualquier forma de escape si tuvieran 
  <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> adversárias en todas las cuadrículas para donde se pueden mover. Como solo atacan hacia adelante, quedan
  completamente vulnerables.
  <p />
  El siguiente ejemplo muestra una <a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a> en las cuatro esquinas:

  <img class="block" src="/Resources/Images/DiagonalTrap2.png" alt="Exemplo de Armadilha Diagonal" />

  Y este ejemplo muestra una <a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a> en la extremidad del <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>:

  <img class="block" src="/Resources/Images/DiagonalTrap1.png" alt="Exemplo de Armadilha Diagonal" />
    
    Se debe tener siempre mucho cuidado en tener <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> con <a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a> en una extremidade de <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>.
    Más allá  que pierden el 50% de mobilidad, quedan mucho mas abiertas a una <a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a>.
    
    <h2>Como combatir una Trampa Diagonal?</h2>
    La mejor forma es evitar por completo caer en la <a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a>. A pesar de esto , si el adversário consigue aplicar 
    la Trampa, la única forma es con outras <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> destruir las unidades que compnen la Trampa.
  </div>

</asp:Content>