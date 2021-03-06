﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Posicionar
	
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Posicionar</h1>
	<div class="content">
    <a href='/es/Battles/Deploy.aspx'>Posicionar</a> es la primera tarea que un jugador tiene que hacer al inicio de una batalla. Cada jugador comienza con un determinado número de unidades las quales tien que ser  colocadas en cualquiera de las 16 cuadriculas iniciales(ver imágen abajo)
    <p /><img class="block" src="/Resources/Images/DeployArea.png" alt="Area de Posicionamento" /><p />
    En la fase de <a href='/es/Battles/Deploy.aspx'>Posicionar</a> no existen <a href='/es/Battles/Movement.aspx#MovPoints'>Puntos de Movimiento</a>  para gastar y el tipo de <a href='/es/Battles/Movement.aspx'>Movimiento</a> no es tomado en cuenta. Puedes ingresar todas las unidades donde desees y separarlas a tu  gusto.
    <p />
    En las batallas entre 4 jugadores se aplican las mismas reglas. El área para posicionar las unidades es equivalente (ver figura abaixo).
    <p /><img class="block" style="width:510px;" src="/Resources/Images/DeployArea4.png" alt="Area de posicionamento para uma batalha de 4 jogadores" /><p />
    La battal solo comienza cuando todos los jugadores tuvieran en posición sus unidades. Cuando estas en la fase de posicionamiento no podrás ver las unidades de los  adversários. Esas unidades sólo serán visibles cuando la batalla comienza.
    <p />
    Abajo está un video de demostración de como  posicionar las unidades:
    <p /></div>
</asp:Content>