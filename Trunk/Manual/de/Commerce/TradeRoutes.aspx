<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/de/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Handelsrouten
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Kommerz</h2><ul><li><a href='/de/Commerce/Orions.aspx'>Orions</a></li><li><a href='/de/Commerce/AuctionHouse.aspx'>Auktions-Haus</a></li><li><a href='/de/Commerce/Shop.aspx'>Premium Dienste</a></li><li><a href='/de/Commerce/Markets.aspx'>Märkte</a></li><li><a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Handels-Routen</h1>
<div class="content">
    Eine <a href='/de/Commerce/TradeRoutes.aspx'>Handelsroute</a> ist der Prozess das Frachtgut von einem <a href='/de/Commerce/Markets.aspx'>Markt</a> zu laden und in einem anderen 
    <a href='/de/Commerce/Markets.aspx'>Markt</a> abzuliefern.
    <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> sind gewöhnlich Missions- <a href='/de/Quests.aspx'>Missionen</a> für die <a href='/de/MerchantQuests.aspx'>Händler</a> . Eigentlich, bist du nur in 
    der Lage Frachtgüter von einem <a href='/de/Commerce/Markets.aspx'>Markt</a> zu laden wenn du auf einer Handelsmission bist.
    <p>
    Jeder <a href='/de/Commerce/Markets.aspx'>Markt</a> handelt mit spezifischen Handelsgütern. Zum Beispiel, kannst du einen <a href='/de/Commerce/Markets.aspx'>Markt</a> 
    finden der nur mit <a class='supplies' href='/de/Intrinsic/Supplies.aspx'>Vorräte</a> handelt. Du kannst <a class='supplies' href='/de/Intrinsic/Supplies.aspx'>Vorräte</a> zu deiner <a href='/de/Universe/Fleet.aspx'>Flotte</a> hochladen auf diesem 
    <a href='/de/Commerce/Markets.aspx'>Markt</a>, aber der <a href='/de/Commerce/Markets.aspx'>Markt</a> wird keine <a class='supplies' href='/de/Intrinsic/Supplies.aspx'>Vorräte</a> als Handelsroute akzeptieren.
    </p><p>
    Es gibt auch einige <a href='/de/Quests.aspx'>Missionen</a> die komplexere <a href='/de/Commerce/TradeRoutes.aspx'>Handelsrouten</a> erfordern: es wird vielleicht nötig sein 
    mehr als ein Handelgut zu tauschen, oder sogar auf einer Deadline (Beispiel: 
    <a href='/de/Quest/Complete10Level1TradeRoutes.aspx'>Vollende 10 Handelsrouten mit "Werkzeuge oder Vorräte" in 24 Stunden</a>).
  </p></div>
	
</asp:Content>