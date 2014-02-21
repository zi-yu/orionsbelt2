<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Casa de Remates
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comercio</h2><ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a></li><li><a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a></li><li><a href='/es/Commerce/Shop.aspx'>Servicios Premium</a></li><li><a href='/es/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Casa de Remates</h1>
	<div class="description">
	La <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a> es el local donde un jugador puede comprar o vender cosas a otro jugador. Las transacciones son siempre echas usando los <a href='/es/Commerce/Orions.aspx'>Orions</a> como moneda de compra.<p /><h2>Lo que puedo  vender y como puedo vender?</h2>
  Es posible vender recursos y <a href='/es/UnitIndex.aspx'>Unidades</a>.Para vender <a href='/es/UnitIndex.aspx'>Unidades</a> es necesario que ellas estén en la <a href='/es/Universe/Fleet.aspx'>Flota</a> de defensa en el <a href='/es/Universe/Planets.aspx'>Planeta</a> madre.<p />
  Para proceder a la venta (puesta en subasta) es necesario ir a la pagina de <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a>  y despues seguir hacia la página de "Adicionar Subasta" .<p /> 
  En esta página aparecen los recursos/<a href='/es/UnitIndex.aspx'>Unidades</a> que se pueden colocar en subasta así como, el valor pretendio, el valor minimode subasta , el valor de venta inmediata, el tiempo que estará en la 
  <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a> y sí es para hacer publicidad al producto que se colocará a la venta.
  Los campos de obligatorios son la cantidad a colocar en subasta y el valor base de licitación.<p />
  Es necesario y obligatorio que el jugador esté por lo menos 3 días sin cambiar la cuenta, para conseguir poner algo en la <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a>.<p /><h2>Como se procede a una venta?</h2>
  Durante el tiempo escogio cuando el producto fué puesto en la <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a>, se permite a los jugadores liciten o comprem el producto de inmediato.
  En caso de una compra inmediata el jugador que esta vendiendo recibe los <a href='/es/Commerce/Orions.aspx'>Orions</a> de inmediato, en el caso de licitación el vendedor sólo recibe los <a href='/es/Commerce/Orions.aspx'>Orions</a> 
  cuando termina el tiempo de licitación.<p />
  Todas las ventas tienen la tasa de la <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a> asociada que puede variar de 8%-25%, la tasa será mas baja en la medida que el valor da la venta final sea mayor.  
  Esto significa que el vendedor va a recibir el valor de la venta (pagada por otro jugador) menos la tasa de la <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a>.<p />
  En el caso que un producto no fuera vendido, si fuera una unidad vuelve a las  <a href='/es/Universe/Fleet.aspx'>Flota</a> de defensa del <a href='/es/Universe/Planets.aspx'>Planeta</a> madre, si fuera un recurso vuelve al repositorio de recursos hasta el limite máximo de    repositorios.
  Existe aún una página donde el jugador puede ver los productor que tiene en subasta en aquel momento, y los productos que ya vendió en la <a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a> en otros momentos.<p /><h2>Como se procede para comprar?</h2>
  Después de ganar una licitación el jugador recibe el producto comprado en la <a href='/es/Universe/Fleet.aspx'>Flota</a> de defensa del <a href='/es/Universe/Planets.aspx'>Planeta</a> madre. En el caso de ser una unidad ella aparecerá directamente en la 
  <a href='/es/Universe/Fleet.aspx'>Flota</a> y quedará lista para ser movidad para otra <a href='/es/Universe/Fleet.aspx'>Flota</a> que pueda navegar poe el <a href='/es/Universe/Default.aspx'>Universo</a>.<p />
  En el caso de ser un recurso o una <a href='/es/Battles/Ultimate.aspx'>Suprema</a> ella va para la carga de la <a href='/es/Universe/Fleet.aspx'>Flota</a> el <a href='/es/Universe/Planets.aspx'>Planeta</a> madre. En el caso de los recursos cuando son retirados de la carga van para el repositorio de recursos,    en el caso de una <a href='/es/Battles/Ultimate.aspx'>Suprema</a> es creada una  <a href='/es/Universe/Fleet.aspx'>Flota</a> en la orbita del <a href='/es/Universe/Planets.aspx'>Planeta</a> madre en el caso que el jugador no haya llegado al limite de armas, en caso contrario no es posible descargar la    <a href='/es/Battles/Ultimate.aspx'>Suprema</a>.
	</div>
	
</asp:Content>