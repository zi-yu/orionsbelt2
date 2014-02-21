<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Premium Dienste
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kommerz</h2><ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a></li><li><a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a></li><li><a href='/de/Commerce/Shop.aspx'>Premium Dienste</a></li><li><a href='/de/Commerce/Markets.aspx'>Märkte</a></li><li><a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Premium Services</h1>
<div class="content">
  Im <a href='/de/Commerce/Shop.aspx'>Premium Dienste</a> kannst du bestimmt Dienstleistungen kaufen die dir helfen werden das Schwierigkeitslevel 
  des Spiels zu reduzieren. Du kannst diese Dienstleistungen nur mit <a href='/de/Commerce/Orions.aspx'>Orions</a> kaufen.
  <p>
    Hier ist eine Liste der verfügbaren Dienstleistungen:
    </p><ul><li><a href='/de/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Erhalte 30% Abzug auf spezifische Kosten von Gebäuden und Einheiten.</a></li><li><a href='/de/Commerce/Shop.aspx#BuyRareDeduction'>Erhalten ein 30% Erlass auf seltene Ressource-Kosten von Gebäuden und Einheiten</a></li><li><a href='/de/Commerce/Shop.aspx#BuyQueueSpace'>Zusätzliche 3 Slots erhältlich auf deiner Warteliste. Diese zusätzlichen Slots stehen dir zur Verfügung in deiner Warteliste für Gebäude und Einheiten.</a></li><li><a href='/de/Commerce/Shop.aspx#BuyFastSpeed'>Baue alles 50% schneller.</a></li><li><a href='/de/Commerce/Shop.aspx#BuyFullLineOfSight'>Kein Nebel des Krieges entdeckt</a></li><li><a href='/de/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Mache das ganze Universum sichtbar</a></li></ul><a name="BuyIntrinsicDeduction" id="BuyIntrinsicDeduction"></a><h2><a href='/de/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Erhalte 30% Abzug auf spezifische Kosten von Gebäuden und Einheiten.</a></h2>
   Mit dieser Dienstleistung aktiv kannst du die <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Kosten deiner <a href='/de/FacilityIndex.aspx'>Gebäude</a> und <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> um 30% reduzieren. 
    Dies ist nur gültig für die Ressourcen deiner <a href='/de/Race/Races.aspx'>Rasse</a>, es wird die seltenen Ressourcen nicht 
    beeinträchtigen.
    
    <ul><li>Wenn du <a href='/de/Race/LightHumans.aspx'>Utopians</a> bist, beeinflusst es die <a class='energy' href='/de/Intrinsic/Energy.aspx'>Energie</a>, <a class='serium' href='/de/Intrinsic/Serium.aspx'>Serium</a> und <a class='mithril' href='/de/Intrinsic/Mithril.aspx'>Mithril</a> 
    Kosten</li><li>wenn du [DarkHumans bist], beeinflusst es die <a class='gold' href='/de/Intrinsic/Gold.aspx'>Gold</a>, <a class='titanium' href='/de/Intrinsic/Titanium.aspx'>Titanium</a> und <a class='uranium' href='/de/Intrinsic/Uranium.aspx'>Uranium</a> 
    Kosten</li><li>Wenn du <a href='/de/Race/Bugs.aspx'>Levyr</a> bist, beeinflusst es die <a class='protol' href='/de/Intrinsic/Protol.aspx'>Protol</a> und <a class='elk' href='/de/Intrinsic/Elk.aspx'>Nahrung</a> Kosten</li></ul><a name="BuyRareDeduction" id="BuyRareDeduction"></a><h2><a href='/de/Commerce/Shop.aspx#BuyRareDeduction'>Erhalten ein 30% Erlass auf seltene Ressource-Kosten von Gebäuden und Einheiten</a></h2>
    Mit dieser Dienstleistung aktiv werden die <a href='/de/IntrinsicIndex.aspx'>Speziell</a> Kosten deiner <a href='/de/FacilityIndex.aspx'>Gebäude</a> und 
    <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> um 30% reduziert.
    
    Ungleich zum vorherigen Service , ist dieser nur gültig für seltene Ressourcen: <a class='astatine' href='/de/Intrinsic/Astatine.aspx'>Astatine</a>, 
    <a class='prismal' href='/de/Intrinsic/Prismal.aspx'>Prismal</a>, <a class='radon' href='/de/Intrinsic/Radon.aspx'>Radon</a>, <a class='cryptium' href='/de/Intrinsic/Cryptium.aspx'>Cryptium</a>
    und <a class='argon' href='/de/Intrinsic/Argon.aspx'>Argon</a>.

    <a name="BuyQueueSpace" id="BuyQueueSpace"></a><h2><a href='/de/Commerce/Shop.aspx#BuyQueueSpace'>Zusätzliche 3 Slots erhältlich auf deiner Warteliste. Diese zusätzlichen Slots stehen dir zur Verfügung in deiner Warteliste für Gebäude und Einheiten.</a></h2>
    Die Warteliste ist die Menge an <a href='/de/FacilityIndex.aspx'>Gebäude</a> oder <a href='/de/UnitIndex.aspx'>Kampf-Einheiten</a> die du in Wartestellung setzen 
    kannst zu einer gegeben Zeit. Standardmässig, hat die Warteliste nur ein Slot. Das bedeut das 
    wenn du bereits was baust, ein Artikel in Wartestellung setzen kannst um in Produktion 
    zu gehen sobald die momentane Produktion zu Ende ist.
    <p>
    Mit diesem Service kannst du 3 Artikel in Wartestellung setzen.

    <a name="BuyFastSpeed" id="BuyFastSpeed"></a></p><h2><a href='/de/Commerce/Shop.aspx#BuyFastSpeed'>Baue alles 50% schneller.</a></h2>
    Die Dauer die eine Konstruktion beanspuchen kann, hängt von dem Produktions-Faktor ab und von dem 
    Artikel der gerade gebaut wird.
    Mit diesem Sevice, Wird dein Produktions-Faktor um 50% reduziert, das bedeutet das alles was du 
    baust, nur die Hälfte der Zeit beansprucht.

    <a name="BuyFullLineOfSight" id="BuyFullLineOfSight"></a><h2><a href='/de/Commerce/Shop.aspx#BuyFullLineOfSight'>Kein Nebel des Krieges entdeckt</a></h2>
    Du kannst Spieler nur sehen wenn sie sich in deiner <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> bewegen. Deine <a href='/de/Universe/LineOfSight.aspx'>Sichtlinie</a> 
    wird festgelegt durch die <a href='/de/Universe/Planets.aspx'>Planeten</a> und <a href='/de/Universe/Fleet.aspx'>Flotten</a> die du in deiner Nähe hast. Mit diesem Service, 
    bist du in der Lage die volle Sichtlinie zu haben in deinem erforschten Universum, wir werden dir 
    keinen Nebel des Krieges zeigen.

    <a name="BuyNoUndiscoveredUniverse" id="BuyNoUndiscoveredUniverse"></a><h2><a href='/de/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Mache das ganze Universum sichtbar</a></h2>
    Die schwarzen Vierecke im <a href='/de/Universe/Default.aspx'>Universum</a> sind unerforschter Raum. Du weisst nicht was es dort gibt, 
    und du musst <a href='/de/Universe/Travel.aspx'>Reisen</a> zu diesem Ort mit einer <a href='/de/Universe/Fleet.aspx'>Flotte</a> um zu sehen was dort ist. Mit diesem Sevice 
    wird das <b>all</b> Universum als bereits erforscht markiert.
  </div>
	
</asp:Content>