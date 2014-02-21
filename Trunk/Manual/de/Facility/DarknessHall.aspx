﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Halle der Dunkelheit Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Halle der Dunkelheit" runat="server" /></h1>

	<div class="description">
		Die <a class='darknesshall' href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> ist das <a href='/de/Race/DarkHumans.aspx'>Renegades</a> Hauptgebäude. Alle anderen <a href='/de/Race/DarkHumans.aspx'>Renegades</a> Gebäude sind abhängig von der<a class='darknesshall' href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a>.
  Jedes <a class='darknesshall' href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> Level erhöht die Produktion von <a class='titanium' href='/de/Intrinsic/Titanium.aspx'>Titanium</a>, <a class='gold' href='/de/Intrinsic/Gold.aspx'>Gold</a>, <a class='uranium' href='/de/Intrinsic/Uranium.aspx'>Uranium</a> und erhöht die <a href='/de/Universe/Planets.aspx#Capacity'>Ressourcen-Limit</a>.
		<div class='baseDarkHumansPreview DarkHumansDarknessHallPreview manualPreview'></div>
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Halle der Dunkelheit Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Keine Abhängigkeiten</li></td><td><ul><li>Keine Kosten</li></td><td class='duration'>Startet bereits konstruiert</td><td><ul><li>+9 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 1</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 1</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 1</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 1</li></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Halle der Dunkelheit Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 1</li></ul></td><td><ul><li>263 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>420 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>30 Minuten </td><td><ul><li>+72 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 2</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 2</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 2</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 2</li></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Halle der Dunkelheit Level 3</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 2</li></ul></td><td><ul><li>975 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>1560 <a href='../Intrinsic/Gold.aspx'>Gold</a></li></ul></td><td class='duration'>1 Stunde 40 Minuten </td><td><ul><li>+243 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 3</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 3</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 3</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 3</li></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Halle der Dunkelheit Level 4</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 3</li></ul></td><td><ul><li>2363 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>3780 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>380 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>4 Stunden </td><td><ul><li>+576 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 4</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 4</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 4</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 4</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 1</li></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Halle der Dunkelheit Level 5</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 4</li></ul></td><td><ul><li>4650 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>7440 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>1219 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>250 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>7 Stunden 50 Minuten </td><td><ul><li>+1125 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li><li>+1000 Kapazität</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 5</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 5</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 5</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 5</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 5</li></ul></td></tr></table><h2><a href='#Level6' name='Level6'>Halle der Dunkelheit Level 6</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 5</li></ul></td><td><ul><li>4075 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>8063 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>12900 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>2470 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>160 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>1160 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>13 Stunden 20 Minuten </td><td><ul><li>+1944 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 6</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 6</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 6</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 6</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 6</li></ul></td></tr></table><h2><a href='#Level7' name='Level7'>Halle der Dunkelheit Level 7</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 6</li></ul></td><td><ul><li>9790 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>12825 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>20520 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>4216 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>1430 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>2430 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>21 Stunden 20 Minuten </td><td><ul><li>+3087 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 7</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 7</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 7</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 7</li><li><a href='../Facility/Devastation.aspx'>Zerstörung</a> Level 1</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 7</li></ul></td></tr></table><h2><a href='#Level8' name='Level8'>Halle der Dunkelheit Level 8</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 7</li></ul></td><td><ul><li>17395 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>19163 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>30660 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>6540 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>3120 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>4120 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>1180 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>1 Tag 7 Stunden 50 Minuten </td><td><ul><li>+4608 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 8</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 8</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 8</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 8</li><li><a href='../Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a> Level 1</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 8</li></ul></td></tr></table><h2><a href='#Level9' name='Level9'>Halle der Dunkelheit Level 9</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 8</li></ul></td><td><ul><li>27160 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>27300 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>43680 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>9524 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>5290 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>6290 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>4435 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>968 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>1 Tag 21 Stunden 10 Minuten </td><td><ul><li>+6561 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 9</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 9</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 9</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 9</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 9</li></ul></td></tr></table><h2><a href='#Level10' name='Level10'>Halle der Dunkelheit Level 10</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 9</li></ul></td><td><ul><li>39355 <a href='../Intrinsic/Uranium.aspx'>Uranium</a></li><li>37463 <a href='../Intrinsic/Titanium.aspx'>Titanium</a></li><li>59940 <a href='../Intrinsic/Gold.aspx'>Gold</a></li><li>13250 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>8000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li><li>9000 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>8500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>3000 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>2 Tage 14 Stunden </td><td><ul><li>+9000 Spielstand</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li></ul></td><td><ul><li><a href='../Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> Level 10</li><li><a href='../Facility/DominationYard.aspx'>Herrschafts Hangar</a> Level 10</li><li><a href='../Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a> Level 10</li><li><a href='../Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a> Level 10</li><li><a href='../Facility/NuclearFacility.aspx'>Uranium Extraktor</a> Level 10</li></ul></td></tr></table>
	
</asp:Content>