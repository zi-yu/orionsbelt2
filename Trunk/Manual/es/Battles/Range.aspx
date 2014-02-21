<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Alcance
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Alcance de las Unidades de Combate</h1>
<div class="content">
    El <a href='/es/Battles/Range.aspx'>Alcance</a> define la distancia de ataque de una unidad. Todas las unidades pueden atacar, y algunas hasta tienen
    poderes de ataque especiales. 
    <p />
    El siguiente ejemplo muestra las diferencias de <a href='/es/Battles/Range.aspx'>Alcance</a> entre dos <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>: el <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> y la <a class='krill' href='/es/Unit/Krill.aspx'>Krill</a>.
    El <a class='crusader' href='/es/Unit/Crusader.aspx'>Cruzador</a> tiene <a href='/es/Battles/Range.aspx'>Alcance</a> de 6, y por eso logra alcanzar practicamente toda la columna en que está.
    Por otro lado, la <a class='krill' href='/es/Unit/Krill.aspx'>Krill</a> sólo tiene <a href='/es/Battles/Range.aspx'>Alcance</a> de 3, por lo que sólo logra alcanzar unidades a 3 de distância.
    <p />
    Nota que si hubiera una unidad entre el atacante y el blanco, el ataque no es posible, a menos que el
    atacante tenga <a href='/es/Battles/Catapult.aspx'>Catapulta</a>.
    
    <img class="block" src="/Resources/Images/Range.png" alt="Mov Nove" /></div>
	
</asp:Content>