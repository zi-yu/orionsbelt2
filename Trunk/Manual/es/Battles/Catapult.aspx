<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Catapulta
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><h1>Ataque Catapulta</h1>
<div class="content">
 Probablemente el ataque <a href='/es/Battles/Catapult.aspx'>Catapulta</a> es el mas imparable de todos los ataques, esto porque aún  teniendo <a href='/es/UnitIndex.aspx'>Unidades</a> que 
    sirvan de <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a>, para este caso ellas son inutiles. <p />

    <a href='/es/Battles/Catapult.aspx'>Catapulta</a> ignora cualquier unidad que esté en frente, sea enemiga o del mismo equipo  <a href='/es/Universe/Fleet.aspx'>Flota</a>, y da la pobilidad de 
 cualquier unidad enemiga que tenga el <a href='/es/Battles/Range.aspx'>Alcance</a> de la unidad que vá a efectuar el disparo. Un ejemplo de esta situación
 es la siguiente imágen:

    <img class="block" src="/Resources/Images/Catapult.png" alt="Catapulta" />

 Este ataque es perfecto para realizar ataques quirurgícos detrás de una barrera defensiva.<p />
 Otro factor que torna este ataque bastante interesante, es que el <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> de la unidad atacada será ignorado en caso
 que la unidad que efectua el disparo tuviera una unidad entre sí y la unidad atacada. 
  </div></h1>
	
</asp:Content>