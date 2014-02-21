<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ataque Venenoso
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Ataque Venenoso</h1>
	<div class="content">
    El ataque <a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a> es como envenenar una unidad enemiga. Si la unidad fuera alcanzada por un ataque <a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a>, va a recibir un determinado daño 
    durante 3 turnos ( dentro de estos 3 turnos esta incluído el turno de ataque)    
    <p />
    El valor del daño es equivalente al 20% del daño echo por la unidad que ataca. Si la unidad dio 1000 de daño, entonces en el primer turno (turno de ataque) la unidad enemiga    
    recibira 1200 y en los 2 turnos siguiente recibirá 200 de daño por turno.
    <p />
    Esta ataque es acumulativo lo que significa que la unidad objetivo podrá tener várias infecciones al mismo tiempo.
    <p />
    Esta ataque es usado por la unidad <a class='blackwidow' href='/es/Unit/BlackWidow.aspx'>Viuda Negra</a> y <a class='hiveking' href='/es/Unit/HiveKing.aspx'>Rey de la Colmena</a>.
    <p />
    La siguiente imagén representa un ataque de <a class='hiveking' href='/es/Unit/HiveKing.aspx'>Rey de la Colmena</a> usando <a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a> contra <a class='scarab' href='/es/Unit/Scarab.aspx'>Escarabajo</a>:
    <img class="block" src="/Resources/Images/Infestation.png" alt="Ataque Infestação" /></div>
	
</asp:Content>