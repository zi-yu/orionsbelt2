<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/es/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Rutas Comerciales
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comercio</h2><ul><li><a href='/es/Commerce/Orions.aspx'>Orions</a></li><li><a href='/es/Commerce/AuctionHouse.aspx'>Casa de Remates</a></li><li><a href='/es/Commerce/Shop.aspx'>Servicios Premium</a></li><li><a href='/es/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Rutas de Comercio</h1>
<div class="content">
 Una <a href='/es/Commerce/TradeRoutes.aspx'>Ruta Comercial</a> es el proceso de cargar un recurso comercial en un <a href='/es/Commerce/Markets.aspx'>Market</a> y transportarlo para otro <a href='/es/Commerce/Markets.aspx'>Market</a>. Las <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> 
 son usadas como objetivos de <a href='/es/Quests.aspx'>Misiones</a> de <a href='/es/MerchantQuests.aspx'>Comerciante</a>. De echo, sólo es posible cargar recursos comerciais en un <a href='/es/Commerce/Markets.aspx'>Market</a> se estuvieras en una misión comercial.
    <p />

    Cada <a href='/es/Commerce/Markets.aspx'>Market</a> posee un determinado recurso comercial. Por ejemplo, un <a href='/es/Commerce/Markets.aspx'>Market</a> que posee <a class='supplies' href='/es/Intrinsic/Supplies.aspx'>Suministros</a>,
    no vá a aceptar <a class='supplies' href='/es/Intrinsic/Supplies.aspx'>Suministros</a> como <a href='/es/Commerce/TradeRoutes.aspx'>Ruta Comercial</a>. Es possible cargar <a class='supplies' href='/es/Intrinsic/Supplies.aspx'>Suministros</a> hacia tu <a href='/es/Universe/Fleet.aspx'>Flota</a>, pero no será possibla descargar <a class='supplies' href='/es/Intrinsic/Supplies.aspx'>Suministros</a> para ese mercado.
    <p />
    Hay también <a href='/es/Quests.aspx'>Misiones</a> que requieren <a href='/es/Commerce/TradeRoutes.aspx'>Rutas Comerciales</a> mas complejas. Puede ser necesario cambiar mas que un recurso comercial o hasta hacerlo en un determinado período de tiempo (ejemplo: <a href='/es/Quest/Complete10Level1TradeRoutes.aspx'>Completar diez rutas comerciales de Herramientas o Mantenimiento en 24 horas</a>).
  </div>
	
</asp:Content>