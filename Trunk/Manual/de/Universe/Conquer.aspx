<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Erobern
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Erobern</h1>
	
	<div class="content">
    <a href='/de/Universe/Conquer.aspx'>Erobern</a> ist der Akt des Eroberns eines Planeten der bereits einen Besitzer hat. Um einen <a href='/de/Universe/Planets.aspx'>Planet</a>
    zu <a href='/de/Universe/Conquer.aspx'>Erobern</a> musst du eine [Flotte] zum Ziel <a href='/de/Universe/Planets.aspx'>Planet</a> bewegen.
    <p>
    Wenn du eine <a href='/de/Universe/Conquer.aspx'>Erobern</a> zu besiedeln versuchst können zwei Dinge passieren:
    </p><ul><li>Der <a href='/de/Universe/Planets.aspx'>Planet</a> hat einen Besitzer aber keine Verteidigungen. In diesem Fall wird der 
   <a href='/de/Universe/Planets.aspx'>Planet</a> automatisch erobert.</li><li>Der <a href='/de/Universe/Planets.aspx'>Planet</a> hat einen Besitzer und Verteidigungen. In diesem 
    Fall wird eine Schlacht anfangen mit dem Besitzer eines <a href='/de/Universe/Planets.aspx'>Planet</a>.</li></ul><p>
    In beiden Fällen, wird dieses Menü erscheinen:
    </p><p><img src="/Resources/Images/en/Conquer2.png" alt="Erobere ein Planet" /></p><p>
    Bemerke dass in dem Menü oben die Option "Planet überfallen" erschienen ist. Du kannst mehr Information über diese Option finden auf der <a href='/de/Universe/Raids.aspx'>Plünderung</a> Seite.
   </p></div>
	
</asp:Content>