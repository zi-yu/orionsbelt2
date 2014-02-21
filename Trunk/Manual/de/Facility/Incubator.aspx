﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Inkubator Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Inkubator" runat="server" /></h1>

	<div class="description">
		Der <a class='incubator' href='/de/Facility/Incubator.aspx'>Inkubator</a> ist das <a href='/de/Race/Bugs.aspx'>Levyr</a> Gebäude das ihnen erlaubt <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> auszubrüten. Abhängig von ihrem Level , ist der <a class='incubator' href='/de/Facility/Incubator.aspx'>Inkubator</a> in der Lage folgendes auszubrüten: <a class='seeker' href='/de/Unit/Seeker.aspx'>Sucher</a>, <a class='interceptor' href='/de/Unit/Interceptor.aspx'>Abfangjäger</a>, <a class='worm' href='/de/Unit/Worm.aspx'>Wurm</a>, <a class='stinger' href='/de/Unit/Stinger.aspx'>Stachel</a>, <a class='hiveprotector' href='/de/Unit/HiveProtector.aspx'>Bienenstock Beschützer</a>,Destroyer], <a class='spider' href='/de/Unit/Spider.aspx'>Spinne</a>, <a class='heavyseeker' href='/de/Unit/HeavySeeker.aspx'>Mega Sucher</a>, <a class='hiveking' href='/de/Unit/HiveKing.aspx'>Bienenstock König</a> und <a class='blackwidow' href='/de/Unit/BlackWidow.aspx'>Schwarze Witwe</a>.
  <p>
  Um eine <a class='queen' href='/de/Unit/Queen.aspx'>Königin</a> zu erzeugen, brauchst du die <a class='queenhatchery' href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a>.</p>
		<div class='baseBugsPreview BugsIncubatorPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Inkubator Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 1</li></ul></td><td><ul><li>320 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>450 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li></ul></td><td class='duration'>10 Minuten </td><td><ul><li>+6 Spielstand</li></ul></td><td><ul><li><a href='../Unit/Seeker.aspx'>Sucher</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 2</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Inkubator Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 2</li></ul></td><td><ul><li>1280 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>1800 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li></ul></td><td class='duration'>40 Minuten </td><td><ul><li>+48 Spielstand</li></ul></td><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 3</li><li><a href='../Unit/Interceptor.aspx'>Abfangjäger</a></li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Inkubator Level 3</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 3</li></ul></td><td><ul><li>2880 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>4050 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li></ul></td><td class='duration'>2 Stunden 10 Minuten </td><td><ul><li>+162 Spielstand</li></ul></td><td><ul><li><a href='../Unit/Worm.aspx'>Wurm</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 4</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Inkubator Level 4</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 4</li></ul></td><td><ul><li>5120 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>7200 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>210 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>4 Stunden 50 Minuten </td><td><ul><li>+384 Spielstand</li></ul></td><td><ul><li><a href='../Unit/Stinger.aspx'>Stachel</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 5</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Inkubator Level 5</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 5</li></ul></td><td><ul><li>8000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>11250 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>1125 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>9 Stunden 30 Minuten </td><td><ul><li>+750 Spielstand</li></ul></td><td><ul><li><a href='../Unit/HiveProtector.aspx'>Bienenstock Beschützer</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 6</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Inkubator Level 6</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 6</li></ul></td><td><ul><li>11520 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>16200 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>2490 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>160 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>16 Stunden 20 Minuten </td><td><ul><li>+1296 Spielstand</li></ul></td><td><ul><li><a href='../Unit/Destroyer.aspx'>Zerstörer</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 7</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Inkubator Level 7</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 7</li></ul></td><td><ul><li>15680 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>22050 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>4395 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>645 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1430 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Tag 1 Stunde 50 Minuten </td><td><ul><li>+2058 Spielstand</li></ul></td><td><ul><li><a href='../Unit/Spider.aspx'>Spinne</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 8</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Inkubator Level 8</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 8</li></ul></td><td><ul><li>20480 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>28800 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>6930 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>3180 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>3120 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>1 Tag 14 Stunden 30 Minuten </td><td><ul><li>+3072 Spielstand</li></ul></td><td><ul><li><a href='../Unit/HeavySeeker.aspx'>Mega Sucher</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 9</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Inkubator Level 9</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 9</li></ul></td><td><ul><li>25920 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>36450 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>10185 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>6435 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>5290 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1580 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>2 Tage 6 Stunden 50 Minuten </td><td><ul><li>+4374 Spielstand</li></ul></td><td><ul><li><a href='../Unit/HiveKing.aspx'>Bienenstock König</a></li><li><a href='../Facility/Nest.aspx'>Nest</a> Level 10</li><li><a href='../Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a> Level 2</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Inkubator Level 10</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/Nest.aspx'>Nest</a> Level 10</li></ul></td><td><ul><li>32000 <a href='../Intrinsic/Protol.aspx'>Protol</a></li><li>45000 <a href='../Intrinsic/Elk.aspx'>Nahrung</a></li><li>14250 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>10500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>8000 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>7000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1500 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>3 Tage 3 Stunden </td><td><ul><li>+6000 Spielstand</li></ul></td><td><ul><li><a href='../Facility/QueenHatchery.aspx'>Königin Brutstätte</a> Level 2</li><li><a href='../Unit/BlackWidow.aspx'>Schwarze Witwe</a></li></ul></td></tr></table>
	
</asp:Content>