<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Triple
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Triple</h1>
	<div class="content">
  <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a> Es un ataque devastador que es capaz de destruir hasta tres grupos de unidades  con solo un ataque. 
 Cuando se ataca con una unidad que tiene <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a> , las unidades encima al objetivo recibiran un <b>50%</b>
 del daño recibido por el objetivo.

    <p />
 Este tipo de ataque es ideal para destruir <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> del adversário, y también para llegar a los <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>
    protegidas contra ataques directos. Un ejemplo de este ataque sería:
    <img class="block" src="/Resources/Images/Triple1.png" alt="Triple Attack" />
 Todos los grupos de <a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a> del adversário serán descruidos por <a class='driller' href='/es/Unit/Driller.aspx'>Perforador</a>. Esto porque <a class='driller' href='/es/Unit/Driller.aspx'>Perforador</a> tiene <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a> 
 y porque los grupos de <a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a> están en las posiciones encima del objetivo y perpendiculares al <a class='driller' href='/es/Unit/Driller.aspx'>Perforador</a>.
    <p />
 Las <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> con <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a> son también capaces de llegar a los <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> del adversário.
 A modo de ejemplo, este grupo de <a class='fenix' href='/es/Unit/Fenix.aspx'>Fénix</a> del adversário están bien protegidas por <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> los que 
 impiden un ataque directo. A pesar de esto un <a class='driller' href='/es/Unit/Driller.aspx'>Perforador</a> consigue rodear la muralla defensiva y dañar el grupo
 de <a class='fenix' href='/es/Unit/Fenix.aspx'>Fénix</a> a través de su <a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a>:
 
    <img class="block" src="/Resources/Images/Triple2.png" alt="Triple Attack" /></div>
	
</asp:Content>