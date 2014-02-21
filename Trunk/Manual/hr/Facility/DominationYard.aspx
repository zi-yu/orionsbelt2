﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Brodogradilište Dominacije Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Brodogradilište Dominacije" runat="server" /></h1>

	<div class="description">
		<a class='dominationyard' href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> je <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> postrojenje koje im dopušta da grade <a href='/hr/UnitIndex.aspx'>Borbene Jedinice</a>. Ovisno o njegovom nivou, <a class='dominationyard' href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> će moći graditi: <a class='darkrain' href='/hr/Unit/DarkRain.aspx'>Crna Kiša</a>, <a class='toxic' href='/hr/Unit/Toxic.aspx'>Otrovni</a>, <a class='anubis' href='/hr/Unit/Anubis.aspx'>Anubis</a>, <a class='driller' href='/hr/Unit/Driller.aspx'>Bušitelj</a>, <a class='panther' href='/hr/Unit/Panther.aspx'>Pantera</a>,<a class='scarab' href='/hr/Unit/Scarab.aspx'>Kornjaš</a>, <a class='kamikaze' href='/hr/Unit/Kamikaze.aspx'>Kamikaza</a>, <a class='vector' href='/hr/Unit/Vector.aspx'>Vector</a>, <a class='darkcrusader' href='/hr/Unit/DarkCrusader.aspx'>Crni Crusader</a>, <a class='doomer' href='/hr/Unit/Doomer.aspx'>Anihilator</a>, <a class='bozer' href='/hr/Unit/Bozer.aspx'>Bozer</a> i <a class='darktaurus' href='/hr/Unit/DarkTaurus.aspx'>Tamni Bik</a>.
		<div class='baseDarkHumansPreview DarkHumansDominationYardPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Brodogradilište Dominacije Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 1</li></ul></td><td><ul><li>380 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>350 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+6 K bodovima</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 2</li><li><a href='../Unit/DarkRain.aspx'>Crna Kiša</a></li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Brodogradilište Dominacije Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 2</li></ul></td><td><ul><li>1520 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>1400 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li></ul></td><td class='duration'>40 Minute </td><td><ul><li>+48 K bodovima</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 3</li><li><a href='../Unit/Toxic.aspx'>Otrovni</a></li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Brodogradilište Dominacije Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 3</li></ul></td><td><ul><li>3420 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>3150 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li></ul></td><td class='duration'>2 Sati 10 Minute </td><td><ul><li>+162 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Driller.aspx'>Bušitelj</a></li><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 4</li><li><a href='../Unit/Anubis.aspx'>Anubis</a></li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Brodogradilište Dominacije Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 4</li></ul></td><td><ul><li>1340 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>6080 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>5600 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>830 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>4 Sati 50 Minute </td><td><ul><li>+384 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Panther.aspx'>Pantera</a></li><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 5</li><li><a href='../Unit/Scarab.aspx'>Kornjaš</a></li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Brodogradilište Dominacije Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 5</li></ul></td><td><ul><li>5000 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>9500 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>8750 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>2000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>422 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>9 Sati 30 Minute </td><td><ul><li>+750 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Kamikaze.aspx'>Kamikaza</a></li><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 6</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Brodogradilište Dominacije Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 6</li></ul></td><td><ul><li>10460 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>13680 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>12600 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>3430 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1275 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>16 Sati 20 Minute </td><td><ul><li>+1296 K bodovima</li></ul></td><td><ul><li><a href='../Unit/Vector.aspx'>Vector</a></li><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 7</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Brodogradilište Dominacije Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 7</li></ul></td><td><ul><li>18080 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>18620 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>17150 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>5120 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2466 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>930 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>1 Dan 1 Sat 50 Minute </td><td><ul><li>+2058 K bodovima</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 8</li><li><a href='../Unit/DarkCrusader.aspx'>Crni Crusader</a></li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Brodogradilište Dominacije Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 8</li></ul></td><td><ul><li>28220 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>24320 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>22400 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>7070 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>4050 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2620 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>620 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 14 Sati 30 Minute </td><td><ul><li>+3072 K bodovima</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 9</li><li><a href='../Unit/Doomer.aspx'>Anihilator</a></li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Brodogradilište Dominacije Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 9</li></ul></td><td><ul><li>41240 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>30780 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>28350 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>9280 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>6084 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2790 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>468 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Dani 6 Sati 50 Minute </td><td><ul><li>+4374 K bodovima</li></ul></td><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 10</li><li><a href='../Unit/Bozer.aspx'>Bozer</a></li><li><a href='../Facility/Devastation.aspx'>Devastacija</a> Nivo 2</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Brodogradilište Dominacije Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 10</li></ul></td><td><ul><li>57500 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>38000 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>35000 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>11750 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>8625 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>7500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5500 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>2500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>3 Dani 3 Sati </td><td><ul><li>+6000 K bodovima</li></ul></td><td><ul><li><a href='../Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a> Nivo 2</li><li><a href='../Unit/DarkTaurus.aspx'>Tamni Bik</a></li></ul></td></tr></table>
	
</asp:Content>