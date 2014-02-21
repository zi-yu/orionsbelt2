﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Inkubator Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Inkubator" runat="server" /></h1>

	<div class="description">
		<a class='incubator' href='/hr/Facility/Incubator.aspx'>Inkubator</a> je <a href='/hr/Race/Bugs.aspx'>Levyr</a> postrojenje koje im dopušta da izlegnu <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>. Ovisno o njegovom nivou, <a class='incubator' href='/hr/Facility/Incubator.aspx'>Inkubator</a> će moći izleći: Seeker], <a class='interceptor' href='/hr/Unit/Interceptor.aspx'>Presretač</a>, <a class='worm' href='/hr/Unit/Worm.aspx'>Glista</a>, <a class='stinger' href='/hr/Unit/Stinger.aspx'>Žalac</a>, <a class='hiveprotector' href='/hr/Unit/HiveProtector.aspx'>Zaštitnik Košnice</a>,
<a class='destroyer' href='/hr/Unit/Destroyer.aspx'>Razarač</a>, <a class='spider' href='/hr/Unit/Spider.aspx'>Pauk</a>, <a class='heavyseeker' href='/hr/Unit/HeavySeeker.aspx'>Teški Tražilac</a>, <a class='hiveking' href='/hr/Unit/HiveKing.aspx'>Kralj Košnice</a> i <a class='blackwidow' href='/hr/Unit/BlackWidow.aspx'>Crna Udovica</a>.
<p />
Da izgradite <a class='queen' href='/hr/Unit/Queen.aspx'>Kraljica</a>, trebate <a class='queenhatchery' href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a>.
		<div class='baseBugsPreview BugsIncubatorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Inkubator Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 1</li></ul></td><td><ul><li>320 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>450 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+6 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Seeker.aspx'>Tražilac</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 2</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Inkubator Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 2</li></ul></td><td><ul><li>1280 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1800 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>40 Minute </td><td><ul><li>+48 K bodovima</li></ul></td><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 3</li><li><a href='../Unit/Interceptor.aspx'>Presretač</a></li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Inkubator Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 3</li></ul></td><td><ul><li>2880 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>4050 <a href='../Intrinsic/Elk.aspx'>Elk</a></li></ul></td><td class='duration'>2 Sati 10 Minute </td><td><ul><li>+162 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Worm.aspx'>Glista</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 4</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Inkubator Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 4</li></ul></td><td><ul><li>5120 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>7200 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>210 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>4 Sati 50 Minute </td><td><ul><li>+384 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Stinger.aspx'>Žalac</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 5</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Inkubator Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 5</li></ul></td><td><ul><li>8000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>11250 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>1125 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>9 Sati 30 Minute </td><td><ul><li>+750 K bodovima</li></ul></td><td><ul><li><a href='../Unit/HiveProtector.aspx'>Zaštitnik Košnice</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 6</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Inkubator Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 6</li></ul></td><td><ul><li>11520 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>16200 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>2490 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>160 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>16 Sati 20 Minute </td><td><ul><li>+1296 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Destroyer.aspx'>Razarač</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 7</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Inkubator Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 7</li></ul></td><td><ul><li>15680 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>22050 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>4395 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>645 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>1430 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dan 1 Sat 50 Minute </td><td><ul><li>+2058 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Spider.aspx'>Pauk</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 8</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Inkubator Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 8</li></ul></td><td><ul><li>20480 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>28800 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>6930 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>3180 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>3120 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dan 14 Sati 30 Minute </td><td><ul><li>+3072 K bodovima</li></ul></td><td><ul><li><a href='../Unit/HeavySeeker.aspx'>Teški Tražilac</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 9</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Inkubator Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 9</li></ul></td><td><ul><li>25920 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>36450 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>10185 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>6435 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>5290 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1580 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>2 Dani 6 Sati 50 Minute </td><td><ul><li>+4374 K bodovima</li></ul></td><td><ul><li><a href='../Unit/HiveKing.aspx'>Kralj Košnice</a></li><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 10</li><li><a href='../Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a> Nivo 2</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Inkubator Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Gnijezdo</a> Nivo 10</li></ul></td><td><ul><li>32000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>45000 <a href='../Intrinsic/Elk.aspx'>Elk</a></li><li>14250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>10500 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>8000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>7000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>3 Dani 3 Sati </td><td><ul><li>+6000 K bodovima</li></ul></td><td><ul><li><a href='../Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a> Nivo 2</li><li><a href='../Unit/BlackWidow.aspx'>Crna Udovica</a></li></ul></td></tr></table>
	
</asp:Content>