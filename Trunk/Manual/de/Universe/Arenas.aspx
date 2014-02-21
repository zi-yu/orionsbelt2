<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Arenen
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Arenen</h1>
	<div class="description">
	Die <a href='/de/Universe/Arenas.aspx'>Arena</a> ist der Platz der Wahl für kriegerische Spieler, wo es eine Chance gibt für Ruhm und Ehre 
  zu kämpfen. <p>
  Es gibt unzählige <a href='/de/Universe/Arenas.aspx'>Arenen</a> im ganzen <a href='/de/Universe/Default.aspx'>Universum</a>, wobei je näher es zum Zentrum des <a href='/de/Universe/Default.aspx'>Universum</a> ist umso grösser ist die Belohnung für den Sieg. </p><p>
  Wenn ein Spieler eine leere <a href='/de/Universe/Arenas.aspx'>Arena</a> findet wird er automatisch zum Champion dieser <a href='/de/Universe/Arenas.aspx'>Arena</a>, andernfalls kann er den gegenwärtigen Champion herausfordern, und die [Flotte] der Schlacht wird eine [Flotte] sein die nicht vor irgendeinem der Spieler ausgewählt wird, sondern eine [Flotte] die gleich für beide Spieler ist und die von der <a href='/de/Universe/Arenas.aspx'>Arena</a> für eine Schlacht zur Verfügung gestellt wird. Im Falle des Siegs wird der Champion ungekrönt und
  der neue Champion wird für diese <a href='/de/Universe/Arenas.aspx'>Arena</a> gekrönt. </p><p>
  Aber der grösste Ansporn ist die Möglichkeit <a href='/de/Commerce/Orions.aspx'>Orions</a> zu gewinnen. Der Herausforderer muss <a href='/de/Commerce/Orions.aspx'>Orions</a> bezahlen um den Champion herauszufordern, und wenn der Champion die Schlacht gewinnt, dann gewinnt er auch einen Teil der <a href='/de/Commerce/Orions.aspx'>Orions</a> die von dem Herausforderer bezahlt wurde. Je mehr <a href='/de/Universe/Arenas.aspx'>Arena</a> Schlachten der Spieler gewinnt umso mehr Punkte verdient er für den Beruf des <a href='/de/GladiatorQuests.aspx'>Gladiator</a>.
Die einzige Frage ist - <i>Mit wievielen <a href='/de/Universe/Arenas.aspx'>Arenen</a> kannst du fertigwerden als Champion?</i></p>
	</div>
	
</asp:Content>