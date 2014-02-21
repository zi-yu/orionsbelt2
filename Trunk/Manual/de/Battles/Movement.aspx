<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Beweglichkeit
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Konzepte</h2><ul><li><a href='/de/Battles/GameBoard.aspx'>Spielbrett</a></li><li><a href='/de/Battles/Deploy.aspx'>Positionieren</a></li><li><a href='/de/Battles/Movement.aspx'>Beweglichkeit</a></li><li><a href='/de/Battles/Rules.aspx'>Regeln</a></li></ul><h2>Angriff</h2><ul><li><a href='/de/Battles/Range.aspx'>Reichweite</a></li><li><a href='/de/Battles/Catapult.aspx'>Katapult</a></li><li><a href='/de/Battles/ParalyseAttack.aspx'>Paralisier-Attacke</a></li><li><a href='/de/Battles/Replicator.aspx'>Replikator</a></li><li><a href='/de/Battles/StrikeBack.aspx'>Gegenangriff</a></li><li><a href='/de/Battles/InfestationAttack.aspx'>Gift-Attacke</a></li><li><a href='/de/Battles/RemoveAbilityAttack.aspx'>Fähigkeiten entfernen</a></li><li><a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a></li><li><a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a></li><li><a href='/de/Battles/Rebound.aspx'>Rückprall</a></li></ul><h2>Kategorie</h2><ul><li><a href='/de/Battles/Light.aspx'>Licht</a></li><li><a href='/de/Battles/Medium.aspx'>Medium</a></li><li><a href='/de/Battles/Heavy.aspx'>Schwer</a></li><li><a href='/de/Battles/Ultimate.aspx'>Höchste</a></li><li><a href='/de/Battles/Special.aspx'>Spezial</a></li></ul><h2>Schlacht-Typ</h2><ul><li><a href='/de/Battles/TotalAnnihilation.aspx'>Totale Zerstörung</a></li><li><a href='/de/Battles/Regicide.aspx'>Königsmord</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Schlacht-Bewegungen</h1>
<div class="content">
    Schlacht-Bewegungen bezieht sich auf den Akt <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> zu bewegen, 
    nachdem man mit dem <a href='/de/Battles/Deploy.aspx'>Positionieren</a> fertig ist.
    Jede Einheit hat ihren eigenen Bewegungs-Typ:
    <ul><li><a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a></li><li><a href='/de/Battles/Movement.aspx#MovNormal'>Normale Bewegung</a></li><li><a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a></li><li><a href='/de/Battles/Movement.aspx#MovFront'>Frontal-Bewegung</a></li><li><a href='/de/Battles/Movement.aspx#MovDrop'>Sturz-Bewegung</a></li><li><a href='/de/Battles/Movement.aspx#MovNone'>Keine Bewegung</a></li></ul>
    Der Bewegungs-Typ und die <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a> definiert die Geschwindigkeit der Einheit.

    <a name="MovAll" id="MovAll"></a><h2><a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a></h2> 
    Mit <a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a> kann die Einheit sich zu einem benachbarten Viereck bewegen. Beispiel:
    <img class="block" src="/Resources/Images/MovAll.png" alt="Mov All" /><a name="MovNormal" id="MovNormal"></a><h2><a href='/de/Battles/Movement.aspx#MovNormal'>Normale Bewegung</a></h2>
    Mit <a href='/de/Battles/Movement.aspx#MovNormal'>Normale Bewegung</a> kann die Einheit sich zu einem benachbarten Viereck bewegen, mit Ausnahme der 
    diagonalen. Beispiel:
    <img class="block" src="/Resources/Images/MovNormal.png" alt="Mov Normal" /><a name="MovDiagonal" id="MovDiagonal"></a><h2><a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a></h2>
    Mit <a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a> kann eine Einheit sich nur diagonal bewegen (achte auf die <a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a>). 
    Beispiel:
    <img class="block" src="/Resources/Images/MovDiagonal.png" alt="Mov Diagonal" /><a name="MovFront" id="MovFront"></a><h2><a href='/de/Battles/Movement.aspx#MovFront'>Frontal-Bewegung</a></h2>
    Mit <a href='/de/Battles/Movement.aspx#MovFront'>Frontal-Bewegung</a> kann die Einheit sich nur geradeaus bewegen. Wenn du die Richtung ändern musst, 
    musst du die Rotation benutzen. Beispiel:
    <img class="block" src="/Resources/Images/MovFront.png" alt="Mov Front" /><a name="MovDrop" id="MovDrop"></a><h2><a href='/de/Battles/Movement.aspx#MovDrop'>Sturz-Bewegung</a></h2>
    AEine Einheit mit <a href='/de/Battles/Movement.aspx#MovDrop'>Sturz-Bewegung</a> ist eine Einheit die eine andere Einheit abwerfen kann auf dem 
    <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>.
    Beispiel: Die <a class='queen' href='/de/Unit/Queen.aspx'>Königin</a> kann ein <a class='egg' href='/de/Unit/Egg.aspx'>Ei</a> abwerfen auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>.

    <a name="MovNone" id="MovNone"></a><h2><a href='/de/Battles/Movement.aspx#MovNone'>Keine Bewegung</a></h2>
    Eine Einheit mit <a href='/de/Battles/Movement.aspx#MovNone'>Keine Bewegung</a> kann sich während einer Schlacht nicht bewegen. Beispiel:
    <img class="block" src="/Resources/Images/MovNone.png" alt="Mov Nove" /><a name="MovCost" id="MovCost"></a><h2><a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a></h2>
    Der <a href='/de/Battles/Movement.aspx'>Beweglichkeit</a> Typ definiert wie eine Einheit sich bewegen kann auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>, Aber alle 
    <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> haben auch eine <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a> die ihre Geschwindigkeit beeinflusst. In jeder Schlacht-
    Runde, hat der Spieler 6 <a href='/de/Battles/Movement.aspx#MovPoints'>Bewegungs-Punkte</a> die er ausgeben kann: er kann Einheiten bewegen, Einheiten 
    angreifen, oder sie sogar ignorieren.
    <p>
    Wenn eine Einheit eine <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a> von 2 hat, bedeutet das, dass wir sie 3 Mal in der gleichen 
    Runde bewegen können (6/2=3).
    Zum Beispiel, hat der <a class='doomer' href='/de/Unit/Doomer.aspx'>Doomer</a> eine Kost von 3 und die <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> eine Kost von 2. Und das macht die 
    <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> schneller als die <a class='doomer' href='/de/Unit/Doomer.aspx'>Doomer</a>, auch wenn beide Einheiten <a href='/de/Battles/Movement.aspx#MovDiagonal'>Diagonale Bewegung</a> benutzen.

    <a name="MovPoints" id="MovPoints"></a></p><h2><a href='/de/Battles/Movement.aspx#MovPoints'>Bewegungs-Punkte</a></h2>
    Die <a href='/de/Battles/Movement.aspx#MovPoints'>Bewegungs-Punkte</a> represäntieren wieviele Aktionen du machen kannst während einer Runde. In jeder 
    Runde erhälst du 6 <a href='/de/Battles/Movement.aspx#MovPoints'>Bewegungs-Punkte</a> die du ausgeben kannst, und es gibt mehrere Aktion die du machen 
    kannst:
    <ul><li>Ein Angriff kostet ein Bewegungs-Punkt</li><li>Eine Einheit zu bewegen hat eine damit 
    verbundene Kost. Alle <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a>
    haben eine definierte <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a></li><li>Eine Einheiten-Gruppe aufzuteilen, kostet dich doppelt 
    soviel wie diese Gruppe zu bewegen</li></ul></div>
	
</asp:Content>