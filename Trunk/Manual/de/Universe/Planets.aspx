<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Planeten
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Universum</h2><ul><li><a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a></li><li><a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a></li><li><a href='/de/Universe/Coordinates.aspx'>Koordinaten</a></li></ul><h2>Universum Aktionen</h2><ul><li><a href='/de/Universe/Travel.aspx'>Reisen</a></li><li><a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a></li><li><a href='/de/Universe/Colonize.aspx'>Besiedeln</a></li><li><a href='/de/Universe/UniverseAttack.aspx'>Angriff</a></li><li><a href='/de/Universe/Conquer.aspx'>Erobern</a></li><li><a href='/de/Universe/Raids.aspx'>Plünderung</a></li><li><a href='/de/Universe/UnloadCargo.aspx'>Fracht abladen</a></li><li><a href='/de/Universe/DevastationAttack.aspx'>Zerstörungs-Attacke</a></li></ul><h2>Elemente des Universums</h2><ul><li><a href='/de/Universe/Planets.aspx'>Planeten</a></li><li><a href='/de/Universe/WormHole.aspx'>Wurmloch</a></li><li><a href='/de/Universe/Fleet.aspx'>Flotte</a></li><li><a href='/de/Universe/Arenas.aspx'>Arenen</a></li><li><a href='/de/Universe/Beacon.aspx'>Wachposten</a></li><li>[Academy]</li><li>[PirateBay]</li></ul><h2>Andere</h2><ul><li><a href='/de/Universe/Alliance.aspx'>Allianz</a></li><li><a href='/de/Universe/Relics.aspx'>Reliquien</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Planeten</h1>
<div class="content">
    Die Planeten sind das Herz und die Seele deines Imperiums. Sie versorgen dich mit <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Ressourcen, du kannst Planeten
    <a href='/de/FacilityIndex.aspx'>Gebäude</a>bauen, und sie erlauben dir auch <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu bauen. Je mehr Planeten du hast 
     umso mächtiger wirst du sein. Du kannst zwei Arten von Planeten haben: Planeten in der 
    <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> und Planeten in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a>.
    
    <h2>Private Zone Planeten</h2>
    Die Planeten in deiner <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> sind die wichtigsten.Sie haben all die Hauptgebäude und du 
    wirst sie niemals verlieren können, als vergiss nicht sie zu aufzubessern. Diese Planeten sind 
    auch die einzigen die es dir erlauben <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu bauen.
    <p>
    Das einzige Problem mit den Planeten der <a href='/de/Universe/PrivateZone.aspx'>Privat-Zone</a> ist dass sie keine seltenen <a href='/de/IntrinsicIndex.aspx'>Spezifisch</a> 
     generieren können. Du musst dich in die <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> begeben um sie zu bekommen.
    
    </p><h2>Hot Zone Planeten</h2>
    Planeten in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> sind ähnlich zu Minen. Si sind sehr einfach, und du kannst nur wenige 
    Gebäude auf ihnen bauen (zum Beispiel, der <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a>) und sie können attackiert (siehe
    <a href='/de/Universe/UniverseAttack.aspx'>Angriff</a>) und geplündert
    (siehe <a href='/de/Universe/Raids.aspx'>Plünderung</a>) werden von anderen Spielern.
    <p>
    Trotz der Risiken, diese Planeten sind essentiell, weil sie dich mit seltenen Ressourcen 
    versorgen: <a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a>,
    <a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a>, <a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a>, <a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a> and <a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a>. Du kannst sie über das <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> Gebäude kriegen. 
    Ohne diese seltenen Ressourcen wirst du nicht in der Lage sein Gebäude aufzurüsten oder mächtige 
    <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> zu bauen.
    </p><p>
    Du kannst ein Maximum von 8 Planeten in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a> haben. Jeder Planet in der <a href='/de/Universe/HotZone.aspx'>Öffentlice Zone</a>hat ein 
    <a href='/de/Universe/HotZone.aspx#levels'>Zone-Level</a>. 
    Je höher der Zone Level, umso mehr Ressourcen wirst du mit dem <a class='extractor' href='/de/Facility/Extractor.aspx'>Extraktor</a> sammeln können.

    <a name="Capacity" id="Capacity"></a></p><h2>Resource Limit</h2>
    Jeder Planet hat seine eigenen Attribute die dein Ressourcen-Einkommen alle 10 Minuten erhöhen. 
    Alle diese Ressourcen sind global zu allen deinen Planeten, aber du hast einen Limit. Deine
    Ressourcen nicht über dein Ressourcen-Limit steigen. Um dein Ressourcen-Limit zu erhöhen   
    kannst du:
    <ul><li>Wenn deine Rasse die <a href='/de/Race/LightHumans.aspx'>Utopians</a> ist, musst du ein <a class='silo' href='/de/Facility/Silo.aspx'>Silo</a> bauen und das <a class='commandcenter' href='/de/Facility/CommandCenter.aspx'>Zentralkommando</a></li><li>Wenn deine Rasse die <a href='/de/Race/DarkHumans.aspx'>Renegades</a> ist, musst du das <a class='slavewarehouse' href='/de/Facility/SlaveWarehouse.aspx'>Sklaven Warenlager</a> bauen und <a class='darknesshall' href='/de/Facility/DarknessHall.aspx'>Halle der Dunkelheit</a></li><li>Wenn deine Rasse die <a href='/de/Race/Bugs.aspx'>Levyr</a> ist, musst du das <a class='nest' href='/de/Facility/Nest.aspx'>Nest</a> bauen</li></ul></div>
	
</asp:Content>