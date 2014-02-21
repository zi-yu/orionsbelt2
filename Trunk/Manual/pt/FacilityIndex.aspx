<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifícios
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Edifícios</h1><table class='table'><tr><th><a href='/pt/Race/LightHumans.aspx'>Utopianos</a></td><th><a href='/pt/Race/DarkHumans.aspx'>Renegados</a></td><th><a href='/pt/Race/Bugs.aspx'>Levyr</a></td></tr><tr><td><ul><li><a href='/pt/Facility/DeepSpaceScanner.aspx'>Radar de Longo Alcance</a></li><li><a href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a></li><li><a href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/pt/Facility/SolarPanel.aspx'>Painel Solar</a></li><li><a href='/pt/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/pt/Facility/Silo.aspx'>Armazém</a></li><li><a href='/pt/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a></li></td></ul><td><ul><li><a href='/pt/Facility/SlaveWarehouse.aspx'>Poço da Escravatura</a></li><li><a href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a></li><li><a href='/pt/Facility/TitaniumExtractor.aspx'>Extractor de Titânio</a></li><li><a href='/pt/Facility/DevotionSanctuary.aspx'>Santuário de Devoção</a></li><li><a href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a></li><li><a href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a></li><li><a href='/pt/Facility/Devastation.aspx'>Devastação</a></li><li><a href='/pt/Facility/NuclearFacility.aspx'>Extractor de Urânio</a></li></td></ul><td><ul><li><a href='/pt/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/pt/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a></li><li><a href='/pt/Facility/Incubator.aspx'>Incubadora</a></li><li><a href='/pt/Facility/Nest.aspx'>Ninho</a></li><li><a href='/pt/Facility/WormHoleCreator.aspx'>Gerador de Túneis Espaciais</a></li></td></ul></tr></table>
	
	<div class="content">
		<h2>Edifício Principal</h2>
<p>
    Cada raça tem um edifício principal, que é usado para definir o nível do jogador. Os edifícios principais
    são os seguintes:
    <ul><li><a class='commandcenter' href='/pt/Facility/CommandCenter.aspx'>Centro de Comando</a> para os <a href='/pt/Race/LightHumans.aspx'>Utopianos</a></li><li><a class='darknesshall' href='/pt/Facility/DarknessHall.aspx'>Capital da Escuridão</a> para os <a href='/pt/Race/DarkHumans.aspx'>Renegados</a></li><li><a class='nest' href='/pt/Facility/Nest.aspx'>Ninho</a> para os <a href='/pt/Race/Bugs.aspx'>Levyr</a></li></ul></p>
<h2>Obtenção de Recursos</h2>
<p>
    Para evoluir os teus edifícios e construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> são precisos recursos <a href='/pt/IntrinsicIndex.aspx'>Intrínsecos</a>. Estes recursos
    podem ser obtidos nos planetas da tua <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> através de edifícios extractores.
  </p>
<h2>Construcção de Unidades</h2>
<p>
    É preciso um edifício especial para construir <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a>. Cada raça tem o seu edifício e estes edifícios
    têm 10 níveis, sendo que cada nível desbloqueia <a href='/pt/UnitIndex.aspx'>Unidades de Combate</a> diferentes. Os edifícios que providenciam
    unidades são:
    <ul><li><a class='unityard' href='/pt/Facility/UnitYard.aspx'>Porto Espacial</a> para os <a href='/pt/Race/LightHumans.aspx'>Utopianos</a></li><li><a class='dominationyard' href='/pt/Facility/DominationYard.aspx'>Hangar do Domínio</a> para os <a href='/pt/Race/DarkHumans.aspx'>Renegados</a></li><li><a class='incubator' href='/pt/Facility/Incubator.aspx'>Incubadora</a> para os <a href='/pt/Race/Bugs.aspx'>Levyr</a></li></ul>
    Nota que para construir unidades é preciso o planeta ter o edifício activo
    (ou seja, sem estar em construção ou evolução).
  </p>
<h3>Construcção de Unidades Supremas</h3>
<p>
    Está disponível para cada raça uma unidade suprema. Estas unidades são muito caras e só podem ser obtidas
    num nível mais avançado. O que distingue estas unidades é que elas são posicionadas fora do
    <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a> e têm capacidades muito importantes:
    <ul><li>
    Os <a href='/pt/Race/LightHumans.aspx'>Utopianos</a> podem construir o <a class='blinker' href='/pt/Unit/Blinker.aspx'>Pisca-pisca</a> na <a class='blinkerassembler' href='/pt/Facility/BlinkerAssembler.aspx'>Fábrica de Pisca-piscas</a>. O <a class='blinker' href='/pt/Unit/Blinker.aspx'>Pisca-pisca</a> pode
    mover arbritariamente unidades (tuas ou do adversário) no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a>.
  </li><li>
    Os <a href='/pt/Race/DarkHumans.aspx'>Renegados</a> podem construir a <a class='battlemoon' href='/pt/Unit/BattleMoon.aspx'>Lua de Batalha</a> no <a class='battlemoonassembler' href='/pt/Facility/BattleMoonAssembler.aspx'>Fábrica de Luas de Combate</a>. A <a class='battlemoon' href='/pt/Unit/BattleMoon.aspx'>Lua de Batalha</a> consegue
    disparar sob qualquer adversário até um determinado alcance.
  </li><li>
    Os <a href='/pt/Race/Bugs.aspx'>Levyr</a> podem construir a <a class='queen' href='/pt/Unit/Queen.aspx'>Rainha</a> na <a class='queenhatchery' href='/pt/Facility/QueenHatchery.aspx'>Incubadora de Rainhas</a>. A <a class='queen' href='/pt/Unit/Queen.aspx'>Rainha</a> consegue
    pôr ovos no <a href='/pt/Battles/GameBoard.aspx'>Tabuleiro de Jogo</a> de onde nasce a <a class='maggot' href='/pt/Unit/Maggot.aspx'>Larva</a>.
  </li></ul></p>
<h2>Nível de Planeta e Nível de Edifícios</h2>
<p>
    Cada planeta tem dois níveis diferentes que influenciam os edifícios que podem ser construídos.
    O <u>Nível de Planeta</u> reflecte o <a href='/pt/Universe/HotZone.aspx#levels'>Nível de Zona</a>, e o
    <u>Nível de Edifício</u> indica o nível de evolução do planeta. Nos planetas da <a href='/pt/Universe/PrivateZone.aspx'>Zona Privada</a> é
    usado o edifício mãe para encontrar o nível, enquanto que na <a href='/pt/Universe/HotZone.aspx'>Zona Pública</a> é usado o nível do <a class='extractor' href='/pt/Facility/Extractor.aspx'>Extractor de Recursos</a>.
  </p>
	</div>
	
</asp:Content>