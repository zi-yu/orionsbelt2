﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Extraktor Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="menu" runat="server">
	<h2>Gebäude</h2><ul><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/Extractor.aspx'>Extraktor</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1><asp:Literal Text="Extraktor" runat="server" /></h1>

	<div class="description">
		  Der <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> ist ein Gebäude der allen <a href='/de/Race/Races.aspx'>Rassen</a> zur Verfügung steht und kann in auf den <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> 
  Planeten gebaut werden. Dieses Gebäude versorgt dich mit den Grundressourcen deiner Rasse und 
  wichtiger noch: seltene Ressourcen.
  <p>
  Der <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> hat fünf Level und jedes versorgt dich mit +1 jeder seltenen Ressource. Ungerade 
  Levels versorgen dich auch mit einer beliebigen, seltenen Ressource.
  </p><p>
  Bemerke dass die <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> Konstruktion von deinem Spieler Level abhängt und von dem the Zonen 
  Level des Planeten.</p>
		<img src='http://resources.orionsbelt.eu/Images/Common/Planets/LightHumans/ExtractorR.png' alt='Extraktor' />
	</div>
	<div class="clear"></div>
	<h2><a href='#Level1' name='Level1'>Extraktor Level 1</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Spieler/Planet Level Check</li></ul></td><td><ul><li>20 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li></ul></td><td class='duration'>10 Minuten </td><td><ul><li>+40 Spielstand</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Energie</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level2' name='Level2'>Extraktor Level 2</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Spieler/Planet Level Check</li></ul></td><td><ul><li>320 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>340 <a href='../Intrinsic/Radon.aspx'>Radon</a></li></ul></td><td class='duration'>1 Stunde </td><td><ul><li>+320 Spielstand</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Energie</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level3' name='Level3'>Extraktor Level 3</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Spieler/Planet Level Check</li></ul></td><td><ul><li>1620 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>1290 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>925 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li></ul></td><td class='duration'>3 Stunden 30 Minuten </td><td><ul><li>+1080 Spielstand</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Energie</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level4' name='Level4'>Extraktor Level 4</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Spieler/Planet Level Check</li></ul></td><td><ul><li>5120 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>3140 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>2775 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>2650 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li></ul></td><td class='duration'>8 Stunden </td><td><ul><li>+2560 Spielstand</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Energie</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table><h2><a href='#Level5' name='Level5'>Extraktor Level 5</a></h2><table class='table'><tr><th>Abhängigkeiten</th><th>Kosten</th><th>Dauer</th><th>Wenn es fertig ist</th><th>Freigeben</th></tr><tr><td><ul><li>Spieler/Planet Level Check</li></ul></td><td><ul><li>12500 <a href='../Intrinsic/Astatine.aspx'>Astatine</a></li><li>6190 <a href='../Intrinsic/Radon.aspx'>Radon</a></li><li>5825 <a href='../Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>7225 <a href='../Intrinsic/Prismal.aspx'>Prismal</a></li><li>11000 <a href='../Intrinsic/Argon.aspx'>Argon</a></li></ul></td><td class='duration'>15 Stunden 40 Minuten </td><td><ul><li>+5000 Spielstand</li><li>+1 <a href='../Intrinsic/Mithril.aspx'>Mithril</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Energy.aspx'>Energie</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Protol.aspx'>Protol</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Uranium.aspx'>Uranium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Elk.aspx'>Nahrung</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Serium.aspx'>Serium</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Gold.aspx'>Gold</a> Pro Tick</li><li>+1 <a href='../Intrinsic/Titanium.aspx'>Titanium</a> Pro Tick</li></ul></td><td><ul></ul></td></tr></table>
	
</asp:Content>