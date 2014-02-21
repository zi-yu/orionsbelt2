<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Servicios Premium
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comercio</h2><ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a></li><li><a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a></li><li><a href='/es/Commerce/Shop.aspx'>Servicios Premium</a></li><li><a href='/es/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Servicios Premium</h1>
<div class="content">
    En la <a href='/es/Commerce/Shop.aspx'>Servicios Premium</a> puedes comprar servicios especiales que te van a asistir en el juego y bajar su dificultad. Solo
    puedes comprar estos servicios usando <a href='/es/Commerce/Orions.aspx'>Orions</a>.
    <p />
    Lista de servicios Disponibles:
    <ul><li><a href='/es/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Reducción de 30% en el costo de recursos intrínsicos de los edificios y la Unidades de Combate</a></li><li><a href='/es/Commerce/Shop.aspx#BuyRareDeduction'>Reducción de 30% en el costo de recursos raros de los edificios y Unidades de Combate</a></li><li><a href='/es/Commerce/Shop.aspx#BuyQueueSpace'>3 espacios adicionales en la lista de espera. Estos espacios adicionales estarán Disponibles en la lista de espera de Edifícios y Unidades.</a></li><li><a href='/es/Commerce/Shop.aspx#BuyFastSpeed'>Velocidad de construcción aumentada en 50%</a></li><li><a href='/es/Commerce/Shop.aspx#BuyFullLineOfSight'>Remoción de la Niebla de Guerra en el universo descubierto</a></li><li><a href='/es/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Dejar todo el universo descubierto</a></li></ul><a name="BuyIntrinsicDeduction" id="BuyIntrinsicDeduction"></a><h2><a href='/es/Commerce/Shop.aspx#BuyIntrinsicDeduction'>Reducción de 30% en el costo de recursos intrínsicos de los edificios y la Unidades de Combate</a></h2>
    Con este servicio activado, los costos <a href='/es/IntrinsicIndex.aspx'>Intrínsicos</a> de tus <a href='/es/FacilityIndex.aspx'>Edificios</a> y <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> serán 30%
    mas bajos. Esto solo se aplica a los recursos de tu <a href='/es/Race/Races.aspx'>Raza</a>, no afectará recursos raros.

    <ul><li>Si fueras de los <a href='/es/Race/LightHumans.aspx'>Utopianos</a>, afecta <a class='energy' href='/es/Intrinsic/Energy.aspx'>Energía</a>, <a class='serium' href='/es/Intrinsic/Serium.aspx'>Serium</a> y <a class='mithril' href='/es/Intrinsic/Mithril.aspx'>Mithril</a></li><li>Si fueras de los <a href='/es/Race/DarkHumans.aspx'>Renegados</a>, afecta <a class='gold' href='/es/Intrinsic/Gold.aspx'>Oro</a>, <a class='titanium' href='/es/Intrinsic/Titanium.aspx'>Titanio</a> y <a class='uranium' href='/es/Intrinsic/Uranium.aspx'>Uranio</a></li><li>Si fueras de los <a href='/es/Race/Bugs.aspx'>Levyr</a>, afecta <a class='protol' href='/es/Intrinsic/Protol.aspx'>Protol</a> y <a class='elk' href='/es/Intrinsic/Elk.aspx'>Comida</a></li></ul><a name="BuyRareDeduction" id="BuyRareDeduction"></a><h2><a href='/es/Commerce/Shop.aspx#BuyRareDeduction'>Reducción de 30% en el costo de recursos raros de los edificios y Unidades de Combate</a></h2>
    Con este servicio activado, los costos <a href='/es/IntrinsicIndex.aspx'>Intrínsicos</a> de tus <a href='/es/FacilityIndex.aspx'>Edificios</a> y <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> serán 30%
    mas bajos. Al contrário del servicio anterior, este es solamente válido para los recursos raros: 
    <a class='astatine' href='/es/Intrinsic/Astatine.aspx'>Astatine</a>, <a class='prismal' href='/es/Intrinsic/Prismal.aspx'>Prismal</a>, <a class='radon' href='/es/Intrinsic/Radon.aspx'>Radon</a>, <a class='cryptium' href='/es/Intrinsic/Cryptium.aspx'>Cryptium</a> e <a class='argon' href='/es/Intrinsic/Argon.aspx'>Argon</a>.

    <a name="BuyQueueSpace" id="BuyQueueSpace"></a><h2><a href='/es/Commerce/Shop.aspx#BuyQueueSpace'>3 espacios adicionales en la lista de espera. Estos espacios adicionales estarán Disponibles en la lista de espera de Edifícios y Unidades.</a></h2>
    La fila de espera es la cantidad de <a href='/es/FacilityIndex.aspx'>Edificios</a> o <a href='/es/UnitIndex.aspx'>Unidades de Combate</a> que puedes colocar en espera para entrar
    en produción. Por omisión, tu lista solo soporta una posición. Esto significa que si estuvieras construyendo
    algo, sólo puedes colocar una orden mas de construción, que se iniciará cuando lo que esta en construcción este terminado. 
    <p />

    Con este servicio puedes colocar 3 ordenes mas en lista de espera.

    <a name="BuyFastSpeed" id="BuyFastSpeed"></a><h2><a href='/es/Commerce/Shop.aspx#BuyFastSpeed'>Velocidad de construcción aumentada en 50%</a></h2>
    El tiempo que algo demora en ser Construido depende de tu factor de producción y de que estes construyendo.
    Con este servicio, tu factor de producción es reducido en un 50%, lo que significa que todo lo que construyas
    va a tomar la del tiempo en quedar listo.

    <a name="BuyFullLineOfSight" id="BuyFullLineOfSight"></a><h2><a href='/es/Commerce/Shop.aspx#BuyFullLineOfSight'>Remoción de la Niebla de Guerra en el universo descubierto</a></h2>
    Tú solo logras ver otros jugadores si  ellos estuvieran operando en tu  <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a>. Tu [LineOfsight]
    es determinada por los <a href='/es/Universe/Planets.aspx'>Planetas</a> y <a href='/es/Universe/Fleet.aspx'>Flotas</a> que tienes próximo a tí. Con este servicio, tendrás <a href='/es/Universe/LineOfSight.aspx'>Área de Visión</a> total
    en el universo descubierto.

    <a name="BuyNoUndiscoveredUniverse" id="BuyNoUndiscoveredUniverse"></a><h2><a href='/es/Commerce/Shop.aspx#BuyNoUndiscoveredUniverse'>Dejar todo el universo descubierto</a></h2>
    Los cuadrados negros en el <a href='/es/Universe/Default.aspx'>Universo</a> son espacio por descubrir. Tu no sabes lo que esta ahí, y necesitas de
    <a href='/es/Universe/Travel.aspx'>Viajar</a> con una <a href='/es/Universe/Fleet.aspx'>Flota</a> para esa localización para ver lo que está alla. Con este servicio, logras ver
    <b>todo</b> el universo como si lo tuvieses  descubierto.
  </div>
	
</asp:Content>