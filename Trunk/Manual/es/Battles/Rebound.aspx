<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Rebote
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Rebote</h1>
	<div class="content">
 <a href='/es/Battles/Rebound.aspx'>Rebote</a> es el caso en que la fuerza de ataque no es desperdiciada, ya que si fuera demasiado para destruir el primer conjunto de <a href='/es/UnitIndex.aspx'>Unidades</a>, 
 la fuerza restante es traspasada al conjunto de <a href='/es/UnitIndex.aspx'>Unidades</a> que esté atrás del conjunto de <a href='/es/UnitIndex.aspx'>Unidades</a> atacadas.<p /><img class="block" src="/Resources/Images/Rebound.png" alt="Ricochete" />
 
 En esta imágen se puede ver <a class='fenix' href='/es/Unit/Fenix.aspx'>Fénix</a> atacando <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a>, imagina que el ataque de las unidades <a class='fenix' href='/es/Unit/Fenix.aspx'>Fénix</a> es de 10000 y la defensa de las
 unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> es de solo 8000, entonces las unidades <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> sufrirían un daño de  2000 (10000 - 8000 = 2000). Pero sí, las unidades <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> 
 no estuviesen detrás  de las <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> no sufrirían daño alguno, basta con que exista un cuadraro entre las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> y <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a>.

  </div>
	
</asp:Content>