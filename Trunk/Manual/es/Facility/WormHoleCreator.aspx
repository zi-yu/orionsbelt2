<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Edifício Generador de Pasajes
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Edificios</h2><ul><li><a href='/es/Facility/Silo.aspx'>Bodega</a></li><li><a href='/es/Facility/SlaveWarehouse.aspx'>Bodega de Esclavos</a></li><li><a href='/es/Facility/DarknessHall.aspx'>Capital de la Oscuridad</a></li><li><a href='/es/Facility/CommandCenter.aspx'>Centro de Comando</a></li><li><a href='/es/Facility/Devastation.aspx'>Devastación</a></li><li><a href='/es/Facility/Incubator.aspx'>Encubadora</a></li><li><a href='/es/Facility/QueenHatchery.aspx'>Encubadora de Reinas</a></li><li><a href='/es/Facility/ElkExtractor.aspx'>Extractor de Comida</a></li><li><a href='/es/Facility/MithrilExtractor.aspx'>Extractor de Mithril</a></li><li><a href='/es/Facility/ProtolExtractor.aspx'>Extractor de Protol</a></li><li><a href='/es/Facility/Extractor.aspx'>Extractor de Recursos</a></li><li><a href='/es/Facility/SeriumExtractor.aspx'>Extractor de Serium</a></li><li><a href='/es/Facility/TitaniumExtractor.aspx'>Extractor de Titanio</a></li><li><a href='/es/Facility/NuclearFacility.aspx'>Extractor de Uranio</a></li><li><a href='/es/Facility/BattleMoonAssembler.aspx'>Fábrica de Lunas de Combate</a></li><li><a href='/es/Facility/BlinkerAssembler.aspx'>Fábrica de Parpadeantes</a></li><li><a href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a></li><li><a href='/es/Facility/DominationYard.aspx'>Hangar de Domínio</a></li><li><a href='/es/Facility/Nest.aspx'>Nido</a></li><li><a href='/es/Facility/SolarPanel.aspx'>Panel Solar</a></li><li><a href='/es/Facility/UnitYard.aspx'>Puerto Espacial</a></li><li><a href='/es/Facility/DeepSpaceScanner.aspx'>Radar de Largo Alcance</a></li><li><a href='/es/Facility/DevotionSanctuary.aspx'>Santuário de Devoción</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Generador de Pasajes" runat="server" /></h1>

	<div class="description">
		El <a class='wormholecreator' href='/es/Facility/WormHoleCreator.aspx'>Generador de Pasajes</a> es el edifício supremo de los <a href='/es/Race/Bugs.aspx'>Levyr</a>. Les Permite generar un <a href='/es/Universe/WormHole.aspx'>Túnel Espacial</a> temporal en el
  <a href='/es/Universe/Default.aspx'>Universo</a>.
		<div class='baseBugsPreview BugsWormHoleCreatorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Generador de Pasajes Nivel 1</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nido</a> Nivel 7</li></ul></td><td><ul><li>25000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>28000 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>11000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>9000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Día 21 Horas </td><td><ul><li>+2500 De pontuación</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Generador de Pasajes Nivel 2</a></h2><table class='table'><tr><th>Dependencias</th><th>Costo</th><th>Duración</th><th>Cuando Complete</th><th>Desbloquea</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Encubadora</a> Nivel 9</li></ul></td><td><ul><li>50000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>56000 <a href='../Intrinsic/Elk.aspx'>Comida</a></li><li>22000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>19000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>18000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>16500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>3 Días 18 Horas </td><td><ul><li>+5000 De pontuación</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>