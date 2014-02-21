<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Sichtlinie
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Sichtlinie</h1>
	<div class="content">
   <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> ist das sichtbare Gebiet das etwas was in deinem Besitz ist umgibt. z.B. (eine [Flotte], ein <a href='/de/Universe/Planets.aspx'>Planet</a>, etc). In diese, Gebiet kannst du alles sehen was sich bewegt, inklusive der feindlichen Einheiten.
   <p>
   Es gibt 3 verschieden Arten von <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a>:
   </p><p></p><ul><li>
 <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> ein Viereck um deine [Flotte] herum. Diese <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> kommt in [Flotten] vor die nur <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten haben.<p><img src="/Resources/Images/LineOfSight.png" alt="Line of Sight 1 Square Around" /></p></li><li>
 <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> zwei Vierecke um deine [Flotte] oder <a href='/de/Universe/Planets.aspx'>Planet</a>  herum. Die <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> kommt vor in [Flotte]n mit mindestens , eine <a href='/de/Battles/Medium.aspx'>Medium</a> oder <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheit und <a href='/de/Universe/Planets.aspx'>Planet</a>.<p><img src="/Resources/Images/LineOfSight2.png" alt="Line of Sight 2 Square Around" /></p></li><li>
 <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> drei Vierecke um den <a href='/de/Universe/Beacon.aspx'>Wachposten</a> herum :<p><img src="/Resources/Images/LineOfSight3.png" alt="Line of Sight 3 Squares Around" /></p></li></ul><p></p></div>
</asp:Content>