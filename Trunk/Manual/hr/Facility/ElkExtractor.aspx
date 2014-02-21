﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Elk Ekstraktor Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Elk Ekstraktor" runat="server" /></h1>

	<div class="description">
		<a class='elkextractor' href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a> je <a href='/hr/Race/Bugs.aspx'>Levyr</a> postrojenje koje ekstrsaktira <a class='elk' href='/hr/Intrinsic/Elk.aspx'>Elk</a> iz <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planeta. Svaki <a class='elkextractor' href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a> nivo povećava +1 planetarni <a class='elk' href='/hr/Intrinsic/Elk.aspx'>Elk</a> prihod.
		<div class='baseBugsPreview BugsElkExtractorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Elk Ekstraktor Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 1</li></ul></td><td><ul><li>250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>38 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+6 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Elk Ekstraktor Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 2</li></ul></td><td><ul><li>1000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>152 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>30 Minute </td><td><ul><li>+48 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Elk Ekstraktor Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 3</li></ul></td><td><ul><li>2250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>342 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>1 Sat 30 Minute </td><td><ul><li>+162 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Elk Ekstraktor Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 4</li></ul></td><td><ul><li>4000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>608 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>3 Sati 30 Minute </td><td><ul><li>+384 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Elk Ekstraktor Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 5</li></ul></td><td><ul><li>6250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>950 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>6 Sati 50 Minute </td><td><ul><li>+750 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Elk Ekstraktor Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 6</li></ul></td><td><ul><li>9000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1368 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>800 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>370 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>11 Sati 40 Minute </td><td><ul><li>+1296 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Elk Ekstraktor Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 7</li></ul></td><td><ul><li>12250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1862 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>1450 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>286 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>955 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>18 Sati 40 Minute </td><td><ul><li>+2058 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Elk Ekstraktor Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 8</li></ul></td><td><ul><li>16000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>2432 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>2200 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>920 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1630 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>90 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 3 Sati 40 Minute </td><td><ul><li>+3072 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Elk Ekstraktor Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 9</li></ul></td><td><ul><li>20250 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3078 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>3050 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1734 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2395 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1110 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>145 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>1 Dan 15 Sati 30 Minute </td><td><ul><li>+4374 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Elk Ekstraktor Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 10</li></ul></td><td><ul><li>25000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3800 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>4000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2250 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>1500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>2 Dani 6 Sati </td><td><ul><li>+6000 K bodovima</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Elk</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>