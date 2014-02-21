<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Öffentlice Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Hot Zone</h1>
<div class="content">
    Die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> ist wo die ganze Action stattfindet. Dort wirst du andere Spieler finden, andere 
    <a href='/de/Race/Races.aspx'>Rassen</a> und ein enormes <a href='/de/Universe/Default.aspx'>Universum</a> zu erforschen. In der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> kann das Spiel dich nicht 
    beschützen gegen andere Gegner, du bist auf dich selbst gestellt. Der einzige Schutz den dir das 
    Spiel bieten kann, ist dass Spieler mit höherem Level nicht in der Lage sind Spieler mit 
    niedrigerem Level anzugreifen.
    <p>
    Aber du musst nicht allein im Universum sein, du solltest einer <a href='/de/Universe/Alliance.aspx'>Allianz</a> beitreten für Schutz 
    und Führung. Du solltest auch eine <a href='/de/Quests.aspx#Professions'>Beruf</a> suchen und ihre <a href='/de/Quests.aspx'>Missionen</a> folgen, weil du so 
    schneller wachsen kannst.
    </p><p>
    Einige Interessenspunkte die du in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> vorfinden magst:
    </p><ul><li>Andere <a href='/de/Universe/Planets.aspx'>Planeten</a> zu besiedelen, die es dir erlauben den <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> zu bauen und 
    mehrere seltene Ressourcen zu gewinnen</li><li>
    <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> - es gibt eine enorme Anzahl von Wormholes im Universum, und sie sind sehr nützlich um deine <a href='/de/Universe/Travel.aspx'>Reisen</a> Zeit effizient zu verkürzen. 
    </li><li><a href='/de/Commerce/Markets.aspx'>Märkte</a> - Finde Märkte und folge den <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> um ein reicher <a href='/de/MerchantQuests.aspx'>Händler</a> zu 
    werden</li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a> - kämpfe in den Schlachten um einer der obersten <a href='/de/GladiatorQuests.aspx'>Gladiator</a> zu 
    werden</li></ul><a id="levels" name="levels"></a><h2>Zone Level</h2>
    Jedes Element im Universum hat ein eigenes Level, das abhängig ist von von der eigenen Zone. 
    <a href='/de/Universe/Planets.aspx'>Planeten</a>, <a href='/de/Universe/Arenas.aspx'>Arenen</a>, <a href='/de/Commerce/Markets.aspx'>Märkte</a>, <a href='/de/Universe/Relics.aspx'>Reliquien</a>, etc.
    Je näher du zum Zentrum bist, umso grösser ist das Level der Zone. Die Zone im Zentrum heisst
    <i>Sirius</i>.
    <p>
    Diese Zone Levels sind dazu da um folgendes sichern:
    </p><ul><li>Wenn ein Spieler ein Spiel anfängt, hat er ein privates <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> das seine 
    <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> mit einem <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> des äusseren Universums verbindet. Von dort aus, kann er sich 
    zum Zentrum bewegen um bessere <a href='/de/Universe/Planets.aspx'>Planeten</a> zu erobern</li><li>Das bedeutet das der Spieler in den 
    äusseren <i>rings</i> anfängt sich zum Zentrum durchzuarbeiten</li><li>Und auch dass Anfänger
    Spieler sich mit fortgeschrittenen Spielern nicht kreuzen, weil diese sich bereits in bessere 
    Position begeben haben </li></ul>
    Levels variieren von 1 to 10, indem 10 das reichste/mächtigste ist. Das folgende Bild ist eine
    Darstellung des <a href='http://www.orionsbelt.eu'>Orion's Belt</a> Universums:
  </div>
	<img class="block" src="/Resources/Images/WormHoleMapPreview.png" />
	
</asp:Content>