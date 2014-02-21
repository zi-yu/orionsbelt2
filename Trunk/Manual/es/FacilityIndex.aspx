<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edificios
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Edificios</h1><table class='table'><tr><th><a href='/es/Race/LightHumans.aspx'>Utopianos</a></td><th><a href='/es/Race/DarkHumans.aspx'>Renegados</a></td><th><a href='/es/Race/Bugs.aspx'>Levyr</a></td></tr><tr><td><ul><li><a href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a></li><li><a href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a></li><li><a href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/es/Facility/SolarPanel.aspx'>Panel Solar</a></li><li><a href='/es/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/es/Facility/Silo.aspx'>Bodega</a></li><li><a href='/es/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a></li></td></ul><td><ul><li><a href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a></li><li><a href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a></li><li><a href='/es/Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a></li><li><a href='/es/Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a></li><li><a href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li><a href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a></li><li><a href='/es/Facility/Devastation.aspx'>Devastación</a></li><li><a href='/es/Facility/NuclearFacility.aspx'>Extractor de Uranio</a></li></td></ul><td><ul><li><a href='/es/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/es/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a></li><li><a href='/es/Facility/Incubator.aspx'>Encubadora</a></li><li><a href='/es/Facility/Nest.aspx'>Nido</a></li><li><a href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a></li></td></ul></tr></table>
	
	<div class="content">
		<h2>Edifício Principal</h2>
<p>
    Cada raza tiene un edifício principal, que es usado para definir el nível del jogador. Los edifícios principales
    son los siguientes:
    <ul><li><a class='commandcenter' href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a> para los <a href='/es/Race/LightHumans.aspx'>Utopianos</a></li><li><a class='darknesshall' href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a> para los <a href='/es/Race/DarkHumans.aspx'>Renegados</a></li><li><a class='nest' href='/es/Facility/Nest.aspx'>Nido</a> para los <a href='/es/Race/Bugs.aspx'>Levyr</a></li></ul></p>
<h2>Obtención de Recursos</h2>
<p>
    Para evolucionar tus edifícios y construir <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> son necesarios recursos <a href='/es/IntrinsicIndex.aspx'>Intrínsicos</a>. Estos recursos
    pueden ser obtenidos en los planetas de tu <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> a través de edifícios extractores.
  </p>
<h2>Construcción de Unidades</h2>
<p>
    Es necesario un edifício especial para construir <a href='/es/UnitIndex.aspx'>Unidades de Combate</a>. Cada raza tien su edifício, y estos edifícios
    tienen 10 niveles, y cada nível desbloquea <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> diferentes. Los edifícios que provisionan unidades son:
    <ul><li><a class='unityard' href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a> para los <a href='/es/Race/LightHumans.aspx'>Utopianos</a></li><li><a class='dominationyard' href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a> para los <a href='/es/Race/DarkHumans.aspx'>Renegados</a></li><li><a class='incubator' href='/es/Facility/Incubator.aspx'>Encubadora</a> para los <a href='/es/Race/Bugs.aspx'>Levyr</a></li></ul>
    Nota que para construir unidades es necesario que el planeta tenga su edifício activo
    (o sea, sin estar en construcción o evolución).
  </p>
<h3>Construcción de Unidades Supremas</h3>
<p>
    Para cada raza está disponible uma unidad suprema. Estas unidades son muy caras y sólo pueden ser obtenidas
    en un nivel mas avanzado. Lo que distingue estas unidades es que elas son posicionadas fuera del
    <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a> y tienen capacidades muy importantes:
    <ul><li>
    Los <a href='/es/Race/LightHumans.aspx'>Utopianos</a> pueden construir el <a class='blinker' href='/es/Unit/Blinker.aspx'>Parpadeante</a> en la <a class='blinkerassembler' href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a>. Los <a class='blinker' href='/es/Unit/Blinker.aspx'>Parpadeante</a> pueden
    mover arbritariamente unidades (tuyas o del adversário) en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a>.
  </li><li>
    Los <a href='/es/Race/DarkHumans.aspx'>Renegados</a> pueden construir la <a class='battlemoon' href='/es/Unit/BattleMoon.aspx'>Luna de Batalla</a> en el <a class='battlemoonassembler' href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a>. La <a class='battlemoon' href='/es/Unit/BattleMoon.aspx'>Luna de Batalla</a> consigue
    disparar sobre cualquier adversário hasta un alcance determinado.
  </li><li>
    Los <a href='/es/Race/Bugs.aspx'>Levyr</a> pueden construir la <a class='queen' href='/es/Unit/Queen.aspx'>Reina</a> en la <a class='queenhatchery' href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a>. La <a class='queen' href='/es/Unit/Queen.aspx'>Reina</a> consigue poner huevos
    en el <a href='/es/Battles/GameBoard.aspx'>Tablero de Juego</a> de donde nace la <a class='maggot' href='/es/Unit/Maggot.aspx'>Larva</a>.
  </li></ul></p>
<h2>Nível de Planeta y Nível de Edifícios</h2>
<p>
    Cada planeta tem dos niveles diferentes que influyen en los edifícios que pueden ser Construidos.
    El <u>Nível de Planeta</u> reflaja el <a href='/es/Universe/HotZone.aspx#levels'>Nível de Zona</a>, y el
    <u>Nível de Edifício</u> indica el nivel de evolución del planeta. En los planetas de la <a href='/es/Universe/PrivateZone.aspx'>Zona Privada</a> es
    usado el edifício madre para encontrar el nivel, mientras que en la  <a href='/es/Universe/HotZone.aspx'>Zona Pública</a> es usado el nivel del <a class='extractor' href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a>.
  </p>
	</div>
	
</asp:Content>