<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Marchés
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a></li><li><a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a></li><li><a href='/fr/Commerce/Shop.aspx'>Services d'abonnement OR</a></li><li><a href='/fr/Commerce/Markets.aspx'>Marchés</a></li><li><a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Marchés</h1>
	<div class="description">
	Les <a href='/fr/Commerce/Markets.aspx'>Marchés</a> sont partout à traver <a href='/fr/Universe/Default.aspx'>Univers</a> et existent pour deux raisons: pour acheter des  <a href='/fr/IntrinsicIndex.aspx'>Ressources</a> et établir <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> pour terminer les <a href='/fr/Quests.aspx'>Quêtes</a>
  <a href='/fr/MerchantQuests.aspx'>Marchand</a>. <p />
  Pour acheter des <a href='/fr/IntrinsicIndex.aspx'>Ressources</a> il est nécessaire de bouger une <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> jusqu'au <a href='/fr/Commerce/Markets.aspx'>Marché</a> apour faire l'achat. LES <a href='/fr/IntrinsicIndex.aspx'>Ressources</a> seront placés dans votre cargaison de cet <a href='/fr/Universe/Fleet.aspx'>Escadrile</a>, que vous devrez conduire à une <a href='/fr/Universe/Planets.aspx'>Planète</a> pour décharger la cargaison. Les <a href='/fr/IntrinsicIndex.aspx'>Ressources</a> rares
 ne sont pas toujours disponibles dans les <a href='/fr/Commerce/Markets.aspx'>Marchés</a>, 2 dois par jours les <a href='/fr/IntrinsicIndex.aspx'>Ressources</a> rare non disponibles dans les <a href='/fr/Commerce/Markets.aspx'>Marchés</a> sont remplacés in. <p />
  Pour établir des <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> il est nécessaire de transporter des ressources entre les <a href='/fr/Commerce/Markets.aspx'>Marchés</a>. Les ressources utilisés dans les <a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a> sont:
  <ul><li>
  <a class='supplies' href='/fr/Intrinsic/Supplies.aspx'>approvisionnements</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 1.
    </li><li>
  <a class='tools' href='/fr/Intrinsic/Tools.aspx'>Outils</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 1.
    </li><li>
  <a class='alcohol' href='/fr/Intrinsic/Alcohol.aspx'>Alcool</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 3 et 5.
    </li><li>
  <a class='medicine' href='/fr/Intrinsic/Medicine.aspx'>Médicaments</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 3 et 5.
    </li><li>
  <a class='mercury' href='/fr/Intrinsic/Mercury.aspx'>Mercure</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 7.
    </li><li>
  <a class='diamonds' href='/fr/Intrinsic/Diamonds.aspx'>Diamants</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 7.
    </li><li>
  <a class='animals' href='/fr/Intrinsic/Animals.aspx'>Animaux</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 10.
    </li><li>
  <a class='cosmicdust' href='/fr/Intrinsic/CosmicDust.aspx'>Poudre Cosmique</a>, qu'on peut trouver dans les marchés <a href='/fr/Commerce/Markets.aspx'>Marchés</a> dans les zones de niveau 10.
    </li></ul>
	</div>
</asp:Content>