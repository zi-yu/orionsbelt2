﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Serium Extraktor Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Serium Extraktor" runat="server" /></h1>

	<div class="description">
		Der <a class='seriumextractor' href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a> ist ein <a href='/de/Race/LightHumans.aspx'>Utopians</a> Gebäude das <a class='serium' href='/de/Intrinsic/Serium.aspx'>Serium</a> extrahiert aus <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> Planeten. Jeder <a class='seriumextractor' href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a> Level erhöht das <a class='serium' href='/de/Intrinsic/Serium.aspx'>Serium</a> Einkommen auf dem Planeten um +1.
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/SeriumExtractorR.png' alt='Serium Extraktor' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Serium Extraktor Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 1</li></ul></td><td><ul><li>20 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>220 <a href='../Intrinsic/Energy.aspx'>Energie</a></li></ul></td><td class='duration'>10 Minuten </td><td><ul><li>+4 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 2</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Serium Extraktor Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 2</li></ul></td><td><ul><li>80 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>880 <a href='../Intrinsic/Energy.aspx'>Energie</a></li></ul></td><td class='duration'>30 Minuten </td><td><ul><li>+32 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Serium Extraktor Level 3</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 3</li></ul></td><td><ul><li>180 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>1980 <a href='../Intrinsic/Energy.aspx'>Energie</a></li></ul></td><td class='duration'>1 Stunde 40 Minuten </td><td><ul><li>+108 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Serium Extraktor Level 4</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 4</li></ul></td><td><ul><li>360 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>320 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>3520 <a href='../Intrinsic/Energy.aspx'>Energie</a></li></ul></td><td class='duration'>4 Stunden </td><td><ul><li>+256 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Serium Extraktor Level 5</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 5</li></ul></td><td><ul><li>2800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>500 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>5500 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>125 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>7 Stunden 30 Minuten </td><td><ul><li>+500 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Serium Extraktor Level 6</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 6</li></ul></td><td><ul><li>6440 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>720 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>7920 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>620 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>148 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>13 Stunden </td><td><ul><li>+864 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Serium Extraktor Level 7</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 7</li></ul></td><td><ul><li>11520 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>980 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>10780 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>1205 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>529 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>60 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>20 Stunden 40 Minuten </td><td><ul><li>+1372 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Serium Extraktor Level 8</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 8</li></ul></td><td><ul><li>18280 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1280 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>14080 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>1880 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1036 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>130 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>660 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Tag 6 Stunden 50 Minuten </td><td><ul><li>+2048 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Serium Extraktor Level 9</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 9</li></ul></td><td><ul><li>26960 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>1620 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>17820 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>2645 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1687 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>895 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1340 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>180 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Tag 19 Stunden 50 Minuten </td><td><ul><li>+2916 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Serium Extraktor Level 10</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/CommandCenter.aspx'>Zentralkommando</a> Level 10</li></ul></td><td><ul><li>37800 <a href='../Intrinsic/Mithril.aspx'>Mithril</a></li><li>2000 <a href='../Intrinsic/Serium.aspx'>Serium</a></li><li>22000 <a href='../Intrinsic/Energy.aspx'>Energie</a></li><li>3500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1750 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2100 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1084 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>2 Tage 12 Stunden </td><td><ul><li>+4000 Spielstand</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>