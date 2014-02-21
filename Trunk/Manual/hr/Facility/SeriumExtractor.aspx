﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/hr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Ekstraktor Seriuma Postrojenje
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Postrojenja</h2><ul><li><a href='/hr/Facility/DominationYard.aspx'>Brodogradilište Dominacije</a></li><li><a href='/hr/Facility/UnitYard.aspx'>Brodogradilište Jedinica</a></li><li><a href='/hr/Facility/Devastation.aspx'>Devastacija</a></li><li><a href='/hr/Facility/DarknessHall.aspx'>Dvorana Tame</a></li><li><a href='/hr/Facility/Extractor.aspx'>Ekstraktor</a></li><li><a href='/hr/Facility/MithrilExtractor.aspx'>Ekstraktor Mithrila</a></li><li><a href='/hr/Facility/ProtolExtractor.aspx'>Ekstraktor Protola</a></li><li><a href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a></li><li><a href='/hr/Facility/TitaniumExtractor.aspx'>Ekstraktor Titana</a></li><li><a href='/hr/Facility/NuclearFacility.aspx'>Ekstraktor Urana</a></li><li><a href='/hr/Facility/ElkExtractor.aspx'>Elk Ekstraktor</a></li><li><a href='/hr/Facility/Nest.aspx'>Gnijezdo</a></li><li><a href='/hr/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/hr/Facility/QueenHatchery.aspx'>Kraljičino Mrijestilište</a></li><li><a href='/hr/Facility/WormHoleCreator.aspx'>Kreator Crvotočine</a></li><li><a href='/hr/Facility/Silo.aspx'>Silos</a></li><li><a href='/hr/Facility/DeepSpaceScanner.aspx'>Skener Dubokog Svemira</a></li><li><a href='/hr/Facility/SlaveWarehouse.aspx'>Skladište Robova</a></li><li><a href='/hr/Facility/SolarPanel.aspx'>Solarna Ploča</a></li><li><a href='/hr/Facility/DevotionSanctuary.aspx'>Svetište Pobožnosti</a></li><li><a href='/hr/Facility/BlinkerAssembler.aspx'>Tvornica Bljeskalica</a></li><li><a href='/hr/Facility/BattleMoonAssembler.aspx'>Tvornica Borbenih Mjeseca</a></li><li><a href='/hr/Facility/CommandCenter.aspx'>Zapovjedni Centar</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Ekstraktor Seriuma" runat="server" /></h1>

	<div class="description">
		<a class='seriumextractor' href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a> is a <a href='/hr/Race/LightHumans.aspx'>Utopians</a> postrojenje koje ekstraktira <a class='serium' href='/hr/Intrinsic/Serium.aspx'>Serium</a> iz <a href='/hr/Universe/PrivateZone.aspx'>Privatna Zona</a> planeta. Svaki nivo <a class='seriumextractor' href='/hr/Facility/SeriumExtractor.aspx'>Ekstraktor Seriuma</a> povećava +1 planetarni <a class='serium' href='/hr/Intrinsic/Serium.aspx'>Serium</a> prihod.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/SeriumExtractorR.png' alt='Ekstraktor Seriuma' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Ekstraktor Seriuma Nivo 1</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 1</li></ul></td><td><ul><li>20 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>220 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>10 Minute </td><td><ul><li>+4 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 2</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Ekstraktor Seriuma Nivo 2</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 2</li></ul></td><td><ul><li>80 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>880 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>30 Minute </td><td><ul><li>+32 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Ekstraktor Seriuma Nivo 3</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 3</li></ul></td><td><ul><li>180 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1980 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>1 Sat 40 Minute </td><td><ul><li>+108 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Ekstraktor Seriuma Nivo 4</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 4</li></ul></td><td><ul><li>360 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>320 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>3520 <a href='../Intrinsic/Energy.aspx'>Energija</a></li></ul></td><td class='duration'>4 Sati </td><td><ul><li>+256 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Ekstraktor Seriuma Nivo 5</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 5</li></ul></td><td><ul><li>2800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>500 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5500 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>125 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>7 Sati 30 Minute </td><td><ul><li>+500 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Ekstraktor Seriuma Nivo 6</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 6</li></ul></td><td><ul><li>6440 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>720 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>7920 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>620 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>148 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>13 Sati </td><td><ul><li>+864 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Ekstraktor Seriuma Nivo 7</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 7</li></ul></td><td><ul><li>11520 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>980 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>10780 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>1205 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>529 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>60 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>20 Sati 40 Minute </td><td><ul><li>+1372 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Ekstraktor Seriuma Nivo 8</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 8</li></ul></td><td><ul><li>18280 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1280 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>14080 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>1880 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1036 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>130 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>660 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li></ul></td><td class='duration'>1 Dan 6 Sati 50 Minute </td><td><ul><li>+2048 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Ekstraktor Seriuma Nivo 9</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 9</li></ul></td><td><ul><li>26960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1620 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>17820 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>2645 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1687 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>895 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1340 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>180 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Dan 19 Sati 50 Minute </td><td><ul><li>+2916 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Ekstraktor Seriuma Nivo 10</a></h2><table class='table'><tr><th>Ovisnosti</th><th>Cijena</th><th>Trajanje</th><th>Po Završetku</th><th>Otključava</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zapovjedni Centar</a> Nivo 10</li></ul></td><td><ul><li>37800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>2000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>22000 <a href='../Intrinsic/Energy.aspx'>Energija</a></li><li>3500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2100 <a href='../Intrinsic/Astatine.aspx'>Astatin</a></li><li>1084 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Dani 12 Sati </td><td><ul><li>+4000 K bodovima</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Po Ticku</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>