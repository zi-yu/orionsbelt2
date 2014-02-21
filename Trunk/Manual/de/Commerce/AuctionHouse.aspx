<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Auktions-Haus
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kommerz</h2><ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a></li><li><a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a></li><li><a href='/de/Commerce/Shop.aspx'>Premium Dienste</a></li><li><a href='/de/Commerce/Markets.aspx'>Märkte</a></li><li><a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Auktions-Haus</h1>
	<div class="description">
	Das <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> ist ein Ort wo ein Spieler einem anderen Spieler Sachen abkaufen oder verkaufen kann. Die Transaktionen werden immer <a href='/de/Commerce/Orions.aspx'>Orions</a> als Kaufwährung benutzt. <p></p><h2>
    Was kann ich verkaufen und wie kann ich es verkaufen?
  </h2>
  Du kannst Ressourcen und <a href='/de/UnitIndex.aspx'>Einheiten</a> verkaufen. Um <a href='/de/UnitIndex.aspx'>Einheiten</a> zu verkaufen müssen sie in der Verteidigungs- <a href='/de/Universe/Fleet.aspx'>Flotte</a> sein auf deinem Heimat- <a href='/de/Universe/Planets.aspx'>Planet</a>. <p>
  Um zu verkaufen (versteigern) muss man zur Seite des <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> gehen und fortfahren zur Seite 
  "Ins Auktionshaus stellen". </p><p>
  Auf dieser Seite kannst du die Ressourcen/<a href='/de/UnitIndex.aspx'>Einheiten</a> sehen die du zur Versteigerung freigibst, Die 
  Anzahl dr Produkte, die minimale Anzahl von Angeboten,
  den Wert für einen unverzüglichen Verkauf, die Zeit die die Produkte im <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> bleiben und 
  ob für das Produkt das zum Verkauf frei ist, Werbung gemacht werden soll.
  Die benötigten Felder sind die Anzahl und der Basis-Wert für Angebote. </p><p>
  Es ist notwendig dass der Spieler die Konten innerhalb der letzten 3 Tage nicht geändert hat um 
  Artikel im <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a>zu stellen.</p><p></p><h2>
    Wie findet der Kauf statt?
  </h2>
  Während der Zeit die man gewählt hat als das Produkt ins <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> gestellt wurde, ist es 
  möglich für Spieler Angebote zu machen oder das Produkt sofort zu verkaufen.
  Für den unverzüglichen Kauf erhält der Verkäufer die <a href='/de/Commerce/Orions.aspx'>Orions</a> sofort, in dem Fall dass geboten wird, erhält der Verkäufer die <a href='/de/Commerce/Orions.aspx'>Orions</a> nur dann wenn die Zeit des Bietens vorbei ist. <p>
  Alle Verkäufe haben ein <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> Tarif that can der von 8% bis 25% variiert, je grösser der 
  finale Verkaufswert ist umso niedriger ist der Tarif.
  Das bedeutet der Verkäufer erhält den Wert des Verkaufs (bezahlt durch einen anderen Spieler) 
  abzüglich des <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> Tarifs. </p><p>
  In dem Fall dass das Produkt nicht verkauft wird: wenn es eine Einheit ist kehr sie zurück zu der 
  Verteidiguns- <a href='/de/Universe/Fleet.aspx'>Flotte</a> auf dem Heimat- <a href='/de/Universe/Planets.aspx'>Planet</a>, wenn es eine Ressource ist geht es zum Depot
  der Ressourcen bis das maximale Limit erreicht ist. </p><p>
  Es gibt auch eine Seite wo der Spieler die Produkte sehen kann the products die er ins  
  <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a> gestellt hat, und die Produkte die bereits von ihm/ihr verkauft wurdem im 
  <a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a>. </p><p></p><h2>Wie findet der Kauf statt? </h2>
  Nach dem Angebotsgewinn erhält der Spieler das gekaufte Produkt in der Verteidigungs- <a href='/de/Universe/Fleet.aspx'>Flotte</a> auf 
  dem Heimat-<a href='/de/Universe/Planets.aspx'>Planet</a>. In dem Fall dass das Produkt eine Einheit ist erscheint es sofort in der 
  <a href='/de/Universe/Fleet.aspx'>Flotte</a> und ist bereit um zu einer anderen <a href='/de/Universe/Fleet.aspx'>Flotte</a> bewegt zu werden die dann über das 
  <a href='/de/Universe/Default.aspx'>Universum</a> navigieren kann. <p>
  In dem Fall dass das Produkt eine Ressource ist oder eine <a href='/de/Battles/Ultimate.aspx'>Höchste</a> geht es zur Fracht 
  Verteidigungs- <a href='/de/Universe/Fleet.aspx'>Flotte</a>'s auf dem Heimat- <a href='/de/Universe/Planets.aspx'>Planet</a>. In dem Falle der Ressourcen können sie entladen 
  werden von der Fracht zum Depot der Ressourcen, in dem Falle der <a href='/de/Battles/Ultimate.aspx'>Höchste</a> wird eine <a href='/de/Universe/Fleet.aspx'>Flotte</a> 
  kreiert im Orbit des Heimat- <a href='/de/Universe/Planets.aspx'>Planet</a> wenn der Spieler das <a href='/de/Universe/Fleet.aspx'>Flotten</a> Limit noch nicht erreicht hat,
  andererseits kann der Spieler die <a href='/de/Battles/Ultimate.aspx'>Höchste</a> nicht abladen.</p>
	</div>
	
</asp:Content>