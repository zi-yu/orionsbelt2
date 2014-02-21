﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Silos Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Silos" runat="server" /></h1>

	<div class="description">
		<a class='silo' href='/hr/Facility/Silo.aspx'>Silos</a> je<a href='/hr/Race/LightHumans.aspx'>Utopians</a> postrojenje  koje im dopuša da im se poveća <a href='/hr/Universe/Planets.aspx#Capacity'>Limit Resursa</a>.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/SiloR.png' alt='Silos' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Silos Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 2</li></ul></td><td><ul><li>30 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>200 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+2 K bodovima</li><li>+180 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Silos Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 2</li></ul></td><td><ul><li>240 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>800 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>20 Minute </td><td><ul><li>+16 K bodovima</li><li>+540 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Silos Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 3</li></ul></td><td><ul><li>280 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>810 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1800 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>40 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>1 Sat 10 Minute </td><td><ul><li>+54 K bodovima</li><li>+900 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Silos Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 4</li></ul></td><td><ul><li>1390 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1920 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>3200 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>460 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>2 Sati 40 Minute </td><td><ul><li>+128 K bodovima</li><li>+1260 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Silos Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 5</li></ul></td><td><ul><li>3220 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>3750 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5000 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>1000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>5 Sati </td><td><ul><li>+250 K bodovima</li><li>+1620 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Silos Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 6</li></ul></td><td><ul><li>5950 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>6480 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>7200 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>1660 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>790 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>8 Sati 40 Minute </td><td><ul><li>+432 K bodovima</li><li>+1980 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Silos Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 7</li></ul></td><td><ul><li>9760 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>10290 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>9800 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>2440 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>215 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1310 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>13 Sati 50 Minute </td><td><ul><li>+686 K bodovima</li><li>+2340 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Silos Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 8</li></ul></td><td><ul><li>14830 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>15360 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>12800 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>3340 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1060 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1910 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>340 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>20 Sati 30 Minute </td><td><ul><li>+1024 K bodovima</li><li>+2700 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Silos Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 9</li></ul></td><td><ul><li>21340 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>21870 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>16200 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>4360 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2145 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2590 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1968 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>56 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dan 5 Sati 10 Minute </td><td><ul><li>+1458 K bodovima</li><li>+3060 Kapacitet</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Silos Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 10</li></ul></td><td><ul><li>29470 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>30000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>20000 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>5500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>3350 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4000 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>1750 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dan 16 Sati </td><td><ul><li>+2000 K bodovima</li><li>+3420 Kapacitet</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>