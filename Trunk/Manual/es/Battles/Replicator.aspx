<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Replicador
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Replicador</h1>
	<div class="content">
    El <a href='/es/Battles/Replicator.aspx'>Replicador</a> es un ataque que puede cambiar los números de la batalla. Cuando una unidad use este ataque especial , ella se replica un determinado número de veces, equivalente al número de unidades 
    destruídas. Si destruyes 6 unidades, la unidad con <a href='/es/Battles/Replicator.aspx'>Replicador</a> se replica 6 veces.    
    <p />
    Este ataque especial sólo funciona si fueran atacadas unidades de la misma categoría o superior. Ejemplo: Una unidad <a href='/es/Battles/Medium.aspx'>Médio Porte</a> con <a href='/es/Battles/Replicator.aspx'>Replicador</a> sólo se replica si el objetivo
    fuera de la [Category]  <a href='/es/Battles/Medium.aspx'>Médio Porte</a> o <a href='/es/Battles/Heavy.aspx'>Gran Porte</a>.
    <p />
    La única de juego que posee este ataque es la <a class='stinger' href='/es/Unit/Stinger.aspx'>Aguijón</a>. Lo qué significa que esta unidad sólo se replica contra unidades <a href='/es/Battles/Medium.aspx'>Médio Porte</a> y <a href='/es/Battles/Heavy.aspx'>Gran Porte</a>.
   </div>
</asp:Content>