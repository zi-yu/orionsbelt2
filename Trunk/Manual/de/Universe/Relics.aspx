<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Reliquien
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Reliquien</h1>
<div class="content">
    Ein <a href='/de/Universe/Relics.aspx'>Relikt</a> ist ein besonderer Körper im <a href='/de/Universe/Default.aspx'>Universum</a>, speziell dafür designt für <a href='/de/Universe/Alliance.aspx'>Allianz</a> Kriege. 
    Wenn eine <a href='/de/Universe/Alliance.aspx'>Allianz</a> einen oder mehrere <a href='/de/Universe/Relics.aspx'>Reliquien</a> hat,
    erhalten alle Allianz-Mitglieder eine seltene Ressource pro Tag. Das Einkommen pro Spieler hängt 
    davon ab wieviele Reliquien die <a href='/de/Universe/Alliance.aspx'>Allianz</a> hat und seinem/ihrem Allianz Rang.
    <p>
    Das Gesamt-Einkommen das die <a href='/de/Universe/Alliance.aspx'>Allianz</a> erhalten wird angegeben durch die folgende Info:
    </p><ul><li>Jedes Relikt wird beisteuern mit K multipliziert durch ihren <a href='/de/Universe/HotZone.aspx#levels'>Zone-Level</a>; Wenn das 
    Relikt im Krieg ist, wird das Einkommen bis zu acht mal verringert</li><li>Die Summe des Einkommens 
    aller Reliquien wird multipliziert mit dem Prozentsatz der Reliquien im Universum die im Besitz der 
    Allianz sind</li></ul>
    Das bedeutet das je mehr <a href='/de/Universe/Relics.aspx'>Reliquien</a> man hat umso mehr Ressourcen abgegeben werden. K ist eine interne
    Konstante, die dem Wandel unterliegt. 
    <p>
    Jedes <a href='/de/Universe/Relics.aspx'>Relikt</a> hat seinen eigenen Beschützer: Ein Allianz Mitglied das dieses Relikt erobert und es 
    dann beschützen muss.
  </p></div>
	
</asp:Content>