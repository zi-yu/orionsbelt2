<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Allianz
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Allianzen</h1>
<div class="content">
    Eine <a href='/de/Universe/Alliance.aspx'>Allianz</a> ist eine Gruppe von Spielern die ein gemeinsames Ziel teilt: Schutz, 
    Reichtum oder vielleicht Herrschaft. Du brauchst <a href='/de/Commerce/Orions.aspx'>Orions</a> um eine Allianz zu kreieren.
    Danach, kannst du Spieler einladen und akzeptieren, und ihnen ein angemessenen Rang geben. Die 
    verfügbaren Ränge sind:
    <ul><li>Admiral - Kommandoführer, Die Admirale sind die Führer der Allianz</li><li>Vize Admiral - 
    Zweiter im Kommando, Die Vize-Admirale sind zu sehen als wären sie fast Führer</li><li>Unteroffizier - Ein Mitglied der Allianz der beweist von Wert zu sein</li><li>Mitglied - 
    Rookie Mitglied</li></ul>
    Jede <a href='/de/Universe/Alliance.aspx'>Allianz</a> sollte versuchen soviele <a href='/de/Universe/Relics.aspx'>Reliquien</a> zu kriegen wie nur möglich. <a href='/de/Universe/Relics.aspx'>Reliquien</a> versorgen 
    Allianzen mit seltenen Ressourcen.
    <p></p><h2>Allianz Diplomatie</h2>
   Allianzen mögen in den Krieg gehen um nach Macht zu kämpfen, aber sie können auch einander 
   helfen. 
   Es gibt verschiedene Diplomatie Level die ein Admiral setzen kann für jede bekannte Allianz:
    <ul><li>Konföderation - Diese Allianzen agieren als eine</li><li>Null Agressionen Pakt - Du 
    solltest die Spieler dieser Allianz nicht angreifen</li><li>Neutral - Das standardmässige 
    diplomatische Level</li><li>Krieg! - Lass die Spiele beginnen!</li></ul>
    Beachte dass obwohl du im Frieden stehst mit einer anderen Allianz, das Spiel nicht verhindern 
    kann dass sie dich angreifen. Diese diplomatischen Zustände sind nur eine Vereinbarung die ohne 
    weitere Notiz gebrochen werden kann
  </div>
	
</asp:Content>