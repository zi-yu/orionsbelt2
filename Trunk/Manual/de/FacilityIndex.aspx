<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gebäude
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Gebäude</h1><table class='table'><tr><th><a href='/de/Race/LightHumans.aspx'>Utopians</a></td><th><a href='/de/Race/DarkHumans.aspx'>Renegades</a></td><th><a href='/de/Race/Bugs.aspx'>Levyr</a></td></tr><tr><td><ul><li><a href='/de/Facility/DeepSpaceScanner.aspx'>Weltraum Tiefenscanner</a></li><li><a href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a></li><li><a href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li><a href='/de/Facility/SolarPanel.aspx'>Solar Tafel</a></li><li><a href='/de/Facility/MithrilExtractor.aspx'>Mithril Extraktor</a></li><li><a href='/de/Facility/Silo.aspx'>Silo</a></li><li><a href='/de/Facility/SeriumExtractor.aspx'>Serium Extraktor</a></li><li><a href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a></li></td></ul><td><ul><li><a href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a></li><li><a href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a></li><li><a href='/de/Facility/TitaniumExtractor.aspx'>Titanium Extraktor</a></li><li><a href='/de/Facility/DevotionSanctuary.aspx'>Zufluchtsstätte der Hingabe</a></li><li><a href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li><a href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a></li><li><a href='/de/Facility/Devastation.aspx'>Zerstörung</a></li><li><a href='/de/Facility/NuclearFacility.aspx'>Uranium Extraktor</a></li></td></ul><td><ul><li><a href='/de/Facility/ProtolExtractor.aspx'>Protol Extraktor</a></li><li><a href='/de/Facility/ElkExtractor.aspx'>Nahrungsextraktor</a></li><li><a href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a></li><li><a href='/de/Facility/Incubator.aspx'>Inkubator</a></li><li><a href='/de/Facility/Nest.aspx'>Nest</a></li><li><a href='/de/Facility/WormHoleCreator.aspx'>Wurmloch Erzeuger</a></li></td></ul></tr></table>
	
	<div class="content">
		<h2>Haupt-Gebude</h2>
<p>
    Jede Rasse hat ihr eigenes Hauptgebäude, das benutzt wird um das Spieler-Level zu definieren. 
    Die Hauptgebäude sind:
    </p>
<ul>
  <li>Das <a class='commandcenter' href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a> für die <a href='/de/Race/LightHumans.aspx'>Utopians</a></li>
  <li>Die <a class='darknesshall' href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a> für die 
    <a href='/de/Race/DarkHumans.aspx'>Renegades</a></li>
  <li>Das <a class='nest' href='/de/Facility/Nest.aspx'>Nest</a> für die <a href='/de/Race/Bugs.aspx'>Levyr</a></li>
</ul>
<h2>Ressourcn Ansammlung</h2>
<p>
    Um deine <a href='/de/FacilityIndex.aspx'>Gebäude</a> aufzurüsten und <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> aufzubauen brauchst du <a href='/de/IntrinsicIndex.aspx'>Speziell</a> 
    Ressourcen. Diese Ressourcen gewonnen werden in den <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> Planeten indem man die 
    Extraktor Gebäude benutzt.
  </p>
<h2>Einheiten bauen</h2>
<p>
    Du brauchst ein spezielles Gebäude um <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu bauen. Jede Rasse hat ihren eigenen 
    Baugebäude , und diese Gebäude haben 10 Level. Jedes Level schaltet andere <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> frei. 
    Die Baugebäude der Einheiten sind:
    </p>
<ul>
  <li>Die <a class='unityard' href='/de/Facility/UnitYard.aspx'>Weltraumhafen</a> für <a href='/de/Race/LightHumans.aspx'>Utopians</a></li>
  <li>Der <a class='dominationyard' href='/de/Facility/DominationYard.aspx'>Herrschafts Hangar</a> für <a href='/de/Race/DarkHumans.aspx'>Renegades</a></li>
  <li>Der <a class='incubator' href='/de/Facility/Incubator.aspx'>Inkubator</a> für die <a href='/de/Race/Bugs.aspx'>Levyr</a></li>
</ul>
    Beachte dass du dieses Gebäude betriesbereit halten musst um in der Lage zu sein Einheiten zu 
    bauen.
  <h3>Ultimative Einheiten Konstruktion</h3><p>
    Wir haben für jede Rasse eine Ultimative Einheit zur Verfügung. Diese Einheiten sind sehr 
    kostenspielig und man kann sie nur in fortgeschrittenen Level erhalten. Was diese Einheiten 
    unterscheidet ist dass sie ausserhalb des <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> positioniert werden können,
    und sie haben sehr einzigartige Fähigkeiten:
    </p><ul><li>
    Die <a href='/de/Race/LightHumans.aspx'>Utopians</a> können den <a class='blinker' href='/de/Unit/Blinker.aspx'>Blinker</a> bauen auf dem <a class='blinkerassembler' href='/de/Facility/BlinkerAssembler.aspx'>Blinker Fabrik</a>. Der <a class='blinker' href='/de/Unit/Blinker.aspx'>Blinker</a> mit 
    Leichtigkeit jede Einheite bewegen auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> bewegen(deine oder deines Gegners) .
  </li><li>
    Die <a href='/de/Race/DarkHumans.aspx'>Renegades</a> können die <a class='battlemoon' href='/de/Unit/BattleMoon.aspx'>Mond-Schlacht</a> bauen auf dem <a class='battlemoonassembler' href='/de/Facility/BattleMoonAssembler.aspx'>Fabrik der Mondschlachten</a>. Die <a class='battlemoon' href='/de/Unit/BattleMoon.aspx'>Mond-Schlacht</a> 
    kann jede gegnerische Einheit innehalbder Reichweite angreifen.
  </li><li>
    Die <a href='/de/Race/Bugs.aspx'>Levyr</a> können die <a class='queen' href='/de/Unit/Queen.aspx'>Königin</a> bauen in der <a class='queenhatchery' href='/de/Facility/QueenHatchery.aspx'>Königin Brutstätte</a>. Die <a class='queen' href='/de/Unit/Queen.aspx'>Königin</a> kann Eier ausbrüten auf 
    dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> aus denen die <a class='maggot' href='/de/Unit/Maggot.aspx'>Made</a> schlüpfen.
  </li></ul><h2>Planet Level and Gebäude Level</h2><p>
    Jeder Planet hat zwei distinktive Level die bestimmen welche <a href='/de/FacilityIndex.aspx'>Gebäude</a> gebaut werden können.
    Der <u>Planet Level</u> das <a href='/de/Universe/HotZone.aspx#levels'>Zone-Level</a> im Universum, an wo der Planet sich befindet.
    Der <u>Gebäude Level</u> zeigt das Evolutions-Level auf deinen Planeten an. In deinen 
    <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> Planeten benutzen wir das Hauptgebäude um den Level des Planeten zu erhalten. In 
    der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> dagegen, benutzen wir das <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> Level.
  </p>
	</div>
	
</asp:Content>