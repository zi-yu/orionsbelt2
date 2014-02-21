<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Kamikaze Bedrohung
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kampf-Taktiken</h2><ul><li><a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a></li><li><a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a></li><li><a href='/de/Battles/DiagonalTrap.aspx'>Diagonale Falle</a></li><li><a href='/de/Battles/EagleStrike.aspx'>Adler Angriff</a></li><li><a href='/de/Battles/FiringSquad.aspx'>Erschiessungskommando</a></li><ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">

	<h1>Kamikaze Bedrohung</h1>
<div class="content">
    <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> eine der wichtigsten <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> im Spiel. Sie sind sehr zerbrechlich, aber sie 
    haben eine enorme Zerstörerungskraft und eine Bewegungsfreiheit fast jed Ecke des <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> zu 
    erreichen.
    Aufgrund dieser Charakteristiken, <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> im Spiel zu haben ist immer <i>Bedrohung</i> für den 
    Gegner.
    Trotzallem, musst du diese <i>Bedrohung</i> direkt und dauerhaft anwenden!
    <p>
    Wenn du eine Gruppe von <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> hast die hinter <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> steckengeblieben oder ausserhalb 
    der <a href='/de/Battles/Range.aspx'>Reichweite</a> sind, dann werden sie nicht als Bedrohung gesehen, zumindest in den folgenden Runden. 
    Aber ein guter <a href='/de/Battles/Deploy.aspx'>Positionieren</a> kann die <a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a> gleich von Anfang an verstärken. Lass uns das 
    folgende Beispiel analysieren:

    <img class="block" src="/Resources/Images/KamikazeMenace.png" alt="Kamikaze Bedrohung Beispiel" />

    Wie wir sehen können, hat der untere Spieler zwei Gruppen von <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a>, eine auf jeder Seite 
    des <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>, beschützt durch <a href='/de/Battles/Heavy.aspx'>Schwer</a> Einheiten, und mit einer offenen Angriffsroute.
    </p><p>
    Diese Disposition erlaubt dem unteren Spieler  mit einer Gruppe von <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> mit Leichtigkeit 
    auf dem gesamten <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a> zuzuschlagen. Und das ist sehr wichtig, weil während er keine 
    <a href='/de/Battles/Movement.aspx#MovPoints'>Bewegungs-Punkte</a> mit ihnen ausgeben braucht muss der Gegner sich immer der <i>Bedrohung</i> bewusst 
    sein und <a href='/de/Battles/DispensableUnits.aspx'>Kanonenfutter</a> benutzen um jede seiner/ihrer Bewegungen zu beschützen.
    </p><p>
    Diese <i>Bedrohung</i> verändert komplett die Strategie des Gegners, und limitiert ihn/sie immens.

    </p><h2>Wie bekämpft man eine Kamikaze Bedrohung?</h2>

    Es ist sehr schwierig die <a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a> zu kämpfen weil wenn du es machst erlaubt es dem 
    Gegner <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu strategischen Positionen zu bewegen. Dennoch gibt es einige Dinge die in 
    Betracht gezogen werden müssen:
    <ul><li>
    Wenn du <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> mit <a href='/de/Battles/Catapult.aspx'>Katapult</a>, <a href='/de/Battles/Rebound.aspx'>Rückschlag</a> oder <a href='/de/Battles/TripleAttack.aspx'>Dreifach-Attacke</a> hast, kannst du sie benutzen 
    um die <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> zu zerstören
  </li><li>
   Eine andere Strategie ist zu versuchen den Gegner zu zwingen die <a class='kamikaze' href='/de/Unit/Kamikaze.aspx'>Kamikaze</a> zu benutzen gegen 
   Einheiten die leicht zu opfern sind;
    Auf diese Weise ist es vielleicht möglich die <a href='/de/Battles/KamikazeMenace.aspx'>Kamikaze Bedrohung</a> zu entfernen von anderen 
    wichtigeren <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a>
  </li></ul></div>

</asp:Content>