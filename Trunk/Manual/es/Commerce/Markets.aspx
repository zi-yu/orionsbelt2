<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercados
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comercio</h2><ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a></li><li><a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a></li><li><a href='/es/Commerce/Shop.aspx'>Servicios Premium</a></li><li><a href='/es/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Mercados</h1>
	<div class="description">
	Los <a href='/es/Commerce/Markets.aspx'>Mercados</a> existen a lo largo de <a href='/es/Universe/Default.aspx'>Universo</a> y tienen dos objetivos: la compra de <a href='/es/IntrinsicIndex.aspx'>Recursos</a> y estabelecer <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> para cumplir
  <a href='/es/Quests.aspx'>Misiones</a> de <a href='/es/MerchantQuests.aspx'>Comerciante</a>.<p />
  Para comprar <a href='/es/IntrinsicIndex.aspx'>Recursos</a> es necesario trasladar una <a href='/es/Universe/Fleet.aspx'>Flota</a> hasta los  <a href='/es/Commerce/Markets.aspx'>Market</a> y efectuar la compra. Los <a href='/es/IntrinsicIndex.aspx'>Recursos</a> serán colocados en la
  carga de la <a href='/es/Universe/Fleet.aspx'>Flota</a>, enseguida se hace necesario trasladar la <a href='/es/Universe/Fleet.aspx'>Flota</a> hasta un <a href='/es/Universe/Planets.aspx'>Planeta</a> que se posea y descargar la carga. Los <a href='/es/IntrinsicIndex.aspx'>Recursos</a> raros
  no siempre están disponibles en los mercados, dos veces por día son colocados <a href='/es/IntrinsicIndex.aspx'>Recursos</a> raros en los <a href='/es/Commerce/Markets.aspx'>Mercados</a> que no los tuvieran.<p />
  Para establecer <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> es necesário transportar recursos entre <a href='/es/Commerce/Markets.aspx'>Mercados</a>. Los recursos usados em <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> son los siguientes:
  <ul><li><a class='supplies' href='/es/Intrinsic/Supplies.aspx'>Suministros</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la área de nível 1</li><li><a class='tools' href='/es/Intrinsic/Tools.aspx'>Herramientas</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la áreade nível 1</li><li><a class='alcohol' href='/es/Intrinsic/Alcohol.aspx'>Alcohol</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la área de nível 3 e 5</li><li><a class='medicine' href='/es/Intrinsic/Medicine.aspx'>Medicamentos</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la área de nível 3 e 5</li><li><a class='mercury' href='/es/Intrinsic/Mercury.aspx'>Mercúrio</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la área de nível 7</li><li><a class='diamonds' href='/es/Intrinsic/Diamonds.aspx'>Diamantes</a>, encontrados en alguns <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la área de nível 7</li><li><a class='animals' href='/es/Intrinsic/Animals.aspx'>Animales</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> en la área de nível 10</li><li><a class='cosmicdust' href='/es/Intrinsic/CosmicDust.aspx'>Polvadera Cósmica</a>, encontrados en algunos <a href='/es/Commerce/Markets.aspx'>Mercados</a> na en la área de nível 10</li></ul>
	</div>
</asp:Content>