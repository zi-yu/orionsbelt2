<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Pequeño Porte
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Conceptos de Batalla</h2><ul><li><a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a></li><li><a href='/es/Battles/Deploy.aspx'>Posicionar</a></li><li><a href='/es/Battles/Movement.aspx'>Movimiento</a></li><li><a href='/es/Battles/Rules.aspx'>Rules</a></li></ul><h2>Ataque</h2><ul><li><a href='/es/Battles/Range.aspx'>Alcance</a></li><li><a href='/es/Battles/Catapult.aspx'>Catapulta</a></li><li><a href='/es/Battles/ParalyseAttack.aspx'>Ataque Paralizador</a></li><li><a href='/es/Battles/Replicator.aspx'>Replicador</a></li><li><a href='/es/Battles/StrikeBack.aspx'>Contraataque</a></li><li><a href='/es/Battles/InfestationAttack.aspx'>Ataque Venenoso</a></li><li><a href='/es/Battles/RemoveAbilityAttack.aspx'>Remover Habilidad</a></li><li><a href='/es/Battles/TripleAttack.aspx'>Ataque Triple</a></li><li><a href='/es/Battles/BombAttack.aspx'>Ataque Bomba</a></li><li><a href='/es/Battles/Rebound.aspx'>Rebote</a></li></ul><h2>Categoría</h2><ul><li><a href='/es/Battles/Light.aspx'>Pequeño Porte</a></li><li><a href='/es/Battles/Medium.aspx'>Médio Porte</a></li><li><a href='/es/Battles/Heavy.aspx'>Gran Porte</a></li><li><a href='/es/Battles/Ultimate.aspx'>Suprema</a></li><li><a href='/es/Battles/Special.aspx'>Especial</a></li></ul><h2>Tipo de Batalla</h2><ul><li><a href='/es/Battles/TotalAnnihilation.aspx'>Destrucción Total</a></li><li><a href='/es/Battles/Regicide.aspx'>Regicidio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Unidades de Porte Pequeño </h1>
<div class="content">
    Las unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> son categorizadas como las mas rápidas y mas frágiles del juego. Una unidad de
    <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> típica tiene <a href='/es/Battles/Movement.aspx#MovAll'>Movimiento Total</a> y <a href='/es/Battles/Movement.aspx#MovCost'>Costo de Movimiento</a> de 1, mas allá de ser mas barata que las <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> de <a href='/es/Battles/Medium.aspx'>Médio Porte</a>
    y <a href='/es/Battles/Heavy.aspx'>Gran Porte</a>.
    <p />
    Cualquier <a href='/es/Universe/Fleet.aspx'>Flota</a> equilibrada tiene un porcentaje sustancial de unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a>, esto porque ellas son
    indispensables como <a href='/es/Battles/DispensableUnits.aspx'>Carne de Cañon</a>, una de las <a href='/es/Battles/BattleTactics.aspx'>Tácticas de Batalla</a> mas usadas en el <a href='http://www.orionsbelt.eu'>Orion's Belt</a>.
    <p />
    Pero las unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a> no son usadas solamente para ser sacrificadas. Existen unidades muy poderosas
    que imponem respeto a unidades de mayor envergadura.
    <p />
    Lista de unidades de <a href='/es/Battles/Light.aspx'>Pequeño Porte</a>:
  </div>
	<ul class='imageList'><li><a href='/es/Unit/Raptor.aspx'><img class='raptor' src='http://resources.orionsbelt.eu/Images/Common/Units/raptor.png' alt='Raptor' /></a></li><li><a href='/es/Unit/Rain.aspx'><img class='rain' src='http://resources.orionsbelt.eu/Images/Common/Units/rain.png' alt='Lluvia' /></a></li><li><a href='/es/Unit/Cypher.aspx'><img class='cypher' src='http://resources.orionsbelt.eu/Images/Common/Units/cypher.png' alt='Cypher' /></a></li><li><a href='/es/Unit/Reaper.aspx'><img class='reaper' src='http://resources.orionsbelt.eu/Images/Common/Units/reaper.png' alt='Reaper' /></a></li><li><a href='/es/Unit/Panther.aspx'><img class='panther' src='http://resources.orionsbelt.eu/Images/Common/Units/panther.png' alt='Pantera' /></a></li><li><a href='/es/Unit/Seeker.aspx'><img class='seeker' src='http://resources.orionsbelt.eu/Images/Common/Units/seeker.png' alt='Buscador' /></a></li><li><a href='/es/Unit/Egg.aspx'><img class='egg' src='http://resources.orionsbelt.eu/Images/Common/Units/egg.png' alt='Huevo' /></a></li><li><a href='/es/Unit/Maggot.aspx'><img class='maggot' src='http://resources.orionsbelt.eu/Images/Common/Units/maggot.png' alt='Larva' /></a></li><li><a href='/es/Unit/DarkRain.aspx'><img class='darkrain' src='http://resources.orionsbelt.eu/Images/Common/Units/darkrain.png' alt='Lluvia Sombría' /></a></li><li><a href='/es/Unit/Toxic.aspx'><img class='toxic' src='http://resources.orionsbelt.eu/Images/Common/Units/toxic.png' alt='Toxico' /></a></li><li><a href='/es/Unit/Anubis.aspx'><img class='anubis' src='http://resources.orionsbelt.eu/Images/Common/Units/anubis.png' alt='Anubis' /></a></li><li><a href='/es/Unit/Jumper.aspx'><img class='jumper' src='http://resources.orionsbelt.eu/Images/Common/Units/jumper.png' alt='Jumper' /></a></li><li><a href='/es/Unit/Samurai.aspx'><img class='samurai' src='http://resources.orionsbelt.eu/Images/Common/Units/samurai.png' alt='Samurai' /></a></li><li><a href='/es/Unit/Interceptor.aspx'><img class='interceptor' src='http://resources.orionsbelt.eu/Images/Common/Units/interceptor.png' alt='Interceptador' /></a></li><li><a href='/es/Unit/Sentry.aspx'><img class='sentry' src='http://resources.orionsbelt.eu/Images/Common/Units/sentry.png' alt='Sentry' /></a></li></ul>
	
</asp:Content>