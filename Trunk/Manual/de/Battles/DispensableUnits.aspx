<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kanonenfutter
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Taktiken</h2><ul><li><a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a></li><li><a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a></li><li><a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a></li><li><a href='/de/Battles/EagleStrike.aspx'>Adler Angriff</a></li><li><a href='/de/Battles/FiringSquad.aspx'>Erschiessungskommando</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Kanonenfutter</h1>
	<div class="content">
    Die <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> ist die <u>meistbenutzte Taktik auf <a href='http://www.orionsbelt.eu'>Orion's Belt</a></u>! Es werde kleine Mengen von 
    <a href='/de/Battles/Light.aspx'>Licht</a> benutzt um andere, wichtigere Einheiten auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> zu verteigen. Eine <a href='/de/Battles/Light.aspx'>Licht</a> 
    Einheit ist sehr günstig und hat gute Beweglichkeit deshalb wird sie aufgeopfert um mächtigere 
    <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu beschützen.
    Deshalb wird sie <i>Kanonen-Futter</i> genannt.
    <p>
    Normalerweise benutzen wir <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten, mit <a href='/de/Battles/Movement.aspx#MovAll'>Totale Beweglichkeit</a> und <a href='/de/Battles/Movement.aspx#MovCost'>Bewegungs-Kost</a> von 1 als
    <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>. Zum Beispiel:
    <a class='rain' href='/de/Unit/Rain.aspx'>Regen</a>, <a class='anubis' href='/de/Unit/Anubis.aspx'>Anubis</a>, <a class='seeker' href='/de/Unit/Seeker.aspx'>Sucher</a>, <a class='raptor' href='/de/Unit/Raptor.aspx'>Raptor</a> und wenn du wirklich verzweifelt bist: <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a>.

    </p><p>
    Lass unsdas folgende Beispiel analysieren:

    <img class="block" src="/Resources/Images/DispensableUnits1.png" alt="Beispiel 1 für Kanonen-&#xD;&#xA;    Futter 1" />

   Wie wir sehen können, haben wir zwei Gruppen von <a class='crusader' href='/de/Unit/Crusader.aspx'>Kreuzfahrer</a> die eine Gruppe von <a class='spider' href='/de/Unit/Spider.aspx'>Spinne</a> bedrohen. 
   Sie werden nicht in der Lage sein anzugreifen weil dort 2 kleine Gruppen <a class='anubis' href='/de/Unit/Anubis.aspx'>Anubis</a> im eg stehen. 
   Und so ist es nicht wert sich zu bewegen und anzugreifen nur um eine kleine Anzahl von 
   <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu zerstören.
    </p><p>
    Die <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> Taktik ist sehr wichtig und wird von allen Spielern benutzt. Aber den 
    gegnerischen Angriff zu deaktivieren ist nicht das Einzige was man mit <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> machen 
    kann.

    </p><h2>Gegner-Bewegung stoppen</h2>

    Auf <a href='http://www.orionsbelt.eu'>Orion's Belt</a> nur eine Einheit zu haben <a href='/de/Battles/Light.aspx'>Licht</a> auf einem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> Viereck. Und der Hauptvorteil 
    daran ist dass die gegnerische Einheit auf dieses Viereck gehen kann ohne die <a href='/de/Battles/Light.aspx'>Licht</a> zuerst zu 
    zerstören.
    Das bedeutet: Wir können <a href='/de/Battles/Light.aspx'>Licht</a> <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> benutzen um zu verhindern dass gegnerische 
    Einheiten auf eine Angriffsposition sich bewegen.
    Lass uns das vorige Beispiel analysieren, indem wir einen anderen Weg zeigen die <a class='spider' href='/de/Unit/Spider.aspx'>Spinne</a> zu 
    beschützen:

    <img class="block" src="/Resources/Images/DispensableUnits2.png" alt="Beispiel 1 für &#xD;&#xA;    Kanonenfutter" />

    Diese Methode ist besonders nützlich gegen Einheiten mit <a href='/de/Battles/Catapult.aspx'>Katapult</a>, die <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>  
    ignorieren und wie auch immer attackieren können. Also, wenn du den Angriff nicht verhindern 
    kannst, ziehe in Betracht die Bewegung die einen Angriff ermöglicht zu verhindern
    (vergiss diesen Tip nicht wenn du mit <a class='vector' href='/de/Unit/Vector.aspx'>Vektor</a> oder <a class='eagle' href='/de/Unit/Eagle.aspx'>Adler</a> zu tun hast ).

    <h2>Wie man Kanonen-Futter bekämpft?</h2>

    <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> zu bekämpfen kann zum Geduldsspiel werden, wo du weitermachst und die 
    <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> des Gegners zerstörst und bist du eine Öffnung kreieren, oder der Gegner ein 
    Fehler macht.
    <p>
    Dennoch, gibt es einige <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> die besonders nützlich sind gegen <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a>. Alle 
    Einheiten mit diesen Fähigkeiten:
    <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a>, <a href='/de/Battles/BombAttack.aspx'>Bombenattacke</a> and <a href='/de/Battles/Rebound.aspx'>Rückschlag</a> können mehr als eine Einheiten-Gruppe pro Angriff 
    zerstören. 
    Auf der anderen Seite, können Einheiten mit <a href='/de/Battles/Catapult.aspx'>Katapult</a> in <a href='/de/Battles/Range.aspx'>Reichweite</a> die 
    <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> des Gegners für einen direkten Angriff umzingeln.
    </p><p>
    Aber der beste Weg die <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> zu bekämpfen ist einfach sie alle zu zerstören! Wenn du 
    alle <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten deines Gegners zerstörst, wird er unfähig sein die <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> zu 
    benutzen und mit Sicherheit verlieren.
    Eine sehr gute Einheit gegen <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten ist der <a class='raptor' href='/de/Unit/Raptor.aspx'>Raptor</a>. Mit einem substantiellen Angriff-Bonus 
    gegen <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten und eine <a href='/de/Battles/Range.aspx'>Reichweite</a> von zwei, ist der <a class='raptor' href='/de/Unit/Raptor.aspx'>Raptor</a> <u>die</u> der ultimative 
    <a href='/de/Battles/Light.aspx'>Licht</a> Einheiten Jäger!

  </p></div>

</asp:Content>