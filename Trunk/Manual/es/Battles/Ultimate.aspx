<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Suprema
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Unidades Supremas</h1>
<div class="content">
    Una unidad <a href='/es/Battles/Ultimate.aspx'>Suprema</a> es la unidad de combate mas poderosa de cada raza. Estas unidades son especiales en la
    medidada en que no están presentes en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>. Aún así pueden ser atacadas.
    <p />
    Cada unidad <a href='/es/Battles/Ultimate.aspx'>Suprema</a> tiene poderes muy especiais, que hacen que sean muy importantes en una batalla.
    <p />
    Lista de unidades de supremas:
  </div>
	<ul class='imageList'><li><a href='/es/Unit/Queen.aspx'><img class='queen' src='http://resources.orionsbelt.eu/Images/Common/Units/queen.png' alt='Reina' /></a></li><li><a href='/es/Unit/Blinker.aspx'><img class='blinker' src='http://resources.orionsbelt.eu/Images/Common/Units/blinker.png' alt='Parpadeante' /></a></li><li><a href='/es/Unit/BattleMoon.aspx'><img class='battlemoon' src='http://resources.orionsbelt.eu/Images/Common/Units/battlemoon.png' alt='Luna de Batalla' /></a></li></ul>
	
</asp:Content>