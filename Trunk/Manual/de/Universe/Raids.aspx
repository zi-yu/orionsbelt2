<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Plünderung
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1><h1>Plündern</h1>
<div class="content">
    Plündern besteht aus dem Angreifen eines <a href='/de/Universe/Planets.aspx'>Planet</a> des anderen Spielers mit der einzigen Absicht 
    <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Ressourcen zu stehlen
    Diese Aktion wird üblicherweise von <a href='/de/PirateQuests.aspx'>Pirat</a> Spielern auf ihren <a href='/de/Quests.aspx'>Missionen</a> durchgefürt, kann aber 
    auch von jedem anderen Spieler durchgeführt werden.
    <p>
    Wenn du einen Planeten plünderst, können zwei Dinge passieren:
    </p><ul><li>Die <a href='/de/Universe/Fleet.aspx'>Flotte</a> der Verteidigung des Planeten ist leer und das Plündern wird 
    durchgeführt</li><li>
    Der Planet hat ein paar wenige Verteidigunsmöglichkeiten und eine Schlacht auf dem <a href='/de/Battles/GameBoard.aspx'>Spielbrett</a>; 
    wird angefangen; nur wenn du gewinnst iwird die Plünderung durchgeführt.
 </li></ul>
    Aber auch wenn die Plünderung durchgeführt wird, kannst es passieren dass du überhaupt keine 
    Ressourcen kriegst. Es gibt einen Timeout für das Plündern um Missbrauch zu verhindrn, und so ist 
    es nur möglich einen Planeten alle 14 Stunden zu plündern.
    <p>
    Wenn die Plünderung erfolgreich war, das wirst du einigen Ressourcen stehlen können und dein 
    <a href='/de/PirateQuests.aspx'>Pirat</a> Rang wird erhöht. Du wirst zwei verschiedene Arten von Ressourcen stehlen. Eine 
    Ressource nach zufälliger Auswahl und die andere ist die, die der Besitzer des Zielplaneten am 
    meisten zu Verfügung steht. Und das ist unterschiedlich für jede <a href='/de/Race/Races.aspx'>Rasse</a>:
    </p><ul><li>Wenn du einen <a href='/de/Race/LightHumans.aspx'>Utopians</a> Planeten anvisierst, erhälst du <a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a></li><li>Wenn du 
    einen <a href='/de/Race/DarkHumans.aspx'>Renegades</a> Planeten anvisierst, erhälst du <a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a></li><li>Wenn du einen<a href='/de/Race/Bugs.aspx'>Levyr</a> 
    Planeten anvisierst, erhälst du <a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a></li></ul>
    Die gestohlene Quantität ist eine kleiner Prozentsatz des Totalbetrags des Zielspielers, and 
    Planeten mit höherem Level bieten bessere Prozentsätze.
   </div></h1>
	
</asp:Content>