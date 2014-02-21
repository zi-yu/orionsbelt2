<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/fr/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Services d'abonnement OR
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Commerce</h2><ul><li><a href='/fr/Commerce/Orions.aspx'>Orions</a></li><li><a href='/fr/Commerce/AuctionHouse.aspx'>Maison des enchères</a></li><li><a href='/fr/Commerce/Shop.aspx'>Services d'abonnement OR</a></li><li><a href='/fr/Commerce/Markets.aspx'>Marchés</a></li><li><a href='/fr/Commerce/TradeRoutes.aspx'>Routes commerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Sevices privilèges</h1>
<div class="content">
  Dans le <a href='/fr/Commerce/Shop.aspx'>Services d'abonnement OR</a>, vous pouvez achter des services spéciaux pour vous assister où décroître la diffculté du jeu. Vous pouvez seulement utiliser ces services à l'aide d'<a href='/fr/Commerce/Orions.aspx'>Orions</a>.
  <p />
    Voiçi une liste des services disponibles:
    <ul><li><a href='/fr/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Permet d'avoir une réduction de 30% sur la consommation des ressources primaires. (lors de constructions de bâtiments et unités)</a></li><li><a href='/fr/Commerce/Shop.aspx#BuyRareDeduction'>Permet d'avoir une réduction de 30% sur la consommation des ressources rares. (lors de constructions de bâtiments et unités)</a></li><li><a href='/fr/Commerce/Shop.aspx#BuyQueueSpace'>3 espaces additionnels pour votre chaîne de construction. Cet espace sera attribué aux châines de construction d'unités et de bâtiments.</a></li><li><a href='/fr/Commerce/Shop.aspx#BuyFastSpeed'>Construit tout 50% plus rapidement</a></li><li><a href='/fr/Commerce/Shop.aspx#BuyFullLineOfSight'>Pas de brouillard de guerre sur l'univers connu</a></li><li><a href='/fr/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>A pour effet de rendre l'univers complètement découvert.</a></li></ul><a name="BuyIntrinsicDeduction" id="BuyIntrinsicDeduction"></a><h2><a href='/fr/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Permet d'avoir une réduction de 30% sur la consommation des ressources primaires. (lors de constructions de bâtiments et unités)</a></h2>
    Ce service réduit le coût en ressources <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> de vos <a href='/fr/FacilityIndex.aspx'>Constructions</a> et vos <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> de 30%. 
    Ceci est seulement valide pour les ressources <a href='/fr/IntrinsicIndex.aspx'>Intrinsèque</a> et n'affecte pas les ressources rares.
    
    <ul><li>Si vous êtes <a href='/fr/Race/LightHumans.aspx'>Utopians</a>, cela influence les coûts de l'<a class='energy' href='/fr/Intrinsic/Energy.aspx'>Énergie</a>, le <a class='serium' href='/fr/Intrinsic/Serium.aspx'>Serium</a> et le <a class='mithril' href='/fr/Intrinsic/Mithril.aspx'>Mithril</a> </li><li>Si vous êtes <a href='/fr/Race/DarkHumans.aspx'>Renegades</a>, cela influence les coûts d <a class='gold' href='/fr/Intrinsic/Gold.aspx'>Or</a>, du <a class='titanium' href='/fr/Intrinsic/Titanium.aspx'>Titane</a> et de l'<a class='uranium' href='/fr/Intrinsic/Uranium.aspx'>Uranium</a></li><li>Si vous êtes <a href='/fr/Race/Bugs.aspx'>Levyr</a>, cela influence les coûts du <a class='protol' href='/fr/Intrinsic/Protol.aspx'>Protol</a> et du <a class='elk' href='/fr/Intrinsic/Elk.aspx'>Elk</a></li></ul><a name="BuyRareDeduction" id="BuyRareDeduction"></a><h2><a href='/fr/Commerce/Shop.aspx#BuyRareDeduction'>Permet d'avoir une réduction de 30% sur la consommation des ressources rares. (lors de constructions de bâtiments et unités)</a></h2>
 Ce service réduit le coût en ressources [Rare] de vos <a href='/fr/FacilityIndex.aspx'>Constructions</a> et vos <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> de 30%.
    Ceci est valide seulement pour les ressources rares: <a class='astatine' href='/fr/Intrinsic/Astatine.aspx'>Astatine</a>, <a class='prismal' href='/fr/Intrinsic/Prismal.aspx'>Prismal</a>, <a class='radon' href='/fr/Intrinsic/Radon.aspx'>Radon</a>, <a class='cryptium' href='/fr/Intrinsic/Cryptium.aspx'>Cryptium</a>
    et <a class='argon' href='/fr/Intrinsic/Argon.aspx'>Argon</a>.

    <a name="BuyQueueSpace" id="BuyQueueSpace"></a><h2><a href='/fr/Commerce/Shop.aspx#BuyQueueSpace'>3 espaces additionnels pour votre chaîne de construction. Cet espace sera attribué aux châines de construction d'unités et de bâtiments.</a></h2>
   L'espace de chaîne est le nombre de <a href='/fr/FacilityIndex.aspx'>Constructions</a> ou <a href='/fr/UnitIndex.aspx'>Unités de Combat</a> que vous pouvez commander une à la suite de l'autre dans un certain temps. Par défaut, vous avez seulement un espace dans votre chaîne. Cela signifie que si vous construisez quelques chose, il suffit de construire une autre chose supplémentaire, et la construction commencera immédiatement après ce qui est déjà construit..
    <p />
    Avec ce service, votre espace de chaîne augmente à 3.

    <a name="BuyFastSpeed" id="BuyFastSpeed"></a><h2><a href='/fr/Commerce/Shop.aspx#BuyFastSpeed'>Construit tout 50% plus rapidement</a></h2>
    La quantité de temps qu'une construction ou unité nécessite dépends de votre facteur de production et de la nature de ce qui est en construction.
    Avec ce service, votre facteur de production sera réduit par 50%, signifiant que tout ce que construizez prends la moitié du temps habutuel.

    <a name="BuyFullLineOfSight" id="BuyFullLineOfSight"></a><h2><a href='/fr/Commerce/Shop.aspx#BuyFullLineOfSight'>Pas de brouillard de guerre sur l'univers connu</a></h2>
    Vous pouve seulement voir les autres joueurs si ils sont dans votre <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a>. Votre <a href='/fr/Universe/LineOfSight.aspx'>Ligne de vision</a> est déterminé par les <a href='/fr/Universe/Planets.aspx'>Planètes</a> et <a href='/fr/Universe/Fleet.aspx'>Escadrilles</a> que vous avez à proximité. Avec ce service, vous voyez parfaitement tout sur l'univers déjà découvert et nous ne vous montrons pas de brouillard de guerre.

    <a name="BuyNoUndiscoveredUniverse" id="BuyNoUndiscoveredUniverse"></a><h2><a href='/fr/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>A pour effet de rendre l'univers complètement découvert.</a></h2>
    ùles cases noirs sur l'<a href='/fr/Universe/Default.aspx'>Univers</a> sont des endroit qui vous sont inconnus. Vous ne savez pas ce qui se trouve à cet endroit et il faut y <a href='/fr/Universe/Travel.aspx'>Voyage</a> avec une <a href='/fr/Universe/Fleet.aspx'>Escadrile</a> pour savoir ce qui s'y trouve. Avec ce service, <b>tout</b>
    l'univers sera marqué comme découvert.
  </div>
	
</asp:Content>