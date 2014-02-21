<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Rotas de Comércio
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comércio</h2><ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a></li><li><a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a></li><li><a href='/pt/Commerce/Shop.aspx'>Serviços Premium</a></li><li><a href='/pt/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Rotas de Comércio</h1>
<div class="content">
    Uma <a href='/pt/Commerce/TradeRoutes.aspx'>Rota Comercial</a> é o processo de carregar um recurso comercial num <a href='/pt/Commerce/Markets.aspx'>Mercado</a> e transportá-lo para outro
    <a href='/pt/Commerce/Markets.aspx'>Mercado</a>. As <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> são usadas como objectivos de <a href='/pt/Quests.aspx'>Missões</a> de <a href='/pt/MerchantQuests.aspx'>Comerciante</a>. De facto, só é possível
    carregar recursos comerciais num <a href='/pt/Commerce/Markets.aspx'>Mercado</a> se estiveres numa missão comercial.
    <p />
    Cada <a href='/pt/Commerce/Markets.aspx'>Mercado</a> possui um determinado recurso comercial. Por exemplo, um <a href='/pt/Commerce/Markets.aspx'>Mercado</a> que possui <a class='supplies' href='/pt/Intrinsic/Supplies.aspx'>Mantimentos</a>,
    não vai aceitar <a class='supplies' href='/pt/Intrinsic/Supplies.aspx'>Mantimentos</a> como <a href='/pt/Commerce/TradeRoutes.aspx'>Rota Comercial</a>. Será possível carregar <a class='supplies' href='/pt/Intrinsic/Supplies.aspx'>Mantimentos</a> para a tua <a href='/pt/Universe/Fleet.aspx'>Armada</a>, mas não
    será possível descarregar <a class='supplies' href='/pt/Intrinsic/Supplies.aspx'>Mantimentos</a> para esse mercado.
    <p />
    Há também <a href='/pt/Quests.aspx'>Missões</a> que requerem <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> mais complexas. Pode ser necessário trocar mais que um
    recurso comercial ou até fazê-lo num determinado período de tempo (exemplo: <a href='/pt/Quest/Complete10Level1TradeRoutes.aspx'>Completar 10 rotas comerciais de Ferramentas ou Mantimentos em 24 horas</a>).
  </div>
	
</asp:Content>