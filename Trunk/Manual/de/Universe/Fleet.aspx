<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Flotte
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Fleets</h1>
<div class="content">
   Die [Flotte] ist eine Gruppe von <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> die <a href='/de/Universe/Travel.aspx'>Reisen</a>(reisen) können im <a href='/de/Universe/Default.aspx'>Universum</a>. Es gibt 
    verschieden Arten von Flotten:
    <ul><li>Defense Fleets: Jeder <a href='/de/Universe/Planets.aspx'>Planet</a> hat eine Verteidigungs-Flotte. Diese Flotte ist 
    nicht bewegbar und wird nur benutzt wenn der Planet angegriffen wird.</li><li>Bewegbare Flotten: 
    auf deinen <a href='/de/Universe/Planets.aspx'>Planeten</a> kannst du 
    Flotten erschafen und sie zum <a href='/de/Universe/Travel.aspx'>Reisen</a> zu benutzen im <a href='/de/Universe/Default.aspx'>Universum</a></li><li>Ultimate Fleets: Wenn 
    eine Flotte eine <a href='/de/Battles/Ultimate.aspx'>Höchste</a> Einheit hat, wird es ultimative Flotte genannt</li></ul><h2>Wie 
    erzeugt man eine Flotte?</h2>
    Als erstes, musst du <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> bauen auf den Planeten deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a>. Wenn sie 
    fertiggestellt sind,
    werden sie in die Verteidigungsflotten des Planeten gestellt. Dann kannst du zu der
    <i>Fleets</i>Sektion von diesem Planeten gehen und eine neue kreieren. Danach bist du in der   
    Lage die <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> von der Verdeitungsflotte deines Planeten in eine neue zu bewegen.
    <p>
    Eine <a href='/de/Universe/Fleet.aspx'>Flotte</a> kann sich nur bewegen wenn es <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> hat und zur Zeit inaktiv ist.
    
    </p><h2>Was können Flotten machen?</h2>
    Die erste Anwendung der Flotte ist zu <a href='/de/Universe/Travel.aspx'>Reisen</a>(reisen) in deine <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a>. Mit der 
    <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> wirst du in der Lage sein jede Zone zu eforschen. Du wirst auch in der Lage sein  
    <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Ressourcen einzufangen und andere <a href='/de/Universe/Planets.aspx'>Planeten</a> zu besiedeln.
     Wenn du bereit bist, kannst du das <a href='/de/Universe/WormHole.aspx'>Wurmloch</a> benutzen um in die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> zu <a href='/de/Universe/Travel.aspx'>Reisen</a>(reisen).
    <p>
    In der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> wirst du in der Lage sein andere Flotten zu attackieren, Planeten mit <a href='/de/Universe/Raids.aspx'>Plünderung</a> 
    zu plündern, <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> zu machen und vieles mehr. 
    
    </p><h2>Flotten-Fracht</h2>
    Jede Flotte hat einen Frachtraum wo man <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Ressourcen lagern kann. Wenn deine Flotte 
    eine Fracht geladen hat,
    kannst du zu einem Planeten von dir gehen um die Fracht zu den Ressourcen abzuladen. Bemerke dass 
    wenn du angegriffen wirst und verlierst, behält dein Gegner deine Fracht als Beutegut.
    <p>
    Die Verteidigungsflotte deines Heimatplaneten wird auch benutzt Ressourcen zu benutzen die du im 
    <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> kaufst.

    </p><h2>Flotten-Farben</h2>
    In der <a href='/de/Universe/Default.aspx'>Universum</a> Ansicht wirst du verschiedene <a href='/de/Universe/Fleet.aspx'>Flotten</a> mit verschiedenen Farben sehen. Jede 
    Farbe hat ihre eigene Bedeutung, und ist abhängig von deinem diplomatischen Status mit der 
    <a href='/de/Universe/Alliance.aspx'>Allianz</a> des jeweiligen Flotten-Besitzers:
    <ul><li>Graue Farbe: du bist neutral für diesen Spieler</li><li>Gelbe Farbe: Du hast einen 
    Null-Agressionen Pakt mit diesem Spieler</li><li>Blaue Farbe: dieser Spieler ist dein 
    Verbündeter</li><li>Rote Farbe: Diese Flotte ist dein Feind!</li></ul></div>
	
</asp:Content>