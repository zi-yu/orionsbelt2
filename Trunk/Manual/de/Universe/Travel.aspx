﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Reisen
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Reisen</h1>
	<div class="content">
    Wenn du <a href='/de/Universe/Travel.aspx'>Reisen</a> im Universum machen willst, brauchst du nur eine Sache: Eine [Flotte] mit 
    Einheiten. 
    <p>
    Das folgende Bild ist das anfägliche Stadium deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> wo eine bewegbare <a href='/de/Universe/Fleet.aspx'>Flotte</a> bereit 
    ist sich in Bewegung zu setzten.
    </p><p><img src="/Resources/Images/PrivateZoneInitialState.png" alt="Anfängliches Stadium deiner Private Zone" /></p><p>
    Um die Flotte zu bewegen klicke einfach drauf und dann klicke auf eine unerforschte Gegend. Dann
    wähle die Option "Flotte bewegen". Das folgende Video wird dir zeigen wie:
    </p><p></p></div>
</asp:Content>