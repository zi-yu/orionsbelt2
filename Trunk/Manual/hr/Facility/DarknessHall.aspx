﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Dvorana Tame Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Dvorana Tame" runat="server" /></h1>

	<div class="description">
		<a class='darknesshall' href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a> je <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> postrojenje. Sve druge <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> postrojenja ovise o <a class='darknesshall' href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a>. Svaki nivo <a class='darknesshall' href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a> povećava produkciju <a class='titanium' href='/hr/Intrinsic/Titanium.aspx'>Titan</a>, <a class='gold' href='/hr/Intrinsic/Gold.aspx'>Zlato</a>, <a class='uranium' href='/hr/Intrinsic/Uranium.aspx'>Uran</a> i povećava <a href='/hr/Universe/Planets.aspx#Capacity'>Limit Resursa</a>.
		<div class='baseDarkHumansPreview DarkHumansDarknessHallPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Dvorana Tame Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li>Nema Ovisnosti</li></td><td><ul><li>Besplatno</li></td><td class='duration'>Počinje Gradnju</td><td><ul><li>+9 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1000 Kapacitet</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 1</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 1</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 1</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 1</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Dvorana Tame Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 1</li></ul></td><td><ul><li>263 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>420 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li></ul></td><td class='duration'>30 Minute </td><td><ul><li>+72 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 2</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 2</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 2</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 2</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Dvorana Tame Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 2</li></ul></td><td><ul><li>975 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>1560 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li></ul></td><td class='duration'>1 Sat 40 Minute </td><td><ul><li>+243 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 3</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 3</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 3</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 3</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Dvorana Tame Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 3</li></ul></td><td><ul><li>2363 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>3780 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>380 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>4 Sati </td><td><ul><li>+576 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 4</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 4</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 4</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 4</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 1</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Dvorana Tame Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 4</li></ul></td><td><ul><li>4650 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>7440 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>1219 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>250 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>7 Sati 50 Minute </td><td><ul><li>+1125 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uran</a> Po Ticku</li><li>+1000 Kapacitet</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 5</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 5</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 5</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 5</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 5</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Dvorana Tame Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 5</li></ul></td><td><ul><li>4075 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>8063 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>12900 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>2470 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>160 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1160 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>13 Sati 20 Minute </td><td><ul><li>+1944 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uran</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 6</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 6</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 6</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 6</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 6</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Dvorana Tame Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 6</li></ul></td><td><ul><li>9790 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>12825 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>20520 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>4216 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1430 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2430 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>21 Sati 20 Minute </td><td><ul><li>+3087 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uran</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 7</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 7</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 7</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 7</li><li><a href='../Facility/Devastation.aspx'>Devastacija</a> Nivo 1</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 7</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Dvorana Tame Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 7</li></ul></td><td><ul><li>17395 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>19163 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>30660 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>6540 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3120 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4120 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1180 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 7 Sati 50 Minute </td><td><ul><li>+4608 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uran</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 8</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 8</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 8</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 8</li><li><a href='../Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a> Nivo 1</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 8</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Dvorana Tame Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 8</li></ul></td><td><ul><li>27160 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>27300 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>43680 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>9524 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5290 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>6290 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4435 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>968 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Dan 21 Sati 10 Minute </td><td><ul><li>+6561 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uran</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 9</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 9</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 9</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 9</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 9</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Dvorana Tame Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 9</li></ul></td><td><ul><li>39355 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>37463 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>59940 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>13250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>8000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>9000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>3000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Dani 14 Sati </td><td><ul><li>+9000 K bodovima</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Zlato</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titan</a> Po Ticku</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uran</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Skladište Robova</a> Nivo 10</li><li><a href='../Facility/DominationYard.aspx'>Brodogradilište Dominacije</a> Nivo 10</li><li><a href='../Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a> Nivo 10</li><li><a href='../Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a> Nivo 10</li><li><a href='../Facility/NuclearFacility.aspx'>Ekstraktor Urana</a> Nivo 10</li></ul></td></tr></table>
	
</asp:Content>