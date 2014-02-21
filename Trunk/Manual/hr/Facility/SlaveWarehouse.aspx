﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Skladište Robova Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Skladište Robova" runat="server" /></h1>

	<div class="description">
		<a class='slavewarehouse' href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a> je <a href='/hr/Race/DarkHumans.aspx'>Renegades</a> postrojenje koje im dopušta da povećaju <a href='/hr/Universe/Planets.aspx#Capacity'>Limit Resursa</a>.
		<div class='baseDarkHumansPreview DarkHumansSlaveWarehousePreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Skladište Robova Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 1</li></ul></td><td><ul><li>300 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>47 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+3 K bodovima</li><li>+180 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Skladište Robova Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 2</li></ul></td><td><ul><li>1200 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>374 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li></ul></td><td class='duration'>30 Minute </td><td><ul><li>+24 K bodovima</li><li>+540 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Skladište Robova Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 3</li></ul></td><td><ul><li>2700 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>1260 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>530 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>40 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Sat 10 Minute </td><td><ul><li>+81 K bodovima</li><li>+900 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Skladište Robova Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 4</li></ul></td><td><ul><li>4800 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>2987 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>1640 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>460 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Sati 50 Minute </td><td><ul><li>+192 K bodovima</li><li>+1260 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Skladište Robova Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 5</li></ul></td><td><ul><li>7500 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>5834 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>3470 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>1000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>5 Sati 20 Minute </td><td><ul><li>+375 K bodovima</li><li>+1620 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Skladište Robova Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 6</li></ul></td><td><ul><li>10800 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>10080 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>6200 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>1660 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>9 Sati 10 Minute </td><td><ul><li>+648 K bodovima</li><li>+1980 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Skladište Robova Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 7</li></ul></td><td><ul><li>14700 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>16007 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>10010 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>2440 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>215 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1310 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>14 Sati 30 Minute </td><td><ul><li>+1029 K bodovima</li><li>+2340 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Skladište Robova Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 8</li></ul></td><td><ul><li>19200 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>23894 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>15080 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>3340 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1060 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1910 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>340 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>21 Sati 40 Minute </td><td><ul><li>+1536 K bodovima</li><li>+2700 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Skladište Robova Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 9</li></ul></td><td><ul><li>24300 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>34020 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>21590 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>4360 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2145 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2590 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1968 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>56 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Dan 6 Sati 40 Minute </td><td><ul><li>+2187 K bodovima</li><li>+3060 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Skladište Robova Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Dvorana Tame</a> Nivo 10</li></ul></td><td><ul><li>30000 <a href='../Intrinsic/Gold.aspx'>Zlato</a></li><li>46667 <a href='../Intrinsic/Titanium.aspx'>Titan</a></li><li>29720 <a href='../Intrinsic/Uranium.aspx'>Uran</a></li><li>5500 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4000 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>1750 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Dan 18 Sati 10 Minute </td><td><ul><li>+3000 K bodovima</li><li>+3420 Kapacitet</li><li>-0,5 Faktor Produkcije</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>