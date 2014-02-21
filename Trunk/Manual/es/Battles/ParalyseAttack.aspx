<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Paralizador
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Paralizador</h1>
	<div class="content">
    <a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a> es un ataque muy poderoso. Una única unidad con este poder puede prevenir la utilización de cualquier grupo de unidades ([Attack]
    y <a href='/es/Battles/Movement.aspx'>Movimiento</a>) durante 1 turno de batalla. Este ataque puede ser muy útil para bloquear unidades importantes y/o destruir las lentamente, o prevenir
    el paso de otras unidades.
    <p />
    Cuidado que en tu turno las unidades ya no estarán paralizadas. Por lo tanto si las quisieras atacar (especialmente unidades con 
    <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> a [ParalyseAttack] - como <a class='spider' href='/es/Unit/Spider.aspx'>Araña</a>) no te olvides de paralizar primero y/o atacar por los lados, o por atrás. 
    <p />
    Aquí puedes ver una imágen de <a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a> cuando una <a class='spider' href='/es/Unit/Spider.aspx'>Araña</a> ataca una <a class='doomer' href='/es/Unit/Doomer.aspx'>Aniquiladora</a>:
    <img class="block" src="/Resources/Images/Paralyse.png" alt="Ataque paralizante" /></div>
</asp:Content>