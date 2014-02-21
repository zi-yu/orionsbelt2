<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Angriff
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	<h1>Angriff</h1>
	<div class="content">
    Um irgendetwas im <a href='/de/Universe/Default.aspx'>Universum</a> anzugreifen, muss du eine [Flotte] mit Einheiten haben.
    <p>
    Um einen anderen Spieler anzugreifen wähle einfach [Flotte] und klicke einfach über die [Flotte] 
    oder <a href='/de/Universe/Planets.aspx'>Planet</a> des anderen Spielers.
    </p><p>
    Wenn du über die [Flotte] klickst, erscheint folgendes Menü:
    </p><p><img src="/Resources/Images/en/AttackFleet.png" alt="Attack a Fleet" /></p><p>
    Nachdem du die Option 'Angriff' anklickst, wird deine [Flotte] sich in Bewegung setzen und die 
    [Flotte] des Feinds angreifen .
    </p><p>
    Wenn die Ziel [Flotte] in Bewegung ist, erscheint eine andere Option:
    </p><p><img src="/Resources/Images/en/AttackPursuit.png" alt="Flotte verfolgen" /></p><p>
    Das bedeutet dass deine [Flotte] die Ziel [Flotte] verfolgt bis sie attackiert wird.
    </p><p>
    Wenn deine [Flotte] ein <a href='/de/Universe/Planets.aspx'>Planet</a> attackiert, erscheinen die folgenden Optionen:
    <img src="/Resources/Images/en/Conquer2.png" alt="Attack a Planet" /></p><p>
    Diese Optionen bedeuten:
    </p><ul><li>Attackiere <a href='/de/Universe/Planets.aspx'>Planet</a> und <a href='/de/Universe/Conquer.aspx'>Erobern</a>: Wenn es keine Verteidigung gibt dann hast du mit <a href='/de/Universe/Conquer.aspx'>Erobern</a> den <a href='/de/Universe/Planets.aspx'>Planet</a> unverzüglich erobert. Andernfalls, ist eine [Battle] angefangen</li><li>Plündere <a href='/de/Universe/Planets.aspx'>Planet</a>: Wenn es keine Verteidigungseinheiten gibt, stiehlst du die Ressourcen ohne [Battle]. Andernfalls, fängt eine [Battle] an und du kannst die Ressourcen nur stehlen wenn du gewinnst. In diesem Fall, Wird der <a href='/de/Universe/Planets.aspx'>Planet</a> nicht erobert.</li></ul></div>
</asp:Content>