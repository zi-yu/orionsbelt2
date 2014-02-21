﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Brodogradilište Jedinica Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Brodogradilište Jedinica" runat="server" /></h1>

	<div class="description">
		<a class='unityard' href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a> je <a href='/hr/Race/LightHumans.aspx'>Utopians</a> postrojenje koje im dopušta da grade <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>. Ovisno o nivou <a class='unityard' href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a> moći će graditi: <a class='rain' href='/hr/Unit/Rain.aspx'>Kiša</a>, <a class='samurai' href='/hr/Unit/Samurai.aspx'>Samuraj</a>, <a class='raptor' href='/hr/Unit/Raptor.aspx'>Raptor</a>, <a class='kahuna' href='/hr/Unit/Kahuna.aspx'>Kahuna</a>, <a class='krill' href='/hr/Unit/Krill.aspx'>Krill</a>,
<a class='pretorian' href='/hr/Unit/Pretorian.aspx'>Pretorijanac</a>, <a class='eagle' href='/hr/Unit/Eagle.aspx'>Orao</a>, <a class='fenix' href='/hr/Unit/Fenix.aspx'>Feniks</a>, <a class='crusader' href='/hr/Unit/Crusader.aspx'>Crusader</a> i <a class='taurus' href='/hr/Unit/Taurus.aspx'>Bik</a>.
<p />
Da izgradite Blinker], trebati će vam <a class='blinkerassembler' href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a>.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/UnitYardR.png' alt='Brodogradilište Jedinica' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Brodogradilište Jedinica Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 2</li></ul></td><td><ul><li>250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>320 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+7 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Rain.aspx'>Kiša</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Brodogradilište Jedinica Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 2</li></ul></td><td><ul><li>1000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1280 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>40 Minute </td><td><ul><li>+56 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Raptor.aspx'>Raptor</a></li><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 3</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Brodogradilište Jedinica Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 3</li></ul></td><td><ul><li>2250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>2880 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>2 Sati </td><td><ul><li>+189 K bodovima</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 4</li><li><a href='../Unit/Krill.aspx'>Krill</a></li><li><a href='../Unit/Samurai.aspx'>Samuraj</a></li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Brodogradilište Jedinica Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 4</li></ul></td><td><ul><li>2840 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>4000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5120 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>830 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>4 Sati 40 Minute </td><td><ul><li>+448 K bodovima</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 5</li><li><a href='../Unit/Pretorian.aspx'>Pretorijanac</a></li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Brodogradilište Jedinica Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 5</li></ul></td><td><ul><li>6800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>6250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>8000 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>2000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>422 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>9 Sati </td><td><ul><li>+875 K bodovima</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 6</li><li><a href='../Unit/Kahuna.aspx'>Kahuna</a></li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Brodogradilište Jedinica Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 6</li></ul></td><td><ul><li>11640 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>9000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>11520 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>3430 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1275 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>15 Sati 40 Minute </td><td><ul><li>+1512 K bodovima</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 7</li><li><a href='../Unit/Eagle.aspx'>Orao</a></li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Brodogradilište Jedinica Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 7</li></ul></td><td><ul><li>17360 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>12250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>15680 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>5120 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2466 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>930 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>1 Dan 50 Minute </td><td><ul><li>+2401 K bodovima</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 8</li><li><a href='../Unit/Crusader.aspx'>Crusader</a></li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Brodogradilište Jedinica Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 8</li></ul></td><td><ul><li>23960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>16000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>20480 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>7070 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4050 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2620 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>620 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 13 Sati </td><td><ul><li>+3584 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Nova.aspx'>Nova</a></li><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 9</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Brodogradilište Jedinica Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 9</li></ul></td><td><ul><li>31440 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>20250 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>25920 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>9280 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>6084 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>4790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2790 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>468 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Dani 4 Sati 30 Minute </td><td><ul><li>+5103 K bodovima</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 10</li><li><a href='../Unit/Fenix.aspx'>Feniks</a></li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Brodogradilište Jedinica Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 10</li></ul></td><td><ul><li>39800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>25000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>32000 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>11750 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>8625 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>7500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5500 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>2500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>3 Dani </td><td><ul><li>+7000 K bodovima</li></ul></td><td><ul><li><a href='../Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a> Nivo 2</li><li><a href='../Unit/Taurus.aspx'>Bik</a></li></ul></td></tr></table>
	
</asp:Content>