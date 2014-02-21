<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Privat-Zone
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Private Zone</h1>
<div class="content">
    Die <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> ist der Ort wo du das Spiel anfängst. Es ist eine Zone die nur dir zugänglich 
    ist, kein anderer Spieler vermag deine <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> zu betreten. In deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> hast du 
    fünf <a href='/de/Universe/Planets.aspx'>Planeten</a>. Diese sind deine Haupt-Planeten wo du <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Ressourcen erhalten 
    und <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> bauen kannst.
    <p>
    Hier ist ein Bild von deiner Private Zone wenn das Spiel anfängt:
    <img class="block" src="/Resources/Images/PZ1.png" alt="Bild der Private Zone" />

    Und hier ist ein Bild von einer komplett erforschten Private Zone:
    <img class="block" src="/Resources/Images/PZ2.png" alt="Bild der Private Zone" />
    
    In deiner Privat Zone (und im ganzen Universum) bist du in der Lage verschiedene <a href='/de/IntrinsicIndex.aspx'>Speziell</a> 
    Ressourcen zu finden, die es dir erlauben Ressourcen einzusammeln nur indem du deine <a href='/de/Universe/Fleet.aspx'>Flotten</a> 
    zu dieser Position bewegst. 
    Wenn du das Spiel anfängst, sorge dafür dass du sie alle einsammelst, weil du sie später alle 
    brauchen wirst.
    </p><p>
    Wenn du bereit bist deine Private Zone zu verlassen, kannst du das <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> benutzen um in die  
    <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> zu reisen und mit anderen Spielern zu interagieren, weitere Planeten zu besiedeln, und
    vieles mehr.
    </p><p>
    Während du in deiner Private Zone bist, sorge dafür dass du folgende <a href='/de/Quests.aspx'>Missionen</a> folgst:
    </p><ul><li><a href='/de/Quest/GetAllPrivateZoneResources.aspx'>Fange all die Ressourcen in deiner Privat-Zone ein</a></li><li><a href='/de/Quest/ColonizeOnePlanetQuest.aspx'>Besiedle einen weiteren Planeten in deiner Privat-Zone</a></li><li><a href='/de/Quest/ColonizeAllPrivateZonePlanetsQuest.aspx'>Bevölkere alle fünf Planeten in deiner Privat-Zone</a></li><li><a href='/de/Quest/FindPrivateWormHoleQuest.aspx'>Finde ein Wurmloch in deiner Privat-Zone und benutze es um in die öffentliche Zone zu reisen</a></li></ul></div>
	
</asp:Content>