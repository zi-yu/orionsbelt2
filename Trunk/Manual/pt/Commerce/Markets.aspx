<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/pt/Resources.Master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
	Mercados
</asp:Content>

<asp:Content ContentPlaceHolderID="conceptMenu" runat="server">
	<h2>Comércio</h2><ul><li><a href='/pt/Commerce/Orions.aspx'>Orions</a></li><li><a href='/pt/Commerce/AuctionHouse.aspx'>Casa de Leilões</a></li><li><a href='/pt/Commerce/Shop.aspx'>Serviços Premium</a></li><li><a href='/pt/Commerce/Markets.aspx'>Mercados</a></li><li><a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a></li></ul>
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
	
	<h1>Mercados</h1>
	<div class="description">
	Os <a href='/pt/Commerce/Markets.aspx'>Mercados</a> existem ao longo do do <a href='/pt/Universe/Default.aspx'>Universo</a> e têm dois objectivos: a compra de <a href='/pt/IntrinsicIndex.aspx'>Recursos</a> e estabelecer <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> para cumprir
  <a href='/pt/Quests.aspx'>Missões</a> de <a href='/pt/MerchantQuests.aspx'>Comerciante</a>.<p />
  Para comprar <a href='/pt/IntrinsicIndex.aspx'>Recursos</a> é necessário deslocar uma <a href='/pt/Universe/Fleet.aspx'>Armada</a> até ao <a href='/pt/Commerce/Markets.aspx'>Mercado</a> e efectuar a compra. Os <a href='/pt/IntrinsicIndex.aspx'>Recursos</a> serão colocados na
  carga da <a href='/pt/Universe/Fleet.aspx'>Armada</a>, de seguida é necessário deslocar a <a href='/pt/Universe/Fleet.aspx'>Armada</a> até um <a href='/pt/Universe/Planets.aspx'>Planeta</a> que se possua e descarregar a carga. Os <a href='/pt/IntrinsicIndex.aspx'>Recursos</a> raros
  nem sempre estão disponíveis nos mercados, duas vezes por dia são colocados <a href='/pt/IntrinsicIndex.aspx'>Recursos</a> raros nos <a href='/pt/Commerce/Markets.aspx'>Mercados</a> que não os tiverem.<p />
  Para estabelecer <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> é necessário transportar recursos entre <a href='/pt/Commerce/Markets.aspx'>Mercados</a>. Os recursos usados em <a href='/pt/Commerce/TradeRoutes.aspx'>Rotas de Comércio</a> são os seguintes:
  <ul><li><a class='supplies' href='/pt/Intrinsic/Supplies.aspx'>Mantimentos</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 1</li><li><a class='tools' href='/pt/Intrinsic/Tools.aspx'>Ferramentas</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 1</li><li><a class='alcohol' href='/pt/Intrinsic/Alcohol.aspx'>Álcool</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 3 e 5</li><li><a class='medicine' href='/pt/Intrinsic/Medicine.aspx'>Medicamentos</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 3 e 5</li><li><a class='mercury' href='/pt/Intrinsic/Mercury.aspx'>Mercúrio</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 7</li><li><a class='diamonds' href='/pt/Intrinsic/Diamonds.aspx'>Diamantes</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 7</li><li><a class='animals' href='/pt/Intrinsic/Animals.aspx'>Animais</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 10</li><li><a class='cosmicdust' href='/pt/Intrinsic/CosmicDust.aspx'>Poeira Cósmica</a>, encontrados em alguns <a href='/pt/Commerce/Markets.aspx'>Mercados</a> na área de nível 10</li></ul>
	</div>
</asp:Content>