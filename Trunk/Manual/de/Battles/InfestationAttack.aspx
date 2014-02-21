<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Gift-Attacke
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Gift-Attacke</h1>
	<div class="content">
    <a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a> ist wie eine feindliche Einheit zu vergiften. Wenn eine Einheit getroffen wird 
     mit einer <a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a> Attacke, wird sie einen gewissen Anteil von Schaden während 3 Runden 
    erhalten (in diesen 3 Runden ist die Runde des Angriffs mitinbegriffen).
    <p>
    Die Grösse des Schadens ist äquivalent zu 20% des Schadens der durch die angreifende Einheit 
    gemacht wurde. Wenn eine Einheit dir einen Schaden von 1000 gemacht hat, in der ersten Runde (Die 
    Angriffs-Runde), erhält das Ziel 1200.
    In den nächsten 2 Runden wird sie einen Schaden von 200 pro Runde erhalten.
    </p><p>
    Dieser Angriff ist anwachsend was bedeutet dass ein Ziel-Einheit mehrere "Vergiftungen" zur 
    gleichen Zeit haben kann.
    </p><p>
    Dieser Angrif wird benutzt durch die <a class='blackwidow' href='/de/Unit/BlackWidow.aspx'>Schwarze Witwe</a> und dem <a class='hiveking' href='/de/Unit/HiveKing.aspx'>Bienenstock König</a>.
    </p><p>
    Hier ist ein Bild das zeigt wie ein <a class='hiveking' href='/de/Unit/HiveKing.aspx'>Bienenstock König</a> die "Infestation" benutzt gegen ein <a class='scarab' href='/de/Unit/Scarab.aspx'>Skarabäus</a>:
    <img class="block" src="/Resources/Images/Infestation.png" alt="Infestation Attack" /></p></div>
	
</asp:Content>