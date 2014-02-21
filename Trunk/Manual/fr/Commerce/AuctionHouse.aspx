<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Maison des enchères
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a></li><li><a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a></li><li><a href='/fr/Commerce/Shop.aspx'>Services d'abonnement OR</a></li><li><a href='/fr/Commerce/Markets.aspx'>Marchés</a></li><li><a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Maison des enchères</h1>
	<div class="description">
	l'<a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a> est l'endroit ou un joueur peut vendre ou acheter avec un autre joueur. Les transactions sont toujours faites avec les <a href='/fr/Commerce/Orions.aspx'>Orions</a>. <p /><h2>
    Qu'est-ce que vous pouvez vedre et comment?
  </h2>
  Vous pouvez vendre des ressources et des <a href='/fr/UnitIndex.aspx'>Unités</a>. Pour vendre des <a href='/fr/UnitIndex.aspx'>Unités</a> elle doivent se retrouvés sur l'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> de défense de votre planète mère. <p />
  Pour vendre (put into auction) il est nécessaire d'accéder à la page du <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a> et cliquer sur "ajouter à la maison des enchères enchères" <p />
  C'est sur cette page que vous pouvez voir les ressources/<a href='/fr/UnitIndex.aspx'>Unités</a> que vous pouvez mettre en enchère en sélectionnant la quantité, l'offre minimale demandé, la valeur de l'achat instantannée, le temps que l'objet sera en enchère dans le <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a>, et la publicité de cette enchère par rapport à cette anchère.
  Les champs obligatoires sont la quantité et la valeur minimale demandé en Orions. <p />
  Il est nécessaire qu'un compte n'a pa changé de joueur dans les 3 derniers jours pour rajouter un objet dans la <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a>.<p /><h2>
    Comment fonctionne la vente?
  </h2>
  Durant le temps choisit quand le produit est inséré dans la <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a>, il est possible pour les autres joueurs de surenchérir ou acheter le produit en vente immédiatement. 
  Si l'achat est instantanné, le vendeur reçoit immédiatement <a href='/fr/Commerce/Orions.aspx'>Orions</a> immediately, alors qu'une enchère habituel signifie que le vendeur reçoit les <a href='/fr/Commerce/Orions.aspx'>Orions</a>seulement à la fin du temps d'enchère et que le produit est vendu. <p />
  Toutes les ventes dans la <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a> sont taxés de 8% à 25%. Plus l'objet est vendu à un prix élevé, plus petite est la taxe.
  Cela signifie que le vendeur reçoit la valeur de la vente moins la taxe selon le prix finale. <p />
  Si le produit n'est pas vendu, il retourne à la <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> de défense de votre <a href='/fr/Universe/Planets.aspx'>Planète</a> mère si c'est une unité ou directement dans votre banque de ressource si ces une ressource.(à moins que le maximum est attint.) <p />
  Il existe aussi une page ou vous pouvez voir les produits que vous avez actuellement dans la <a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a> et votre gistorique de ventes. <p /><h2>Comment fonctionne les achats? </h2>
  Après avoir gagné une anchère, le joueurs reçoit ce qu'il a gagné dans l'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> de défense de la <a href='/fr/Universe/Planets.aspx'>Planète</a> mère. Si c'est unité, elle apparaît directement dans l'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> et est prête à être utilisé dans une autre <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>pour l'envoyant n'importe-où  travers l'<a href='/fr/Universe/Default.aspx'>Univers</a>. <p />
  Si le produit est une ressource, ou un <a href='/fr/Battles/Ultimate.aspx'>Ultime</a>, ce dernier se retrouve dans la cargaison de l'<a href='/fr/Universe/Fleet.aspx'>Escadrile</a> de défense sur la <a href='/fr/Universe/Planets.aspx'>Planète</a> mère. Dans le cas d'une ressource, il suffit de la décharger dans la banque de ressources pour pouvoir l'utiliser et dans le cas d'une unité <a href='/fr/Battles/Ultimate.aspx'>Ultime</a>, il faut déplacer l'unité dans une nouvelle <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> à la <a href='/fr/Universe/Planets.aspx'>Planète</a> mère si le nombre d'<a href='/fr/Universe/Fleet.aspx'>Escadrilles</a> maximum n'est pas dépass.,
  Sinon, il est impossible d'utiliser l'unité <a href='/fr/Battles/Ultimate.aspx'>Ultime</a> acquise.
	</div>
	
</asp:Content>