﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Zufluchtsstätte der Hingabe Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Zufluchtsstätte der Hingabe" runat="server" /></h1>

	<div class="description">
		Der <a class='devotionsanctuary' href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> ist ein <a href='/de/Race/DarkHumans.aspx'>Renegades</a> Gebäude das <a class='gold' href='/de/Intrinsic/Gold.aspx'>Gold</a> aus <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> Planeten gewinnt. Jedes <a class='devotionsanctuary' href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level erhöht um +1 das <a class='gold' href='/de/Intrinsic/Gold.aspx'>Gold</a> Einkommen auf dem Planeten.
		<div class='baseDarkHumansPreview DarkHumansDevotionSanctuaryPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Zufluchtsstätte der Hingabe Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 1</li></ul></td><td><ul><li>160 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>25 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>10 Minuten </td><td><ul><li>+3 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Zufluchtsstätte der Hingabe Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 2</li></ul></td><td><ul><li>640 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>100 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>30 Minuten </td><td><ul><li>+24 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Zufluchtsstätte der Hingabe Level 3</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 3</li></ul></td><td><ul><li>1440 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>225 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>1 Stunde 30 Minuten </td><td><ul><li>+81 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Zufluchtsstätte der Hingabe Level 4</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 4</li></ul></td><td><ul><li>1520 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>2560 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>400 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>3 Stunden 20 Minuten </td><td><ul><li>+192 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Zufluchtsstätte der Hingabe Level 5</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 5</li></ul></td><td><ul><li>3500 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>4000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>625 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>6 Stunden 30 Minuten </td><td><ul><li>+375 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Zufluchtsstätte der Hingabe Level 6</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 6</li></ul></td><td><ul><li>5920 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>5760 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>900 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>800 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>370 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>11 Stunden 20 Minuten </td><td><ul><li>+648 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Zufluchtsstätte der Hingabe Level 7</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 7</li></ul></td><td><ul><li>8780 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>7840 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>1225 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1450 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>286 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>955 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>18 Stunden </td><td><ul><li>+1029 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Zufluchtsstätte der Hingabe Level 8</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 8</li></ul></td><td><ul><li>12080 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>10240 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>1600 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>2200 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>920 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1630 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>90 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Tag 2 Stunden 40 Minuten </td><td><ul><li>+1536 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Zufluchtsstätte der Hingabe Level 9</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 9</li></ul></td><td><ul><li>15820 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>12960 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>2025 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>3050 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1734 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2395 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1110 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>145 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Tag 14 Stunden </td><td><ul><li>+2187 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Zufluchtsstätte der Hingabe Level 10</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level 10</li></ul></td><td><ul><li>20000 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>16000 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>2500 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>4000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2750 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>3250 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2250 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1500 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Tage 4 Stunden </td><td><ul><li>+3000 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+0,5 Produktionsfaktor</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>