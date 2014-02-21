<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Bomba
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Bomba</h1>
	<div class="content">
 Un <a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a> puede ser el ataque mas poderoso del juego, si es usado de forma correcta. Una unidad de combate
 con <a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a> genera daño en todas las unidades adversárias que estuvieran encima del ataque.
 Esta habilidad es excelente para combatir las <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a> del adversário, o como arma para dañar a un
 gran número de grupos de unidades.
    <p />
    Aquí está el ejemplo de un <a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a>:

    <img class="block" src="/Resources/Images/Bomb.png" alt="Bomb Attack" />

    En este ejemplo, el daño al objetivo, será también sobre todas las unidades adversárias de encima , o sea,
    todos los grupos de <a class='rain' href='/es/Unit/Rain.aspx'>Lluvia</a> serán destruidos. No existe cualquier atenuación de daños.

  </div>
	
</asp:Content>