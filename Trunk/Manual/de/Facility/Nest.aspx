﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Nest Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Nest" runat="server" /></h1>

	<div class="description">
		Das <a class='nest' href='/de/Facility/Nest.aspx'>Nest</a> ist das <a href='/de/Race/Bugs.aspx'>Levyr</a> Haupt-Gebäude. All die anderen <a href='/de/Race/Bugs.aspx'>Levyr</a> Gebäude sind von dem <a class='nest' href='/de/Facility/Nest.aspx'>Nest</a> abhängig.
  Jedes <a class='nest' href='/de/Facility/Nest.aspx'>Nest</a> Level erhöht die Produktion von <a class='elk' href='/de/Intrinsic/Elk.aspx'>Nahrung</a>, <a class='protol' href='/de/Intrinsic/Protol.aspx'>Protol</a> und erhöht die <a href='/de/Universe/Planets.aspx#Capacity'>Ressourcen-Limit</a>.
		<div class='baseBugsPreview BugsNestPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Nest Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Keine Abhängigkeiten</li></td><td><ul><li>Keine Kosten</li></td><td class='duration'>Startet bereits konstruiert</td><td><ul><li>+9 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 1</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 1</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 1</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Nest Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 1</li></ul></td><td><ul><li>385 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>490 <a href='../Intrinsic/Protol.aspx'>Protol</a></li></ul></td><td class='duration'>30 Minuten </td><td><ul><li>+72 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 2</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 2</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 2</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Nest Level 3</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 2</li></ul></td><td><ul><li>1430 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>1820 <a href='../Intrinsic/Protol.aspx'>Protol</a></li></ul></td><td class='duration'>1 Stunde 40 Minuten </td><td><ul><li>+243 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 3</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 3</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 3</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Nest Level 4</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 3</li></ul></td><td><ul><li>3465 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>4410 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>530 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>4 Stunden </td><td><ul><li>+576 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 4</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 4</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 4</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Nest Level 5</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 4</li></ul></td><td><ul><li>6820 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>8680 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1750 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>7 Stunden 50 Minuten </td><td><ul><li>+1125 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 5</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 5</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 5</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Nest Level 6</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 5</li></ul></td><td><ul><li>11825 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>15050 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>3570 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>1240 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>13 Stunden 20 Minuten </td><td><ul><li>+1944 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 6</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 6</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 6</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Nest Level 7</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 6</li></ul></td><td><ul><li>18810 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>23940 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>6110 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>2360 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>3145 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>21 Stunden 20 Minuten </td><td><ul><li>+3087 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 7</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 7</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 7</li><li><a href='../Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a> Level 1</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Nest Level 8</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 7</li></ul></td><td><ul><li>28105 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>35770 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>9490 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>5740 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5680 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Tag 7 Stunden 50 Minuten </td><td><ul><li>+4608 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 8</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 8</li><li><a href='../Facility/QueenHatchery.aspx'>Königin Brutstätte</a> Level 1</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 8</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Nest Level 9</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 8</li></ul></td><td><ul><li>40040 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>50960 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>13830 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>10080 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>8935 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5225 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Tag 21 Stunden 10 Minuten </td><td><ul><li>+6561 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 9</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 9</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 9</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Nest Level 10</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 9</li></ul></td><td><ul><li>54945 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>69930 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>19250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>15500 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>13000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>12000 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>2000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>2 Tage 14 Stunden </td><td><ul><li>+9000 Spielstand</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+2000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/ProtolExtractor.aspx'>Protol Extraktor</a> Level 10</li><li><a href='../Facility/ElkExtractor.aspx'>Nahrungsextraktor</a> Level 10</li><li><a href='../Facility/Incubator.aspx'>Inkubator</a> Level 10</li></ul></td></tr></table>
	
</asp:Content>