<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kraljičino Mrijestilište Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Kraljičino Mrijestilište" runat="server" /></h1>

	<div class="description">
		<a class='queenhatchery' href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a> je <a href='/hr/Race/Bugs.aspx'>Levyr</a> postrojenje koje im dopušta da izgrade njihovu ultimativnu jedinicu: <a class='queen' href='/hr/Unit/Queen.aspx'>Kraljica</a>.
		<div class='baseBugsPreview BugsQueenHatcheryPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Kraljičino Mrijestilište Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 8</li></ul></td><td><ul><li>32000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>24000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>10500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 18 Sati </td><td><ul><li>+3000 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Queen.aspx'>Kraljica</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Kraljičino Mrijestilište Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Nivo 10</li></ul></td><td><ul><li>64000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>48000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>21000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>19000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>18000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>17000 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>3 Dani 12 Sati </td><td><ul><li>+6000 K bodovima</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>