<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Routes commerciales
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a></li><li><a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a></li><li><a href='/fr/Commerce/Shop.aspx'>Services d'abonnement OR</a></li><li><a href='/fr/Commerce/Markets.aspx'>Marchés</a></li><li><a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Trade Routes</h1>
<div class="content">
    Faire une <a href='/fr/Commerce/TradeRoutes.aspx'>Route commerciale</a> est l'action de délivrer un bien en le chargant sur une escadrille, d'une <a href='/fr/Commerce/Markets.aspx'>Marché</a> à un autre.
    <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> sont souvent sonsidérés comme des objectifs pour <a href='/fr/Quests.aspx'>Quêtes</a> de <a href='/fr/MerchantQuests.aspx'>Marchand</a> . En fait, vous pourez seulement charger des biens commerciaux et les échanger entre <a href='/fr/Commerce/Markets.aspx'>Marché</a> si vous avez une quête correspondante en cours.
    <p />
    Chaque <a href='/fr/Commerce/Markets.aspx'>Marché</a> s'occuper d'échanges d'un bien particulier. Par exemple, il pourrait y avoir un <a href='/fr/Commerce/Markets.aspx'>Marché</a> qui s'occupe des
    <a class='supplies' href='/fr/Intrinsic/Supplies.aspx'>approvisionnements</a>. Vous pouves charger les <a class='supplies' href='/fr/Intrinsic/Supplies.aspx'>approvisionnements</a> sur votre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> sur ce <a href='/fr/Commerce/Markets.aspx'>Marché</a>, mais le <a href='/fr/Commerce/Markets.aspx'>Marché</a> n'accepte pas les
    <a class='supplies' href='/fr/Intrinsic/Supplies.aspx'>approvisionnements</a> comme cargaison intéressante car elle possède déjà une puissante route commercial dans ce milieu.
    <p />
    Il y a aussi des <a href='/fr/Quests.aspx'>Quêtes</a> qui demande de réussir des <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> plus complexes: vous devrez échanger plus d'un bien, ou le faire selon une limite de temps (example: <a href='/fr/Quest/Complete10Level1TradeRoutes.aspx'>Complétez 10 routes commerciales en utilisant les outils ou approvisionnements en 24 heures</a>).
  </div>
	
</asp:Content>