<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Contraataque
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Contraataque</h1>
	<div class="content">
    <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> es un ataque que es bueno de tener pero no es fundamental para ganar una batalla. Lo que sucede es que cuando un grupo de
    <a href='/es/UnitIndex.aspx'>Unidades</a> con esta habilidad es atacado las <a href='/es/UnitIndex.aspx'>Unidades</a> que sobreviven atacan automáticamente sin que el jugador lo indique o incluso gaste
    movimientos de ataque.<p />
 Pero este ataque tiene algunas limitaciones , como que todos los ataque son posibles de ser contraatacados, las siguientes imágenes
 ayudan a entender esas limitaciones:

    <div class="block"><img style="margin-right:90px" src="/Resources/Images/strikeBack1.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack4.png" alt="Strike Back" /></div><br /><div class="block"><img style="margin-right:34px" src="/Resources/Images/strikeBack3.png" alt="Strike Back" /><img src="/Resources/Images/strikeBack2.png" alt="Strike Back" /></div><br />
 Las <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> son unidades que tienen la habilidad de <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> , en todos los ejemplos se efectuarán ataques a las <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a>.
 En la primera imágen las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> no van a contratacar porque están siendo atacadas por unidades <a class='spider' href='/es/Unit/Spider.aspx'>Araña</a> que tienen la habilidad de <a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a>,
 por lo que las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> son paralizadas no efectuando un <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a>.<p />

 En la segunda imágen las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a>  están siendo atacadas por unidades <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a>, pero como las unidades <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a> tienen unidades <a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a> en frente atacando 
 con la habilidad <a href='/es/Battles/Catapult.aspx'>Catapulta</a>, las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> no logran alcanzar las unidades <a class='eagle' href='/es/Unit/Eagle.aspx'>Aguila</a> con un <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> porque tienes unidades <a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a> 
    en el camino.<p />

 El tercer ataque también no provoca <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> porque las unidades <a class='kamikaze' href='/es/Unit/Kamikaze.aspx'>Suicida</a> no están atacando de manera frontal a las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a>.<p />

 Finalmente, el cuarto ataque es el único que va a provocar <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> porque las unidades <a class='raptor' href='/es/Unit/Raptor.aspx'>Raptor</a> están atacando de manera frontal a las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> 
 las cuales no tienen ninguna habilidad que evite un <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a>.<p />

 Aún  existen otras dos situaciones en que <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> no es activado. En el caso que una unidad con habilidad <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> no tenga <a href='/es/Battles/Range.aspx'>Alcance</a> suficiente 
 para responder al ataque. Por ejemplo sí las unidades <a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a> fuesen atacadas a 5 de distancia por <a class='nova' href='/es/Unit/Nova.aspx'>Nova</a> no logran responder al ataque porque solo tienen
    <a href='/es/Battles/Range.aspx'>Alcance</a> de 3. La última situación en que un <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> no es activado, se dá cuando una unidad (ej:<a class='pretorian' href='/es/Unit/Pretorian.aspx'>Pretoriana</a>) con la habilidad de <a href='/es/Battles/StrikeBack.aspx'>Contraataque</a> 
 es alcanzada con <a href='/es/Battles/Rebound.aspx'>Rebote</a>.
  </div>
	
</asp:Content>