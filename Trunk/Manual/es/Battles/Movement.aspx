<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Movimiento
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Movimientos en la Batalla</h1>
<div class="content">
    Los movimientos se refieren al acto de mover <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a> posterior a la fase de <a href='/es/Battles/Deploy.aspx'>Posicionar</a>.
    Cada unidad de combate tiene un tipo de movimiento específico, los cuales pueden ser :
    <ul><li><a href='/es/Battles/Movement.aspx#MovAll'>Movimiento Total</a></li><li><a href='/es/Battles/Movement.aspx#MovNormal'>Movimiento Normal</a></li><li><a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a></li><li><a href='/es/Battles/Movement.aspx#MovFront'>Movimiento Frontal</a></li><li><a href='/es/Battles/Movement.aspx#MovDrop'>Movimento Paracaidas</a></li><li><a href='/es/Battles/Movement.aspx#MovNone'>Sin Movimiento</a></li></ul>
    En conjunto al tipo de movimiento está el <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a>. Estas dos características definen la velocidad de una unidade.

    <a name="MovAll" id="MovAll"></a><h2><a href='/es/Battles/Movement.aspx#MovAll'>Movimiento Total</a></h2>
    Con el <a href='/es/Battles/Movement.aspx#MovAll'>Movimiento Total</a> una unidad se puede mover para cualquier cuadrícula adjacente. Ejemplo:
    <img class="block" src="/Resources/Images/MovAll.png" alt="Mov All" /><a name="MovNormal" id="MovNormal"></a><h2><a href='/es/Battles/Movement.aspx#MovNormal'>Movimiento Normal</a></h2>
    Con el <a href='/es/Battles/Movement.aspx#MovNormal'>Movimiento Normal</a> una unidad se puede mover para cualquier cuadrícula adjacente, excepto hacía las diagonales. Ejemplo:
    <img class="block" src="/Resources/Images/MovNormal.png" alt="Mov Normal" /><a name="MovDiagonal" id="MovDiagonal"></a><h2><a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a></h2>
    Con el <a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a> una unidad sólo se puede mover para una diagonal (cuidado con la <a href='/es/Battles/DiagonalTrap.aspx'>Trampa Diagonal</a>). Ejemplo:
    <img class="block" src="/Resources/Images/MovDiagonal.png" alt="Mov Diagonal" /><a name="MovFront" id="MovFront"></a><h2><a href='/es/Battles/Movement.aspx#MovFront'>Movimiento Frontal</a></h2>
    Con el <a href='/es/Battles/Movement.aspx#MovFront'>Movimiento Frontal</a> una unidad sólo se puede mover hacia adelante. Se necesita cambiar de dirección , tendrá que usar
    una rotación. Ejemplo:
    <img class="block" src="/Resources/Images/MovFront.png" alt="Mov Front" /><a name="MovDrop" id="MovDrop"></a><h2><a href='/es/Battles/Movement.aspx#MovDrop'>Movimento Paracaidas</a></h2>
    Una unidad con <a href='/es/Battles/Movement.aspx#MovDrop'>Movimento Paracaidas</a> es capaz de introducir otra unidad de combate en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>.
    Por ejemplo: una <a class='queen' href='/es/Unit/Queen.aspx'>Reina</a> es capaz de  hacer crecer un <a class='egg' href='/es/Unit/Egg.aspx'>Huevo</a> en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>.

    <a name="MovNone" id="MovNone"></a><h2><a href='/es/Battles/Movement.aspx#MovNone'>Sin Movimiento</a></h2>
    Una unidad <a href='/es/Battles/Movement.aspx#MovNone'>Sin Movimiento</a> está fija y no se puede mover. Ejemplo:
    <img class="block" src="/Resources/Images/MovNone.png" alt="Mov Nove" /><a name="MovCost" id="MovCost"></a><h2><a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a></h2>
    El tipo de <a href='/es/Battles/Movement.aspx'>Movimiento</a> influye como es que la unidad se mueve. Pero todas las <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> tienen un <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a>
    que influyen en cuan rápidas serán. En cada turno de uma batalla, un jugador tiene 6 puntos de movimientos
    para gastar: puede mover unidades, puede atacar o puede no gastarlos.
    <p />
    Si una unidad tiene un <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a> de 2, eso quiere decir que podemos moverla 3 veces en un turno (6/2=3). vemos
    por ejemplo la <a class='doomer' href='/es/Unit/Doomer.aspx'>Aniquiladora</a> y la <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>. Ambas tienen <a href='/es/Battles/Movement.aspx#MovDiagonal'>Movimiento Diagonal</a>, pero la <a class='doomer' href='/es/Unit/Doomer.aspx'>Aniquiladora</a> tiene un costo 3 y la <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>
    custo 2, lo que hace que la <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a> sea más rápida.

    <a name="MovPoints" id="MovPoints"></a><h2><a href='/es/Battles/Movement.aspx#MovPoints'>Puntos de Movimiento</a></h2>
    Los <a href='/es/Battles/Movement.aspx#MovPoints'>Puntos de Movimiento</a> representan el total de acciones que pueden ser realizadas en un turno de batalla. En cada turno
    están Disponibles seis <a href='/es/Battles/Movement.aspx#MovPoints'>Puntos de Movimiento</a> para gastar, y cada acción disponible tiene su costo:
    <ul><li>Atacar cuesta 1 punto</li><li>
    Mover una unidade de combate tendrá el costo asociado a esa unidad. Todas las <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>
    tienen un <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a> definido
  </li><li>Separar un grupo de unidades, cuesta el doble de <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a> de esa unidad</li></ul></div>
	
</asp:Content>